using Hangfire;
using KuceZBronksuBLL.Models;
using KuceZBronksuBLL.Services.IServices;
using KuceZBronksuDAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KuceZBronksuWEB.Controllers
{
	public class AccountController : Controller
	{
		private readonly IUserService _userService;
		private readonly IRecipeService _recipeService;
		private readonly ITimeService _timeService;
		private readonly SignInManager<User> _signInManager;

		public AccountController(SignInManager<User> signInManager, IUserService userService, IRecipeService recipeService, ITimeService timeService)
		{
			_signInManager = signInManager;
			_recipeService = recipeService;
			_userService = userService;
			_timeService = timeService;
		}

		[Authorize(Roles = "Admin")]
		public IActionResult AdministratorPanel()
		{
			return View();
		}

		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> ShowAllUsers()
		{
			var users = await _userService.ShowAllUsers();

			return View(users);
		}

		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> ShowRecipeWaitingToBeAdd()
		{
			var recipeWaitingToBeAdd = (await _recipeService.RecipeWaitingToBeAdd()).ToList();
			var result = recipeWaitingToBeAdd;
			return View(result);
		}

		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> AddRecipe(int id)
		{
			await _recipeService.ChangeApprovedOfRecipe(id);
			return RedirectToAction("ShowRecipeWaitingToBeAdd");
		}

		[Authorize(Roles = "Admin")]
		public IActionResult DeleteRecipe(int id)
		{
			_recipeService.DeleteRecipe(id);
			return RedirectToAction("ShowRecipeWaitingToBeAdd");
		}

		[Authorize(Roles = "Admin")]
		public IActionResult ChangeTimeOfEmailSend()
		{
			return View();
		}

		[Authorize(Roles = "Admin")]
		public IActionResult ChangeTimeOfCyclicalEmailing(TimeViewModel model)
		{
			RecurringJob.AddOrUpdate<ITimeService>("SendEmailToAdmin", service => service.SendEmailToAdmin(), Cron.Daily(model.TimeOfCyclicalEmailing));
			return RedirectToAction("AdministratorPanel");
		}
	}
}
using KuceZBronksuBLL.Models;
using KuceZBronksuBLL.Services;
using KuceZBronksuBLL.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Pkcs;
using Hangfire;

namespace KuceZBronksuWEB.Controllers
{
	public class AccountController : Controller
	{
		private readonly IUserService _userService;
		private readonly IRecipeService _recipeService;

		public AccountController(IUserService userService, IRecipeService recipeService)
		{
			_recipeService = recipeService;
			_userService = userService;
		}

		public IActionResult Login()
		{
			return View();
		}

		public IActionResult Registration()
		{
			return View();
		}

		[Authorize(Roles = "Admin")]
		public IActionResult AdministratorPanel()
		{
			return View();
		}

		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> ShowAllUsers()
		{
			return View(await _userService.ShowAllUsers());
		}

		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> ShowRecipeWaitingToBeAdd()
		{
			var result = (await _recipeService.RecipeWaitingToBeAdd()).ToList();
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
	}
}
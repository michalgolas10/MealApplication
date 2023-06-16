using Hangfire;
using KuceZBronksuBLL.Models;
using KuceZBronksuBLL.Services.IServices;
using KuceZBronksuDAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KuceZBronksuWEB.Controllers
{
	public class AccountController : Controller
	{
		private readonly IUserService _userService;
		private readonly IRecipeService _recipeService;
		private readonly ITimeService _timeService;
		private readonly IGetReportService _getReportService;
		private readonly IPostReportService _reportService;
		private readonly SignInManager<User> _signInManager;
		private readonly ICreateReportService _creaReportService;

		public AccountController(SignInManager<User> signInManager, IUserService userService, IRecipeService recipeService, ITimeService timeService, IGetReportService getReportService, IPostReportService reportService, ICreateReportService createRecipeService)
		{
			_signInManager = signInManager;
			_recipeService = recipeService;
			_userService = userService;
			_timeService = timeService;
			_getReportService = getReportService;
			_reportService = reportService;
			_creaReportService = createRecipeService;
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
		public async Task<IActionResult> CreateRaportOfViews()
		{
			var visitedRecipesDTOs = await _getReportService.GetVisitedRecipe();
            var lastLoggedUsersDTOs = await _getReportService.GetLoggedUsers();
            var recipesAddedToFavouritesDTOs = await _getReportService.GetRecipeAddedToFavourite();
            return View(visitedRecipesDTOs);
		}

		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> CountedRecipeViews()
		{
			var recipesModel = await _recipeService.GetAllRecipies();
			var visitedRecipeDTOs = await _getReportService.GetVisitedRecipe();
            var favouriteRecipesDTOs = await _getReportService.GetRecipeAddedToFavourite();
            var countedRecipes = await _creaReportService.CountRecipeViews(recipesModel, visitedRecipeDTOs, favouriteRecipesDTOs);

			return View(countedRecipes);
		}

		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> CreateRaportOfRecipesAddedToFavs()
		{
            var recipesAddedToFavouritesDTOs = await _getReportService.GetRecipeAddedToFavourite();

			return View(recipesAddedToFavouritesDTOs);
        }

		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> DownloadWeeklyRaport()
		{
			await _getReportService.GetFile();
			return Ok();
		}
	}
}


using KuceZBronksuBLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KuceZBronksuWEB.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserService _userService;
		private readonly RecipeService _recipeService;

		public AccountController(UserService userService, RecipeService recipeService)
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
		public async Task<IActionResult> DeleteRecipe(int id)
		{
			await _recipeService.DeleteRecipe(id);
			return RedirectToAction("ShowRecipeWaitingToBeAdd");
		}
	}
}
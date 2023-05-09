using AutoMapper;
using KuceZBronksuBLL.Models;
using KuceZBronksuBLL.Services;
using KuceZBronksuDAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace KuceZBronksuWEB.Controllers
{
    public class RecipeController : Controller
	{
		private readonly RecipeService _recipeService;
		private readonly IMapper _mapper;
		private readonly UserService _userService;
		private readonly UserManager<User> _userManager;

		public RecipeController(UserService userService,
			RecipeService recipeService, IMapper mapper, UserManager<User> userManager)
		{
			_userService = userService;
			_recipeService = recipeService;
			_mapper = mapper;
			_userManager = userManager;
		}

		// GET: RecipeController
		public async Task<ActionResult> Index()
		{
			ViewBag.SearchViewModel = await _recipeService.CreateSearchModelWithMealTypes();
            return View(await _recipeService.GetAllRecipies());
		}

		[HttpPost]
		public async Task<ActionResult> Search(SearchViewModel pageModel)
		{
			if (pageModel == null)
			{
				return View("Index");
			}
			var listOfRecipes = await _recipeService.Search(pageModel);
			ViewBag.SearchViewModel = await _recipeService.CreateSearchModelWithMealTypes();
			return View(listOfRecipes);
		}

		// GET: RecipeController/Details/5
		public async Task<ActionResult> ShowRecipeDetails(int id)
		{
			var result = await _recipeService.GetRecipe(id);
			return View(result);
		}
		public async Task<ActionResult> ShowRecipeDetailsWithViewModel(RecipeViewModel model)
		{
			var result = await _recipeService.GetRecipe(model.Id);
			result.Servings = model.Servings;
			return View(result);
		}

		public async Task<ActionResult> Create()
		{
			return View(_recipeService.GetUniqueValuesOfRecipeLists());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(EditAndCreateViewModel pageModel)
		{
			if (!ModelState.IsValid)
			{
				return View(_recipeService.GetUniqueValuesOfRecipeLists());
			}
			_recipeService.AddRecipeFromCreateView(pageModel);
			return RedirectToAction("CreateComplete");
		}

		public async Task<ActionResult> AddToFavourites(int id)
		{
			ViewBag.Duplicate = $"Recipe is already in your fav";
			var idOfUser = int.Parse(_userManager.GetUserId(HttpContext.User));
			bool hasBeenAdded = await _userService.AddRecipeToFavourites(id, idOfUser);

			if (hasBeenAdded == true)
			{
				return RedirectToAction("Index");
			}

			return RedirectToAction("Index");
		}

		public async Task<ActionResult> FavouriteRecipes()
		{
			var idOfUser = int.Parse(_userManager.GetUserId(HttpContext.User));
			var zmienna = await _userService.GetFavouritesRecipesOfUser(idOfUser);
			return View(zmienna);
		}

		public async Task<ActionResult> DeleteRecipesFromFavourites(int id)
		{
			var idOfUser = int.Parse(_userManager.GetUserId(HttpContext.User));
			await _userService.DeleteRecipeFromFavourites(id, idOfUser);
			return RedirectToAction("FavouriteRecipes");
		}
		
		public async Task<ActionResult> Edit(int id)
		{
			ViewBag.EditWithUniqueValues = await _recipeService.CreateEditViewModelForEdit(id);
			var modelToPass = _recipeService.GetUniqueValuesOfRecipeLists();
			return View(modelToPass);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(EditAndCreateViewModel recipe, int id)
		{
			if (!ModelState.IsValid)
			{
				return View((await _recipeService.CreateEditViewModelForEdit(id)));
			}
			await _recipeService.UpdateEditedRecipe(recipe);
			return RedirectToAction("EditComplete");
		}

		public ActionResult EditComplete()
		{
			return View();
		}

		public ActionResult CreateComplete()
		{
			return View();
		}
		[Authorize(Roles = "Admin")]
		public async Task<ActionResult> DeleteRecipe(int id)
		{
			await _recipeService.DeleteRecipe(id);
			return RedirectToAction("Index");
		}
	}
}
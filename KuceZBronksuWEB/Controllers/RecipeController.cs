using AutoMapper;
using KuceZBronksuBLL.Helpers;
using KuceZBronksuBLL.Models;
using KuceZBronksuBLL.Services.IServices;
using KuceZBronksuDAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace KuceZBronksuWEB.Controllers
{
	public class RecipeController : Controller
	{
		private readonly IRecipeService _recipeService;
		private readonly IMapper _mapper;
		private readonly IUserService _userService;
		private readonly UserManager<User> _userManager;
		private readonly IReportService _reportService;
		private readonly SignInManager<User> _signInManager;

		public RecipeController(IUserService userService,
			IRecipeService recipeService, IMapper mapper, UserManager<User> userManager, IReportService reportService, SignInManager<User> signInManager)
		{
			_userService = userService;
			_recipeService = recipeService;
			_mapper = mapper;
			_userManager = userManager;
			_reportService = reportService;
			_signInManager = signInManager;
		}

		// GET: RecipeController
		public async Task<ActionResult> Index()
		{
			ViewBag.Message = TempData["shortMessage"];
			ViewBag.SearchViewModel = ModelHelper.CreateSearchModelWithMealTypes();
			try
			{
				var containerOfRecipesModelView = (await _recipeService.GetAllRecipies()).ToList();
				if (_signInManager.IsSignedIn(User))
					await _userService.ListOfRecipesWithFavButton(containerOfRecipesModelView, HttpContext.User as ClaimsPrincipal);
				return View(containerOfRecipesModelView);
			}
			catch (NullReferenceException)
			{
				throw new NullReferenceException("Smth went wrong with load most viewed recipes!");
			}
		}

		[HttpPost]
		public async Task<ActionResult> Search(SearchViewModel pageModel)
		{
			ViewBag.Message = TempData["shortMessage"];
			var listOfRecipes = (await _recipeService.Search(pageModel)).ToList();
			if (_signInManager.IsSignedIn(User))
				await _userService.ListOfRecipesWithFavButton(listOfRecipes, HttpContext.User as ClaimsPrincipal);
			ViewBag.SearchViewModel = ModelHelper.CreateSearchModelWithMealTypes();
			if (pageModel == null)
			{
				return View(listOfRecipes);
			}
			return View(listOfRecipes);
		}

		// GET: RecipeController/Details/5
		public async Task<ActionResult> ShowRecipeDetails(int id)
		{
			var RecipeCount = (await _recipeService.GetAllRecipies()).Count();
			if (id > 0 && id < RecipeCount)
			{
				var result = await _recipeService.GetRecipe(id);
				await _reportService.ReportRecipeVisitAsync(result);
				return View(result);
			}
			else
			{
				throw new Exception("There is no such a recipe in database!");
			}
		}

		public async Task<ActionResult> ShowRecipeDetailsWithViewModel(RecipeViewModel model)
		{
			var result = await _recipeService.GetRecipe(model.Id);
			result.Servings = model.Servings;
			return View(result);
		}

		public ActionResult Create()
		{
			return View(ModelHelper.GetUniqueValuesOfRecipeLists());
		}


		public async Task<ActionResult> FavouriteRecipes()
		{
			ViewBag.Message = TempData["shortMessage"];
			var idOfUser = int.Parse(_userManager.GetUserId(HttpContext.User));
			var favUserRecipes = (await _userService.GetFavouritesRecipesOfUser(idOfUser)).ToList();
			return View(favUserRecipes);
		}
		public async Task<ActionResult> Edit(int id)
		{
			var modelForViewBagFilled = await _recipeService.CreateEditViewModelForEdit(id);
			ViewBag.EditWithUniqueValues = modelForViewBagFilled;
			var modelToPass = ModelHelper.GetUniqueValuesOfRecipeLists();
			modelToPass.IngredientLines = modelForViewBagFilled.IngredientLines;
			return View(modelToPass);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(EditAndCreateViewModel pageModel)
		{
			if (!ModelState.IsValid)
			{
				return View(ModelHelper.GetUniqueValuesOfRecipeLists());
			}
			_recipeService.AddRecipeFromCreateView(pageModel);
			TempData["shortMessage"] = "Recipe created successfully. Waiting for administrator approval";
			return RedirectToAction("Index");
		}

		public async Task<ActionResult> AddToFavourites(int id)
		{
			var idOfUser = int.Parse(_userManager.GetUserId(HttpContext.User));
			bool hasBeenAdded = await _userService.AddRecipeToFavourites(id, idOfUser);
			if (hasBeenAdded == true)
			{
				var recipe = await _recipeService.GetRecipe(id);
				await _reportService.ReportAddedToFavouriteAsync(recipe, idOfUser);
				TempData["shortMessage"] = "Recipe added successfully to favourite";
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");
		}
		public async Task<ActionResult> DeleteRecipesFromFavourites(int id)
		{
			var idOfUser = int.Parse(_userManager.GetUserId(HttpContext.User));
			await _userService.DeleteRecipeFromFavourites(id, idOfUser);
			TempData["shortMessage"] = "Recipe deleted from favourites";
			return RedirectToAction("FavouriteRecipes");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(EditAndCreateViewModel recipe, int id)
		{
			if (!ModelState.IsValid)
			{
				return View((await _recipeService.CreateEditViewModelForEdit(id)));
			}
			_recipeService.UpdateEditedRecipe(recipe);
			TempData["shortMessage"] = "Recipe edited successfully. Waiting for administrator approval";
			return RedirectToAction("Index");
		}
		public async Task<ActionResult> DeleteRecipesFromFavouritesFromSearchOrIndex(int id)
		{
			var idOfUser = int.Parse(_userManager.GetUserId(HttpContext.User));
			await _userService.DeleteRecipeFromFavourites(id, idOfUser);
			TempData["shortMessage"] = "Recipe deleted from favourites";
			return RedirectToAction("Index");
		}

		[Authorize(Roles = "Admin")]
		public ActionResult DeleteRecipe(int id)
		{
			_recipeService.DeleteRecipe(id);
			TempData["shortMessage"] = "Deleted recipe from Db";
			return RedirectToAction("Index");
		}
	}
}
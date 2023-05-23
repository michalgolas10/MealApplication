using AutoMapper;
using KuceZBronksuBLL.Models;
using KuceZBronksuBLL.Services;
using KuceZBronksuBLL.Services.IServices;
using KuceZBronksuDAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace KuceZBronksuWEB.Controllers
{
	public class RecipeController : Controller
	{
		private readonly IRecipeService _recipeService;
		private readonly IMapper _mapper;
		private readonly IUserService _userService;
		private readonly UserManager<User> _userManager;

		public RecipeController(IUserService userService,
			IRecipeService recipeService, IMapper mapper, UserManager<User> userManager)
		{
			_userService = userService;
			_recipeService = recipeService;
			_mapper = mapper;
			_userManager = userManager;
		}

		// GET: RecipeController
		public async Task<ActionResult> Index()
		{
            ViewBag.SearchViewModel = ModelHelper.CreateSearchModelWithMealTypes();
			var containerOfRecipesModelView = await _recipeService.GetAllRecipies();
			return View(containerOfRecipesModelView);
		}

		[HttpPost]
		public async Task<ActionResult> Search(SearchViewModel pageModel)
		{
            var listOfRecipes = await _recipeService.Search(pageModel);
			ViewBag.SearchViewModel = ModelHelper.CreateSearchModelWithMealTypes();
				if (pageModel==null)
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

		public async Task<ActionResult> Create()
		{
            return View(ModelHelper.GetUniqueValuesOfRecipeLists());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(EditAndCreateViewModel pageModel)
		{
            if (!ModelState.IsValid)
			{
				return View(ModelHelper.GetUniqueValuesOfRecipeLists());
			}
			_recipeService.AddRecipeFromCreateView(pageModel);
			return RedirectToAction("CreateComplete");
		}

		public async Task<ActionResult> AddToFavourites(int id)
		{
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
			var zmienna = (await _userService.GetFavouritesRecipesOfUser(idOfUser)).ToList();
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
            var modelForViewBagFilled = await _recipeService.CreateEditViewModelForEdit(id);
			ViewBag.EditWithUniqueValues = modelForViewBagFilled;
			var modelToPass = ModelHelper.GetUniqueValuesOfRecipeLists();
			modelToPass.IngredientLines = modelForViewBagFilled.IngredientLines;
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
			_recipeService.UpdateEditedRecipe(recipe);
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
		public ActionResult DeleteRecipe(int id)
		{
            _recipeService.DeleteRecipe(id);
			return RedirectToAction("Index");
		}
	}
}
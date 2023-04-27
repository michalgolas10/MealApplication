using AutoMapper;
using KuceZBronksuBLL.Services;
using KuceZBronksuWEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace KuceZBronksuWEB.Controllers
{
	public class RecipeController : Controller
	{
		private readonly RecipeService _recipeService;
		private readonly IMapper _mapper;
		private readonly UserService _userService;

		public RecipeController(UserService userService,
			RecipeService recipeService, IMapper mapper)
		{
			_userService = userService;
			_recipeService = recipeService;
			_mapper = mapper;
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
		public async Task<ActionResult> ShowRecipeDetails(string id)
		{
			var result = await _recipeService.GetRecipe(id);
			return View(result);
		}

		public async Task<ActionResult> Create()
		{
			return View(await _recipeService.CreateModelForEditAndCreate());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(EditAndCreateViewModel pageModel)
		{
			pageModel.Id = await _recipeService.GenerateNewId();
			if (!ModelState.IsValid)
			{
				return View(await _recipeService.CreateModelForEditAndCreate());
			}
			_recipeService.AddRecipeFromCreateView(pageModel);
			return RedirectToAction("CreateComplete");
		}

		public async Task<ActionResult> AddToFavourites(string id)
		{
			ViewBag.Duplicate = $"Recipe is already in your fav";

			bool hasBeenAdded = await _userService.AddRecipeToFavourites(id);

			if (hasBeenAdded == true)
			{
				return RedirectToAction("Index");
			}

			return RedirectToAction("Index");
		}

		public async Task<ActionResult> FavouriteRecipes()
		{
			//na razie w FavouriteRecipes nie dajemy string Id usera bo nie ma logowania!!!
			var zmienna = await _userService.GetFavouritesRecipesOfUser();
			return View(zmienna);
		}

		public async Task<ActionResult> DeleteRecipesFromFavourites(string id)
		{
			await _userService.DeleteRecipeFromFavourites(id);
			return RedirectToAction("FavouriteRecipes");
		}

		public async Task<ActionResult> Edit(string id)
		{
			return View(await _recipeService.CreateEditViewModelForEdit(id));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(EditAndCreateViewModel recipe, string id)
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

		public async Task<ActionResult> DeleteRecipe(string id)
		{
			await _recipeService.DeleteRecipe(id);
			return RedirectToAction("Index");
		}
	}
}
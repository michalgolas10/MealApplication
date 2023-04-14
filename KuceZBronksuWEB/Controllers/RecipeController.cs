using KuceZBronksuDAL;
using KuceZBronksuWEB.Interfaces;
using KuceZBronksuWEB.Models;
using Microsoft.AspNetCore.Mvc;
using KuceZBronksuBLL.Services.IService;
using AutoMapper;
using KuceZBronksuDAL.Models;
using NuGet.Packaging;

namespace KuceZBronksuWEB.Controllers
{
    public class RecipeController : Controller
    {
        private readonly ISearch<RecipeViewModel> _search;
        private readonly IService<Recipe> _recipeService;
        private readonly IMapper _mapper;
        private readonly IService<User> _userService;

        public RecipeController(IService<User> userService, ISearch<RecipeViewModel> search, IService<Recipe> recipeService, IMapper mapper)
        {
            _userService = userService;
            _search = search;
            _recipeService = recipeService;
            _mapper = mapper;
        }

        // GET: RecipeController
        public async Task<ActionResult> Index()
        {
            var listOfRecipes = await _recipeService.GetAll();
            var SearchViewModel = new SearchViewModel();
            SearchViewModel.ListOfMealType = new List<string> { "breakfast", "dinner/lunch", "teatime" };
            ViewBag.SearchViewModel = SearchViewModel;
            var recipesViews = listOfRecipes.Select(e => _mapper.Map<RecipeViewModel>(e)).ToList();
            return View(recipesViews);
        }

        [HttpPost]
        public async Task<ActionResult> Search(SearchViewModel pageModel)
        {
            if (pageModel == null)
            {
                return View("Index");
            }
            var listOfRecipes = await _search.Search(pageModel);
            var SearchViewModel = new SearchViewModel();
            SearchViewModel.ListOfMealType = new List<string> { "breakfast", "dinner/lunch", "teatime" };
            ViewBag.SearchViewModel = SearchViewModel;
            return View(listOfRecipes);
        }

        // GET: RecipeController/Details/5
        public async Task<ActionResult> ShowRecipeDetails(string label)
        {
            var result = await _search.GetByName(label);
            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateViewModel pageModel)
        {
            if (!ModelState.IsValid)
            {
                return View(pageModel);
            }
            Recipe databaseModel = new Recipe
            {
                Label = pageModel.Label,
                ShareAs = pageModel.ShareAs,
                Calories = double.Parse(pageModel.Calories),
                DietLabels = pageModel.DietLabels,
                HealthLabels = pageModel.HealthLabels,
                Cautions = pageModel.Cautions,
                IngredientLines = pageModel.IngredientLines.Split(",").ToList(),
                RecipeSteps = pageModel.RecipeSteps.Split(",").ToList(),
                CuisineType = pageModel.CuisineType,
                MealType = pageModel.MealType,
                Image = pageModel.Images
            };

            TempDb.Recipes.Add(databaseModel);

            return RedirectToAction("Create");
        }
		public async Task<ActionResult> AddToFavourites(string label)
		{
			var resultRecipe= await _search.GetByNameRecipe(label);
            var users = await _userService.GetAll();
            var user = users.FirstOrDefault();
            var recipes = user.Recipes;
            recipes.Add(resultRecipe);
            user.Recipes= recipes;
            _userService.Update(user);
            return RedirectToAction("Index");
		}
        public async Task<ActionResult> FavouriteRecipes()
        {
            var users = await _userService.GetAll();
            var userId = users.FirstOrDefault().Id;
            var listOfRecipes = await _search.GetRecipesOfUser(userId);
			var recipesViews = listOfRecipes.Select(e => _mapper.Map<RecipeViewModel>(e)).ToList();
			return View(recipesViews);
		}
		public async Task<ActionResult> DeleteRecipesFromFavourites(string label)
        {
			var resultRecipe = await _search.GetByNameRecipe(label);
            resultRecipe.Users = new List<User>();
            _recipeService.Update(resultRecipe);
			return RedirectToAction("FavouriteRecipes");
		}

        public async Task<ActionResult> Edit(string label)
        {
            var pageModel = await _search.GetByName(label);
            return View(pageModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public Task<ActionResult> Edit(RecipeViewModel recipe)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var recipies = _recipeService.GetAll();
            var recipeEdit = recipies.Result.FirstOrDefault(x => x.Label == recipe.Label);

            recipeEdit.Label = recipe.Label;
            recipeEdit.DietLabels = recipe.DietLabels;
            recipeEdit.HealthLabels = recipe.HealthLabels;
            recipeEdit.Calories = recipe.Calories;
            recipeEdit.Cautions = recipe.Cautions;
            recipeEdit.CuisineType = recipe.CuisineType;
            recipeEdit.Image = recipe.Image;
            recipeEdit.IngredientLines = recipe.IngredientLines;
            recipeEdit.MealType = recipe.MealType;
            recipeEdit.RecipeSteps = recipe.RecipeSteps;

            _recipeService.Update(recipeEdit);

            return RedirectToAction("ShowRecipeDetails");

        }
    }
}
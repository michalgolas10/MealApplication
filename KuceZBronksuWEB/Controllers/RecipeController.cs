﻿using KuceZBronksuDAL;
using KuceZBronksuWEB.Interfaces;
using KuceZBronksuWEB.Models;
using Microsoft.AspNetCore.Mvc;
using KuceZBronksuBLL.Services.IService;
using AutoMapper;
using KuceZBronksuDAL.Models;
using NuGet.Packaging;
using Microsoft.EntityFrameworkCore.Diagnostics;
using KuceZBronksuWEB.AutoMapProfiles;
using System.Globalization;

namespace KuceZBronksuWEB.Controllers
{
    public class RecipeController : Controller
    {
        private readonly ISearch<RecipeViewModel> _search;
        private readonly IService<Recipe> _recipeService;
        private readonly IMapper _mapper;
        private readonly IService<User> _userService;
        private readonly EditViewModelMapping _editViewModelMapping;

        public RecipeController(IService<User> userService, ISearch<RecipeViewModel> search, IService<Recipe> recipeService, IMapper mapper, 
            EditViewModelMapping editViewModelMapping)
        {
            _userService = userService;
            _search = search;
            _recipeService = recipeService;
            _mapper = mapper;
            _editViewModelMapping = editViewModelMapping;
        }

        // GET: RecipeController
        public async Task<ActionResult> Index()
        {
            var listOfRecipes = await _recipeService.GetAll();
            var SearchViewModel = new SearchViewModel();
            SearchViewModel.ListOfMealType = new List<string> { "breakfast", "lunch/dinner", "teatime" };
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
            SearchViewModel.ListOfMealType = new List<string> { "breakfast", "lunch/dinner", "teatime" };
            ViewBag.SearchViewModel = SearchViewModel;
            return View(listOfRecipes);
        }

        // GET: RecipeController/Details/5
        public async Task<ActionResult> ShowRecipeDetails(string label)
        {
            var result = await _search.GetByName(label);
            return View(result);
        }

        public async Task<ActionResult> Create()
        {
            var editViewModel = await _search.CreateEditViewModel();
            return View(editViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EditViewModel pageModel)
        {
            var doubleCalories = new double();
            var resultRecipe = _mapper.Map<Recipe>(pageModel);
            resultRecipe.Calories = Double.Parse(pageModel.Calories, CultureInfo.InvariantCulture);
            _recipeService.AddNew(resultRecipe);
            return RedirectToAction("CreateComplete");
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
            var editViewModel = await _search.GetEditViewModel(pageModel);
            //var editViewModel = await _search.CreateEditViewModel();
            //ViewBag.EditViewModel = await _search.CreateEditViewModel();

            return View(editViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditViewModel recipe)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}
            var resultRecipe = await _editViewModelMapping.MapEditViewModel(recipe);
            
            _recipeService.Update(resultRecipe);

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
    }
}
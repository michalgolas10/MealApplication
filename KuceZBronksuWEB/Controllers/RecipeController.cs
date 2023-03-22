using KuceZBronksuDAL;
using KuceZBronksuWEB.Interfaces;
using KuceZBronksuWEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KuceZBronksuWEB.Controllers
{
    public class RecipeController : Controller
    {
        private readonly ISearch<RecipeViewModel> _search;

        public RecipeController(ISearch<RecipeViewModel> search)
        {
            _search = search;
        }

        // GET: RecipeController
        public ActionResult Index()
        {
            var listOfRecipes = _search.GetAll();
            var vm = new RecipiesViewModel()
            {
                Recipies = listOfRecipes,
            };
            return View(vm);
        }

        [HttpPost]
        public ActionResult Search(SearchViewModel pageModel)
        {
            if (pageModel == null)
            {
                return View("Index");
            }
            var listOfRecipes = _search.Search(pageModel);
            var resultModel = new RecipiesViewModel()
            {
                Recipies = listOfRecipes,
                Search = pageModel
            };
            return View(resultModel);
        }

        // GET: RecipeController/Details/5
        public ActionResult ShowRecipeDetails(string label)
        {
            var result = _search.GetByName(label);
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
            if(!ModelState.IsValid)
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
                    Images = new Images
                    {
                        LARGE = new LARGE
                        {
                            Url = pageModel.Images
                        }
                    }
                };

                TempDb.Recipes.Add(databaseModel);

            return RedirectToAction("Create");
        }
    }
}
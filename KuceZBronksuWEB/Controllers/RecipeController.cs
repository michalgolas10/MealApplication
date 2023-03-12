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
            return View("Create");
        }
        [HttpPost]
        public ActionResult CreateRecipe(CreateViewModel pageModel)
        {

            try
            {

                Recipe databaseModel = new Recipe
                {
                    Label = pageModel.Label,
                    ShareAs = pageModel.ShareAs,
                    Calories = pageModel.Calories,
                    DietLabels = pageModel.DietLabels.Split(',').ToList(),
                    HealthLabels = pageModel.HealthLabels.Split(",").ToList(),
                    Cautions = pageModel.Cautions.Split(",").ToList(),
                    IngredientLines = pageModel.IngredientLines.Split(",").ToList(),
                    RecipeSteps = pageModel.RecipeSteps.Split(",").ToList(),
                    CuisineType = pageModel.CuisineType.Split(",").ToList(),
                    MealType = pageModel.MealType.Split(",").ToList(),
                    Images = new Images
                    {
                        LARGE = new LARGE
                        {
                            Url = pageModel.Images
                        }
                    }
                };

                TempDb.Recipes.Add(databaseModel);
            }
            catch (NullReferenceException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return RedirectToAction("Create");
        }
    }
}
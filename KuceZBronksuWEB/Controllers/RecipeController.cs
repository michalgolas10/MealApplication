using KuceZBronksuWEB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KuceZBronksuLogic;
using KuceZBronksuDAL;

namespace KuceZBronksuWEB.Controllers
{
    public class RecipeController : Controller
    {
        // GET: RecipeController
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(SearchViewModel model)
        {
            if(model == null)
            {
                return View("Index");
            }

            List<RecipeViewModel> result = new List<RecipeViewModel>();
            var recipies = TempDb.Recipes;
            if (model.IngrediendsList != null)
            {
                List<string> ingrediends = model.IngrediendsList.Split(',').ToList();
                recipies = KuceZBronksuLogic.Search.SearchByIngredients(ingrediends, recipies);
            }

            if(model.MealType != null) 
            {
                recipies = KuceZBronksuLogic.Search.SearchByMealType(model.MealType.Split(',').ToList(), recipies);
			}

			if (model.KcalAmount != null)
			{
                recipies = KuceZBronksuLogic.Search.SearchByKcal(model.KcalAmount.Value,300d, recipies);
			}

            foreach(var recipe in recipies)
            {
                result.Add(new RecipeViewModel
                {
                    Label = recipe.Label,
                    IngredientLines = recipe.IngredientLines,
                    Calories = recipe.Calories.ToString("0.00"),
                    MealType = recipe.MealType
                });
            }

			return View(result);
        }

        /*
        // GET: RecipeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RecipeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecipeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RecipeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RecipeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RecipeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RecipeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        */
    }
}

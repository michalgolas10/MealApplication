using KuceZBronksuWEB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KuceZBronksuLogic;

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
            if (string.IsNullOrEmpty(model.IngrediendsList))
            {
                var result2 = KuceZBronksuLogic.Search.SearchByMealType(model.MealType.Split(',').ToList());
                return View(result2);
            }
            var ingrediends = model.IngrediendsList.Split(',').ToList();
            var result = KuceZBronksuLogic.Search.SearchByIngredients(ingrediends);
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

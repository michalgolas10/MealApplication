using KuceZBronksuDAL;
using KuceZBronksuWEB.Models;
using KuceZBronksuWEB.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using KuceZBronksuWEB.Interfaces;
using System.Dynamic;

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
            return View(listOfRecipes);
        }

        [HttpPost]
        public ActionResult Search(SearchViewModel model)
        {
            if (model == null)
            {
                return View("Index");
            }
           var listOfRecipes = _search.Search(model);
            return View(listOfRecipes);
        }
        // GET: RecipeController/Details/5
        public ActionResult ShowRecipeDetails(string label)
        {
            var result = _search.GetByName(label);
            return View(result);
        }
        /*
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
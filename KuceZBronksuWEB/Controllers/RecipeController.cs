using KuceZBronksuWEB.Interfaces;
using KuceZBronksuWEB.Models;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult Search(SearchViewModel model)
        {
            if (model == null)
            {
                return View("Index");
            }
            var listOfRecipes = _search.Search(model);
            var vm = new RecipiesViewModel()
            {
                Recipies = listOfRecipes,
                Search = model
            };
            return View(vm);
        }

        // GET: RecipeController/Details/5
        public ActionResult ShowRecipeDetails(string label)
        {
            var result = _search.GetByName(label);
            return View(result);
        }
    }
}
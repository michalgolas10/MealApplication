using KuceZBronksuDAL;
using KuceZBronksuWEB.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using KuceZBronksuDAL.Models;
using NuGet.Packaging;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Globalization;
using KuceZBronksuBLL.Services;

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
            //if (!ModelState.IsValid)
            //{
            //    return View(pageModel);
            //}
            _recipeService.AddRecipeFromCreateView(pageModel);
            return RedirectToAction("CreateComplete");
        }
        public async Task<ActionResult> AddToFavourites(string id)
        {
            await _userService.AddRecipeToFavourites(id);
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
        public async Task<ActionResult> Edit(EditAndCreateViewModel recipe)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(recipe);
            //}
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
using AutoMapper;
using KuceZBronksuBLL.Services.IService;
using KuceZBronksuDAL;
using KuceZBronksuWEB.Interfaces;
using KuceZBronksuWEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KuceZBronksuWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISearch<RecipeViewModel> _search;
        private readonly IService<Recipe> _recipeService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, ISearch<RecipeViewModel> search, IService<Recipe> recipeService, IMapper mapper)
        {
            _logger = logger;
            _search = search;
            _mapper = mapper;
            _recipeService = recipeService;
        }

        public async Task<IActionResult> Index()
        {
            var listOfRecipes = await _recipeService.GetAll();
            var SearchViewModel = new SearchViewModel();
            SearchViewModel.ListOfMealType = new List<string> { "breakfast","lunch/dinner","teatime"};
            ViewBag.SearchViewModel = SearchViewModel;
            var productsViews = listOfRecipes.Select(e => _mapper.Map<RecipeViewModel>(e)).ToList();
            return View(productsViews);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
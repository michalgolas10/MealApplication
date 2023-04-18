using AutoMapper;
using KuceZBronksuBLL.Services;
using KuceZBronksuDAL;
using KuceZBronksuWEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KuceZBronksuWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RecipeService _recipeService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, RecipeService recipeService, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _recipeService = recipeService;
        }

        public async Task<IActionResult> Index()
        {
            var listOfRecipes = await _recipeService.GetThreeMostViewedRecipes();
            ViewBag.SearchViewModel = await _recipeService.CreateSearchModelWithMealTypes();
            return View(listOfRecipes);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
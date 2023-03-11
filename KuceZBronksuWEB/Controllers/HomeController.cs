using KuceZBronksuWEB.Interfaces;
using KuceZBronksuWEB.Models;
using KuceZBronksuWEB.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;
using System.Diagnostics;
using System.Reflection;

namespace KuceZBronksuWEB.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISearch<RecipeViewModel> _search;
        public HomeController(ILogger<HomeController> logger, ISearch<RecipeViewModel> search)
        {
            _logger = logger;
            _search = search;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
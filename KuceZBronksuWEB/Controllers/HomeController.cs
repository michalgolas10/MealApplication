using AutoMapper;
using KuceZBronksuBLL.Helpers;
using KuceZBronksuBLL.Models;
using KuceZBronksuBLL.Services.IServices;
using KuceZBronksuDAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KuceZBronksuWEB.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IRecipeService _recipeService;
		private readonly IMapper _mapper;
        private readonly SignInManager<User> _signInManager;

        public HomeController(SignInManager<User> signInManager, ILogger<HomeController> logger, IRecipeService recipeService, IMapper mapper)
		{
			_signInManager = signInManager;
			_logger = logger;
			_mapper = mapper;
			_recipeService = recipeService;
		}
		public IActionResult ChangeLanguage(string culture)
		{
			Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
				CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
				new CookieOptions() { Expires = DateTimeOffset.UtcNow.AddYears(1) });
			return Redirect(Request.Headers["Referer"].ToString());
		}

		public async Task<IActionResult> Index()
		{
			var listOfRecipes = await _recipeService.GetThreeMostViewedRecipes();
			ViewBag.SearchViewModel = ModelHelper.CreateSearchModelWithMealTypes();
			return View(listOfRecipes);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignOutAsync()
		{
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
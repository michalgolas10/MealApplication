using KuceZBronksuBLL.Services.IServices;
using KuceZBronksuWebApi.BLL.Services.IServices;
using KuceZBronksuWebApi.Contracts;
using Microsoft.AspNetCore.Mvc;


namespace KuceZBronksuWebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class RecipeController : ControllerBase
	{
		private readonly IRecipeAnalysisService _recipeAnalysisService;
		public RecipeController(IRecipeAnalysisService recipeAnalysisService)
		{
			_recipeAnalysisService = recipeAnalysisService;
		}


		[HttpGet]
		public async Task<IActionResult> Get(CreateDateForAnalysisRequest request)
		{
			// GET - jak chcemy raport - dej dane Panie królu złoty

		}

		[HttpPost]
		public async Task<IActionResult> Post()
		{
			//POST - wysyłanie danych tutaj przyjmujemy dane i przekazujemy do bazy danych
		}

	}
}

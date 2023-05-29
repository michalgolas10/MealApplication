using KuceZBronksuAPIBLL.Services.IServices;
using KuceZBronksuDAL.Context;
using KuceZBronksuDAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace KuceZBronksuAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class VisitedRecipeController : ControllerBase
	{
		private readonly MealAppContext _context;
		private readonly ILogger<VisitedRecipeController> _logger;
		private readonly IReportManager _recipeManager;

		public VisitedRecipeController(ILogger<VisitedRecipeController> logger, MealAppContext context, IReportManager recipeManager)
		{
			_logger = logger;
			_context = context;
			_recipeManager = recipeManager;
		}

		[HttpPost(Name = "AddVisitedRecipes")]
		public async Task AddAsyncVisit([FromBody] VisitedRecipe lastLoggedReport)
		{
			await _context.AddAsync(lastLoggedReport);
			await _context.SaveChangesAsync();
		}

		[HttpGet (Name = "GetRecipeViewsData")]
		public async Task<IActionResult> GetRecipeViewsData()
		{
            var recipes = await _recipeManager.GetAll();
            //var recipes = await _recipeManager.GetReport();

			return Ok(recipes);
		}
	}
}
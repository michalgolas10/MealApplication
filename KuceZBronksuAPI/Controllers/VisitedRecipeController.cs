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
		public async Task<ActionResult> AddAsyncVisit([FromBody] VisitedRecipe lastLoggedReport)
		{
			await _context.AddAsync(lastLoggedReport);
			await _context.SaveChangesAsync();
			return Ok();
		}

		[HttpGet (Name = "GetRecipeViewsData")]
		public async Task<IActionResult> GetRecipeViewsData()
		{
            var recipes = await _recipeManager.GetAllVisitedRecipe();
			return Ok(recipes);
		}
	}
}
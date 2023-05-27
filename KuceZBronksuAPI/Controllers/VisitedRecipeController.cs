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

		public VisitedRecipeController(ILogger<VisitedRecipeController> logger, MealAppContext context)
		{
			_logger = logger;
			_context = context;
		}

		[HttpPost(Name = "AddVisitedRecipes")]
		public async Task AddAsyncVisit([FromBody] VisitedRecipe lastLoggedReport)
		{
			await _context.AddAsync(lastLoggedReport);
			await _context.SaveChangesAsync();
		}
	}
}
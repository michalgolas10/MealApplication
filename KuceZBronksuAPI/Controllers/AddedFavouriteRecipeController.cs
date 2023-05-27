using KuceZBronksuDAL.Context;
using KuceZBronksuDAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace KuceZBronksuAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AddedFavouriteRecipeController : ControllerBase
	{
		private readonly MealAppContext _context;
		private readonly ILogger<VisitedRecipeController> _logger;

		public AddedFavouriteRecipeController(ILogger<VisitedRecipeController> logger, MealAppContext context)
		{
			_logger = logger;
			_context = context;
		}

		[HttpPost(Name = "AddedToFavourite")]
		public async Task AddAsyncVisit([FromBody] RecipeAddedToFavourite recipeAddedToFavourite)
		{
			await _context.AddAsync(recipeAddedToFavourite);
			await _context.SaveChangesAsync();
		}
	}
}
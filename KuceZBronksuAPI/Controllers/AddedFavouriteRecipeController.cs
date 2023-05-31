using KuceZBronksuAPIBLL.Models;
using KuceZBronksuAPIBLL.Services.IServices;
using KuceZBronksuDAL.Context;
using KuceZBronksuDAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KuceZBronksuAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AddedFavouriteRecipeController : ControllerBase
	{
		private readonly MealAppContext _context;
		private readonly ILogger<VisitedRecipeController> _logger;
        private readonly IReportManager _recipeManager;

        public AddedFavouriteRecipeController(IReportManager recipeManager, ILogger<VisitedRecipeController> logger, MealAppContext context)
		{
			_recipeManager = recipeManager;
			_logger = logger;
			_context = context;
		}

		[HttpPost(Name = "AddedToFavourite")]
		public async Task<ActionResult> AddAsyncVisit([FromBody] RecipeAddedToFavourite recipeAddedToFavourite)
		{
			await _context.AddAsync(recipeAddedToFavourite);
			await _context.SaveChangesAsync();
			return Ok();
		}
        [HttpGet(Name = "GetRecipesAddedToFavourite")]
        public async Task<IActionResult> Get()
        {
			var recipeAddedToFavourites = await _recipeManager.GetAllAddedToFavouriteRecipes();
            return Ok(recipeAddedToFavourites);
        }
    }
}
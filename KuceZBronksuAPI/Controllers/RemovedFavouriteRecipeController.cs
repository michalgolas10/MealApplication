using KuceZBronksuAPIBLL.Services.IServices;
using KuceZBronksuDAL.Context;
using KuceZBronksuDAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace KuceZBronksuAPI.Controllers
{
    public class RemovedFavouriteRecipeController : Controller
    {
        private readonly MealAppContext _context;
        private readonly ILogger<VisitedRecipeController> _logger;
        private readonly IReportManager _recipeManager;

        public RemovedFavouriteRecipeController(IReportManager recipeManager, ILogger<VisitedRecipeController> logger, MealAppContext context)
        {
            _recipeManager = recipeManager;
            _logger = logger;
            _context = context;
        }

        [HttpPost(Name = "RemovedFromFavourite")]
        public async Task<ActionResult> AddAsyncVisit([FromBody] RecipeAddedToFavourite recipeAddedToFavourite)
        {
            await _context.AddAsync(recipeAddedToFavourite);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet(Name = "GetRecipesRemovedFromFavourite")]
        public async Task<IActionResult> Get()
        {
            var recipeAddedToFavourites = await _recipeManager.GetAllAddedToFavouriteRecipes();
            return Ok(recipeAddedToFavourites);
        }
    }
}

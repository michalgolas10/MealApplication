using KuceZBronksuDAL.Context;
using KuceZBronksuDAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KuceZBronksuAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class VisitedCarController : ControllerBase
	{
		private readonly MealAppContext _context;
		private readonly ILogger<VisitedCarController> _logger;
		public VisitedCarController(ILogger<VisitedCarController> logger, MealAppContext context)
		{
			_logger = logger;
			_context = context;
		}

		[HttpPost(Name = "AddVisitedRecipes")]
		public async Task AddAsyncVisit([FromBody] VisitedRecipe lastLoggedReport)
		{
			//var existingRow = await _context.VisitedRecipes
			//	.FirstOrDefaultAsync<VisitedRecipe>(x => x.UserId == lastLoggedReport.UserId);

			//if (existingRow != null)
			//{
			//	_context.VisitedRecipes.Update(lastLoggedReport);
			//	await _context.SaveChangesAsync();
			//	return;
			//}
			await _context.AddAsync(lastLoggedReport);
			await _context.SaveChangesAsync();
		}
	}
}
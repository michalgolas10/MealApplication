using KuceZBronksuBLL.Models;
using KuceZBronksuBLL.Services.IServices;
using KuceZBronksuWebApi.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KuceZBronksuWebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class RecipeController : ControllerBase
	{
		private readonly IRecipeService _recipeService;
		public RecipeController(IRecipeService recipeService)
		{
			_recipeService = recipeService;
		}


		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateRecipeFav([FromRoute] int id, [FromBody]UpdateRecipeAnalysisDataRequest request)
		{

		}

	}
}

using KuceZBronksuBLL.Models;
using KuceZBronksuBLL.Services.IServices;
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


		[HttpGet]
		public async Task<ActionResult<IEnumerable<RecipeViewModel>>> Get()
		{
			var recipes = await _recipeService.GetAllRecipies();
			return Ok(recipes);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<RecipeViewModel>> GetById(int id)
		{
			var recipe = await _recipeService.GetRecipe(id);

			if (recipe == null)
			{
				return NotFound();
			}

			return Ok(recipe);
		}

		[HttpPost]
		public async Task<ActionResult<RecipeViewModel>> Post([FromBody] RecipeViewModel recipe)
		{
			// Logika obsługi POST /api/recipes
			// Utwórz nowy przepis na podstawie przesłanych danych
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] RecipeViewModel recipe)
		{
			// Logika obsługi PUT /api/recipes/{id}
			// Zaktualizuj przepis o podanym ID na podstawie przesłanych danych
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			// Logika obsługi DELETE /api/recipes/{id}
			// Usuń przepis o podanym ID
		}
	}
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KuceZBronksuBLL.Models
{
	public class EditAndCreateViewModel
	{
		public int? Id { get; set; }

		[DisplayName("Name"), StringLength(100, MinimumLength = 2)]
		public string Label { get; set; }

		[DisplayName("Calories"), StringLength(200, MinimumLength = 2)]
		public string Calories { get; set; }

		[DisplayName("Image"), StringLength(300, MinimumLength = 2)]
		public string Image { get; set; }

		[DisplayName("Ingredients"), Required]
		public List<string> IngredientLines { get; set; }

		[DisplayName("Recipe Steps")]
		public string? RecipeSteps { get; set; }

		[DisplayName("Link"), StringLength(300, MinimumLength = 2)]
		public string? ShareAs { get; set; }

		[DisplayName("Meal Type"), Required]
		public List<string>? MealType { get; set; }

		[DisplayName("Health Labels"), Required]
		public List<string>? HealthLabels { get; set; }

		[DisplayName("Diet Labels"), Required]
		public List<string>? DietLabels { get; set; }

		[DisplayName("Cautions"), Required]
		public List<string>? Cautions { get; set; }

		[DisplayName("Cuisine Type"), Required]
		public List<string>? CuisineType { get; set; }

		[DisplayName("Servings"), Required]
		public int Servings { get; set; }
	}
}
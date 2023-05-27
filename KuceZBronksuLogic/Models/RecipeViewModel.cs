using System.ComponentModel;

namespace KuceZBronksuBLL.Models
{
	public class RecipeViewModel
	{
		public int Id { get; set; }
		public string Label { get; set; }

		[DisplayName("Ingredients")]
		public IEnumerable<string> IngredientLines { get; set; }

		public string? ShareAs { get; set; }

		public decimal Calories { get; set; }

		public IEnumerable<string> MealType { get; set; }

		public IEnumerable<string> RecipeSteps { get; set; }

		public IEnumerable<string> HealthLabels { get; set; }

		public IEnumerable<string> DietLabels { get; set; }

		public IEnumerable<string> Cautions { get; set; }

		public IEnumerable<string> CuisineType { get; set; }
		public string Image { get; set; }
		public int Servings { get; set; }
		public bool Approved { get; set; }
		public bool IsFavourite { get; set; }
	}
}
using KuceZBronksuDAL.Models.BaseEntity;

namespace KuceZBronksuDAL.Models
{
	public class Recipe : Entity
	{
		public string? Label { get; set; }

		public string? ShareAs { get; set; }

		public IEnumerable<string>? DietLabels { get; set; }

		public IEnumerable<string>? HealthLabels { get; set; }

		public IEnumerable<string>? Cautions { get; set; }

		public IEnumerable<string>? IngredientLines { get; set; }

		public IEnumerable<string>? RecipeSteps { get; set; }

		public double Calories { get; set; }

		public IEnumerable<string>? CuisineType { get; set; }

		public IEnumerable<string>? MealType { get; set; }
		public string? Image { get; set; }
		public decimal? Servings { get; set; }
		public ICollection<User>? Users { get; set; }
		public bool Approved { get; set; }
	}
}
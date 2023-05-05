using KuceZBronksuDAL.Models;
using KuceZBronksuDAL.Models.BaseEntity;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace KuceZBronksuDAL
{
	public class Recipe : IEntity
	{
        int? IEntity.Id { get; set; }
        public string? Label { get; set; }

		public string? ShareAs { get; set; }

		public List<string>? DietLabels { get; set; }

		public List<string>? HealthLabels { get; set; }

		public List<string>? Cautions { get; set; }

		public List<string>? IngredientLines { get; set; }

		public List<string>? RecipeSteps { get; set; }

		public double Calories { get; set; }

		public List<string>? CuisineType { get; set; }

		public List<string>? MealType { get; set; }
		public string? Image { get; set; }
		public decimal? Servings { get; set; }
		public User? User { get; set; }
	}
}
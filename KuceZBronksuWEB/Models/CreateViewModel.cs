using KuceZBronksuDAL;

namespace KuceZBronksuWEB.Models
{
    public class CreateViewModel
    {
        public string Label { get; set; }

        public string ShareAs { get; set; }

        public string DietLabels { get; set; }

        public string HealthLabels { get; set; }

        public string Cautions { get; set; }

        public string IngredientLines { get; set; }

        public string RecipeSteps { get; set; }

        public double Calories { get; set; }

        public string CuisineType { get; set; }

        public string MealType { get; set; }

        public string Images { get; set; }
    }
}

using KuceZBronksuDAL;
using System.ComponentModel;

namespace KuceZBronksuWEB.Models
{
    public class RecipeViewModel
    {
        public string Label { get; set; }

        [DisplayName("Ingredients")]
        public List<string> IngredientLines { get; set; }

        public string Calories { get; set; }

        public List<string> MealType { get; set; }

        public List<string> RecipeSteps { get; set; }

        public List<string> HealthLabels { get; set; }

        public List<string> DietLabels { get; set; }

        public List<string> Cautions { get; set; }

        public List<string> CuisineType { get; set; }
        public string Image { get; set; }


    }
}
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

        public SearchViewModel SearchViewModel { get; set; }
    }
}
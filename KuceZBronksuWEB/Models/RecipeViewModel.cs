using KuceZBronksuDAL;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace KuceZBronksuWEB.Models
{
    public class RecipeViewModel
    {
        public string Label { get; set; }

        [DisplayName("Ingredients")]
        public List<string> IngredientLines { get; set; }
        
        public string Calories { get; set; }

        public List<string> MealType { get; set; }
    }
}

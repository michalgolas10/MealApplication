using KuceZBronksuDAL;
using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KuceZBronksuWEB.Models
{
    public class CreateViewModel
    {
        [DisplayName("Name"), StringLength(20, MinimumLength = 2)]
        public string Label { get; set; }

        [DisplayName("Link"), StringLength(200, MinimumLength = 2)]
        public string ShareAs { get; set; }

        [DisplayName("Image"), StringLength(200, MinimumLength = 2)]
        public string Images { get; set; }

        [DisplayName("Ingredients"), StringLength(200, MinimumLength = 2)]
        public string IngredientLines { get; set; }

        [DisplayName("Recipe Steps"), StringLength(2000, MinimumLength = 2)]
        public string RecipeSteps { get; set; }

        [DisplayName("Calories"), StringLength(200, MinimumLength = 2)]
        public string Calories { get; set; }

        [DisplayName("Diet Labels"), Microsoft.Build.Framework.Required]
        public List<string> DietLabels { get; set; }

        [DisplayName("Health Labels"), Microsoft.Build.Framework.Required]
        public List<string> HealthLabels { get; set; }

        [DisplayName("Cautions"), Microsoft.Build.Framework.Required]
        public List<string> Cautions { get; set; }

        [DisplayName("Cuisine Type"), Microsoft.Build.Framework.Required]
        public List <string> CuisineType { get; set; }
        
        [DisplayName("Meal Type"), Microsoft.Build.Framework.Required]
        public List<string> MealType { get; set; }

    }
}

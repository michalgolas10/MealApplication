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

        public RecipeViewModel FillModel(Recipe baseModel) // TODO: Double check and replace all old mappings with this.
        {
            this.Label = baseModel.Label;
            this.IngredientLines = baseModel.IngredientLines;
            this.Calories = baseModel.Calories.ToString("0.00");
            this.MealType = baseModel.MealType;
            this.RecipeSteps = baseModel.RecipeSteps;

            return this;
        }
    }
}
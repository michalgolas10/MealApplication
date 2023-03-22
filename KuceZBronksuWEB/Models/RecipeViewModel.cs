using KuceZBronksuDAL;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;

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

        public List <string> DietLabels { get; set; }

        public List<string> Cautions { get;set; }

        public Images Images { get; set; }

        public List<string> CuisineType { get; set; }

        public RecipeViewModel FillModel(Recipe baseModel)
        {
            this.CuisineType = baseModel.CuisineType;
            this.Label = baseModel.Label;
            this.IngredientLines = baseModel.IngredientLines;
            this.Calories = baseModel.Calories.ToString("0.00");
            this.MealType = baseModel.MealType;
            this.Images = baseModel.Images;
            this.HealthLabels = baseModel.HealthLabels;
            this.DietLabels = baseModel.DietLabels;
            this.Cautions = baseModel.Cautions;
            if(baseModel.RecipeSteps == null)
            {
                this.RecipeSteps = new List<string> {"no data"};
            }
            else
            {
                this.RecipeSteps = baseModel.RecipeSteps;

            }

            return this;
        }
    }
}
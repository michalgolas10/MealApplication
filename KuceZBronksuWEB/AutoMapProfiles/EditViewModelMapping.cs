using KuceZBronksuBLL.Services.IService;
using KuceZBronksuDAL;
using KuceZBronksuWEB.Models;

namespace KuceZBronksuWEB.AutoMapProfiles
{
    public class EditViewModelMapping
    {
        private readonly IService<Recipe> _recipeService;
        public EditViewModelMapping(IService<Recipe> recipeService)
        {
            _recipeService= recipeService;
        }
        public async Task<Recipe> MapEditViewModel(EditViewModel recipe)
        {

            var recipies = await _recipeService.GetAll();
            var recipeToEdit = recipies.FirstOrDefault(x => x.Label == recipe.Label);

            if (recipe.Label != "") { recipeToEdit.Label = recipe.Label; }
            else { recipeToEdit.Label = recipeToEdit.Label; }

            if (recipe.DietLabels != null) { recipeToEdit.DietLabels = recipe.DietLabels; }
            else { recipeToEdit.DietLabels = recipeToEdit.DietLabels; }

            if (recipe.HealthLabels != null) { recipeToEdit.HealthLabels = recipe.HealthLabels; }
            else { recipeToEdit.HealthLabels = recipeToEdit.HealthLabels; }

            if (double.Parse(recipe.Calories) != null) { recipeToEdit.Calories = double.Parse(recipe.Calories); }
            else { recipeToEdit.Calories = recipeToEdit.Calories; }

            if (recipe.Cautions != null) { recipeToEdit.Cautions = recipe.Cautions; }
            else { recipeToEdit.Cautions = recipeToEdit.Cautions; }

            if (recipe.CuisineType != null) { recipeToEdit.CuisineType = recipe.CuisineType; }
            else { recipeToEdit.CuisineType = recipeToEdit.CuisineType; }

            if (recipe.Image != "") { recipeToEdit.Image = recipe.Image; }
            else { recipeToEdit.Image = recipeToEdit.Image; }

            if (recipe.IngredientLines != null) { recipeToEdit.IngredientLines = recipe.IngredientLines.Split(",").ToList(); }
            else { recipeToEdit.IngredientLines = recipeToEdit.IngredientLines; }

            if (recipe.MealType != null) { recipeToEdit.MealType = recipe.MealType; }
            else { recipeToEdit.MealType = recipeToEdit.MealType; }

            if (recipe.RecipeSteps != null) { recipeToEdit.RecipeSteps = recipe.RecipeSteps.Split(",").ToList(); }
            else { recipeToEdit.RecipeSteps = recipeToEdit.RecipeSteps; }

            return recipeToEdit;
        }
    }
}

using KuceZBronksuDAL;
using KuceZBronksuWEB.Models;

namespace KuceZBronksuWEB.Services
{
    public class SearchService
    {
        public static List<RecipeViewModel> Search (SearchViewModel model) 
        {
            List<RecipeViewModel> result = new List<RecipeViewModel>();
            var recipies = TempDb.Recipes;
            if (model.IngrediendsList != null)
            {
                List<string> ingrediends = model.IngrediendsList.Split(',').ToList();
                recipies = KuceZBronksuLogic.Search.SearchByIngredients(ingrediends, recipies);
            }
            if (model.MealType != null)
            {
                recipies = KuceZBronksuLogic.Search.SearchByMealType(model.MealType.Split(',').ToList(), recipies);
            }
            if (model.KcalAmount != null)
            {
                recipies = KuceZBronksuLogic.Search.SearchByKcal(model.KcalAmount.Value, 300d, recipies);
            }
            foreach (var recipe in recipies)
            {
                result.Add(new RecipeViewModel
                {
                    Label = recipe.Label,
                    IngredientLines = recipe.IngredientLines,
                    Calories = recipe.Calories.ToString("0.00"),
                    MealType = recipe.MealType
                });
            }


            return result;
        }

        public static List<RecipeViewModel> Search()
        {
            List<RecipeViewModel> result = new List<RecipeViewModel>();
            var recipies = TempDb.Recipes;
            
            foreach (var recipe in recipies)
            {
                result.Add(new RecipeViewModel
                {
                    Label = recipe.Label,
                    IngredientLines = recipe.IngredientLines,
                    Calories = recipe.Calories.ToString("0.00"),
                    MealType = recipe.MealType
                });
            }
            return result;
        }
    }
}

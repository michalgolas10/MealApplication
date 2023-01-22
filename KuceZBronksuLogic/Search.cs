using KuceZBronksuDAL;
using System.Linq;

namespace KuceZBronksuLogic
{
    public class Search
    {
        public static List<Recipe> SearchByIngredients(List<string> products)
        {
            //Przykładowe dane wejściowe
            //List<string> list = new List<string>() { "mulberries", "sugar" };
            //var wynik = Search.SearchByIngredients(list);

            List<Recipe> result = new List<Recipe>();
            if (products != null)
            {
                foreach (var recipe in TempDb.Recipes)
                {
                    if (products.All(x => recipe.IngredientLines.Any(i => i.Contains(x,StringComparison.CurrentCultureIgnoreCase))))
                    {
                        result.Add(recipe);
                    }
                }
            }
            return result;
        }

        public static List<Recipe> SearchByMealType(List<string> mealType)
        {
            List<Recipe> result = new List<Recipe>();
            if (mealType != null)
            {
                foreach (var recipe in TempDb.Recipes)
                {
                    if (mealType.All(x => recipe.MealType.Any(i => i.Contains(x, StringComparison.CurrentCultureIgnoreCase))))
                    {
                        result.Add(recipe);
                    }
                }
            }
            return result;
        }
    }
}
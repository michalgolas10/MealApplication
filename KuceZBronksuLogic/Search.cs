using KuceZBronksuDAL;

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
                    if (products.All(x => recipe.IngredientLines.Any(i => i.Contains(x, StringComparison.CurrentCultureIgnoreCase))))
                    {
                        result.Add(recipe);
                    }
                }
            }
            return result;
        }

        public static List<Recipe> SearchByMealType(List<string> mealType)
        {
            //Przykładowe dane wejściowe
            //List<string> list = new List<string>() {"lunch/dinner","teatime"};
            //var wynik = Search.SearchByMealType(list);

            List<Recipe> result = new List<Recipe>();
            if (mealType != null)
            {
                foreach (var recipe in TempDb.Recipes)
                {
                    if (mealType.All(x => recipe.MealType.Any(i => i.Equals(x, StringComparison.CurrentCultureIgnoreCase))))
                    {
                        result.Add(recipe);
                    }
                }
            }
            return result;
        }

        public static List<Recipe> SearchByKcal(double kcal, double margin)
        {
            //Przykładowe dane wejściowe
            //var wynik = Search.SearchByKcal(1500d,150d);

            List<Recipe> result = new List<Recipe>();
            if (kcal > 0 && margin >= 0)
            {
                foreach (var recipe in TempDb.Recipes)
                {
                    if (Math.Abs(recipe.Calories - kcal) <= margin)
                    {
                        result.Add(recipe);
                    }
                }
            }
            return result;
        }
    }
}
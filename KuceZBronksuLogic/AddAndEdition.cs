using KuceZBronksuDAL;
using System.Text.RegularExpressions;

namespace KuceZBronksuLogic
{
    public class AddAndEdition
    {
        public static Recipe CreatingRecipeObject()
        {
            Console.WriteLine("Podaj nazwę przepisu który chcesz dodać");
            var label = Console.ReadLine();
            Console.WriteLine("Podaj strone do przepisu");
            var url = Console.ReadLine();
            var calories = AddCalories();
            Console.WriteLine("Podaj etykiety dietetyczne po przecinku");
            var dietLabels = Console.ReadLine();
            var dietLabelssplited = dietLabels.Split(',').ToList();
            Console.WriteLine("Podaj etykiety zdrowotne po przecinku");
            var healthLabels = Console.ReadLine();
            var healthLabelssplited = healthLabels.Split(',').ToList();
            Console.WriteLine("Podaj typ użytych środków konserwujących");
            var cautions = Console.ReadLine();
            var cautionsList = cautions.Split(',').ToList();
            var ingredientsList = AddIngredients();
            Console.WriteLine("Podaj rodzaj kuchni po przecinku");
            string cuisineType = Console.ReadLine();
            var cuisineTypeList = cuisineType.Split(',').ToList();
            var mealTypeList = AddMealType();
            TotalNutrients totalNutrients = new();
            var Recipe = new Recipe()
            {
                Label = label,
                Url = url,
                Calories = calories,
                IngredientLines = ingredientsList,
                DietLabels = dietLabelssplited,
                HealthLabels = healthLabelssplited,
                Cautions = cautionsList,
                CuisineType = cuisineTypeList,
                MealType = mealTypeList,
                TotalNutrients = totalNutrients,
            };
            return Recipe;
        }

        private static List<string> AddMealType()
        {
            Console.WriteLine("Podaj rodzaj dania po przecinku : breakfast , teatime, lunch/dinner");
            string mealType = Console.ReadLine();
            var mealTypeList = new List<string>();
            if (mealType == "breakfast" || mealType == "teatime" || mealType == "lunch/dinner")
            {
                return mealTypeList = mealType.Split(',').ToList();
            }
            else
            {
                Console.WriteLine("Podana wartość nie jest prawidłowa wpisz ponownie :");
                return AddMealType();
            }
        }

        private static double AddCalories()
        {
            Console.WriteLine("Podaj kaloryczność posiłku");
            string calories = Console.ReadLine();
            Regex rx = new Regex(@"^[0-9]+$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (rx.IsMatch(calories))
            {
                return double.Parse(calories);
            }
            else
            {
                Console.WriteLine("Podana wartość nie jest prawidłowa");
                return AddCalories();
            }
        }

        private static List<string> AddIngredients()
        {
            var ingredientLines = new List<string>();
            var ingredient = ",";
            Console.WriteLine(@"Podaj po kolei składniki potrzebne do przepisu po
przecinku zaczynając od ilości w postaci:
składnik1,
skladnik2,
...");
            while ((ingredient.EndsWith(',')))
            {
                ingredient = Console.ReadLine();
                ingredientLines.Add(ingredient);
            }
            return ingredientLines;
        }

        public static void EditRecipe()
        {
        }
    }
}
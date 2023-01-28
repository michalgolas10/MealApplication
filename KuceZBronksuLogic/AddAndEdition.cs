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

            Console.WriteLine("Edycja przepisów\n");
            Console.WriteLine("Jaki przepis chcesz zedytować?\n");
            Console.WriteLine("==========================================\n");

            int i = 0;
            foreach (var name in TempDb.Recipes)
            {
                Console.WriteLine($"{i} - {name.Label}");
                i++;
            }
            Console.WriteLine("\n==========================================\n");
            Console.WriteLine("Wpisz nazwę przepisu - całą lub częściowo (najlepiej minimum 2 następujące po sobie słowa)");
            var nameOfRecipe = Console.ReadLine();

            var recip = TempDb.Recipes.FirstOrDefault(recip => recip.Label.ToLower().Contains(nameOfRecipe.ToLower()));
            if (recip == null)
            {
                Console.WriteLine("Nie znaleziono przepisu");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                RecipeEdition(recip);
            }

        }

        public static void RecipeEdition(Recipe recip)
        {
            Console.Clear();
            Console.WriteLine("Chcesz zmienić nazwę? Jeśli nie, wpisz 'N' ");
            var recipeName = Console.ReadLine();

            if (recipeName.ToLower() == "N")
            {
                recip.Label = recip.Label;
            }
            else
            {
                recip.Label = recipeName;
            }


            Console.WriteLine("\nChcesz zmienić stronę(url) przepisu? Jeśli nie, wpisz 'N' ");
            var recipeUrl = Console.ReadLine();

            if (recipeUrl.ToLower() == "N")
            {
                recip.Url = recip.Url;
            }
            else
            {
                recip.Url = recipeUrl;
            }


            Console.WriteLine("\nChcesz zminić kaloryczność? Wpisz 'Tak' lub 'Nie' ");
            var answerCal = Console.ReadLine();
            if (answerCal.ToLower() == "tak")
            {
                var newCalories = AddCalories();
                recip.Calories = newCalories;
            }
            else if (answerCal.ToLower() == "nie")
            {
                recip.Calories = recip.Calories;
            }
            else
            {
                recip.Calories = recip.Calories;
                Console.WriteLine("Zła odpowiedź. Automatycznie przyjęto odpowiedź 'Nie'");
                Console.WriteLine("Naciśnij dowolny przycisk.");
                Console.ReadKey();
            }

            Console.WriteLine("\nChcesz zmienić etykiety dietetyczne? Wpisz 'Tak' lub 'Nie' ");
            var answerDL = Console.ReadLine();
            if (answerDL.ToLower() == "tak")
            {
                Console.WriteLine("Podaj etykiety dietetyczne po przecinku");
                var dietLabels = Console.ReadLine();
                var dietLabelssplited = dietLabels.Split(',').ToList();

                recip.DietLabels = dietLabelssplited;
            }
            else if (answerDL.ToLower() == "nie")
            {
                recip.DietLabels = recip.DietLabels;
            }
            else
            {
                recip.DietLabels = recip.DietLabels;
                Console.WriteLine("Zła odpowiedź. Automatycznie przyjęto odpowiedź 'Nie'");
                Console.WriteLine("Naciśnij dowolny przycisk.");
                Console.ReadKey();
            }

            Console.WriteLine("\nChcesz zmienić etykiety zdrowotne? Wpisz 'Tak' lub 'Nie' ");
            var answerHL = Console.ReadLine();
            if (answerHL.ToLower() == "tak")
            {
                Console.WriteLine("Podaj etykiety zdrowotne po przecinku");
                var healthLabels = Console.ReadLine();
                var healthLabelssplited = healthLabels.Split(',').ToList();

            }
            else if (answerHL.ToLower() == "nie")
            {
                recip.HealthLabels = recip.HealthLabels;
            }
            else
            {
                recip.HealthLabels = recip.HealthLabels;
                Console.WriteLine("Zła odpowiedź. Automatycznie przyjęto odpowiedź 'Nie'");
                Console.WriteLine("Naciśnij dowolny przycisk.");
                Console.ReadKey();
            }

            Console.WriteLine("\nChcesz zmienić typ środków konserwujących? Wpisz 'Tak' lub 'Nie' ");
            var answerCau = Console.ReadLine();
            if (answerCau.ToLower() == "tak")
            {
                Console.WriteLine("Podaj etykiety zdrowotne po przecinku");
                var cautions = Console.ReadLine();
                var cautionsList = cautions.Split(',').ToList();

            }
            else if (answerCau.ToLower() == "nie")
            {
                recip.Cautions = recip.Cautions;
            }
            else
            {
                recip.Cautions = recip.Cautions;
                Console.WriteLine("Zła odpowiedź. Automatycznie przyjęto odpowiedź 'Nie'");
                Console.WriteLine("Naciśnij dowolny przycisk.");
                Console.ReadKey();
            }

            Console.WriteLine("\nChcesz zminić składniki? Wpisz 'Tak' lub 'Nie' ");
            var answerIng = Console.ReadLine();
            if (answerIng.ToLower() == "tak")
            {
                var newIngredientsList = AddIngredients();
                recip.IngredientLines = newIngredientsList;
            }
            else if (answerIng.ToLower() == "nie")
            {
                recip.IngredientLines = recip.IngredientLines;
            }
            else
            {
                recip.IngredientLines = recip.IngredientLines;
                Console.WriteLine("Zła odpowiedź. Automatycznie przyjęto odpowiedź 'Nie'");
                Console.WriteLine("Naciśnij dowolny przycisk.");
                Console.ReadKey();
            }

            Console.WriteLine("\nChcesz zmienić rodzaj kuchni? Wpisz 'Tak' lub 'Nie' ");
            var answerCuis = Console.ReadLine();
            if (answerCuis.ToLower() == "tak")
            {
                Console.WriteLine("Podaj rodzaj kuchni po przecinku");
                string cuisineType = Console.ReadLine();
                var newCuisineTypeList = cuisineType.Split(',').ToList();

            }
            else if (answerCuis.ToLower() == "nie")
            {
                recip.CuisineType = recip.CuisineType;
            }
            else
            {
                recip.CuisineType = recip.CuisineType;
                Console.WriteLine("Zła odpowiedź. Automatycznie przyjęto odpowiedź 'Nie'");
                Console.WriteLine("Naciśnij dowolny przycisk.");
                Console.ReadKey();
            }

            Console.WriteLine("\nChcesz zmienić rodzaj posiłku? Wpisz 'Tak' lub 'Nie' ");
            var answerMT = Console.ReadLine();
            if (answerMT.ToLower() == "tak")
            {
                var newMealTypeList = AddMealType();
                recip.MealType = newMealTypeList;
            }
            else if (answerMT.ToLower() == "nie")
            {
                recip.MealType = recip.MealType;
            }
            else
            {
                recip.MealType = recip.MealType;
                Console.WriteLine("Zła odpowiedź. Automatycznie przyjęto odpowiedź 'Nie'");
                Console.WriteLine("Naciśnij dowolny przycisk.");
                Console.ReadKey();
            }
        }
    }
}
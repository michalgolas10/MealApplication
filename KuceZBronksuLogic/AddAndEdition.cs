using KuceZBronksuDAL;

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
                ShareAs = url,
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
            if (Validation.ValidationIfMealTypeCorrect(mealType))
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
            if (Validation.ValidationIfNumbers(calories))
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

        /* ================================================ EDYCJA ================================================ */

        public static void RecipeNameEdit(Recipe recip)
        {
            Console.Clear();
            Console.WriteLine("Podaj nową nazwę przepisu. Jeśli nie chcesz jej zmieniać wcisnij 'Enter'");
            var recipeName = Console.ReadLine();

            if (string.IsNullOrEmpty(recipeName))
            {
                Console.WriteLine("\nNie wprowadzono zmian.\n\nNaciśnij dowolny przycisk, żeby kontynuować");
                Console.ReadKey();
                recip.Label = recip.Label;
            }
            else
            {
                Console.WriteLine($"\nWprowadzono zmianę. Nowa nazwa to: {recipeName}");
                Console.WriteLine("\nNaciśnij dowolny przycisk, żeby kontynuować");
                Console.ReadKey();
                recip.Label = recipeName;
            }
        }

        public static void RecipeURLEdit(Recipe recip)
        {
            Console.Clear();
            Console.WriteLine("Podaj stronę(url) do przepisu. Jeśli nie chcesz go zmieniać kliknij 'Enter' ");
            var recipeUrl = Console.ReadLine();

            if (string.IsNullOrEmpty(recipeUrl))
            {
                Console.WriteLine("\nNie wprowadzono zmian.\n\nNaciśnij dowolny przycisk, żeby kontynuować");
                Console.ReadKey();
                recip.ShareAs = recip.ShareAs;
            }
            else if (!recipeUrl.Contains("https://", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("\nNieprawidłowy link.\n\nNaciśnij dowolny przycisk, żeby kontynuować");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"\nWprowadzono zmianę. Nowy adres URL to: {recipeUrl}");
                Console.WriteLine("\nNaciśnij dowolny przycisk, żeby kontynuować");
                Console.ReadKey();
                recip.ShareAs = recipeUrl;
            }
        }

        public static void RecipeKcalEdit(Recipe recip)
        {
            Console.Clear();

            var newCalories = AddCalories();
            Console.WriteLine($"\nWprowadzono zmianę. Nowe kalorie to: {newCalories} kcal");
            Console.WriteLine("\nNaciśnij dowolny przycisk, żeby kontynuować");
            Console.ReadKey();
            recip.Calories = newCalories;
        }

        public static void RecipeDLEdit(Recipe recip)
        {
            Console.Clear();
            Console.WriteLine("Podaj nowe etykiety dietetyczne po przecinku. Jeśli nie chcesz ich zmieniać kliknij 'Enter'");
            var dietLabels = Console.ReadLine();
            if (string.IsNullOrEmpty(dietLabels))
            {
                Console.WriteLine("\nNie wprowadzono zmian.\n\nNaciśnij dowolny przycisk, żeby kontynuować");
                recip.DietLabels = recip.DietLabels;
                Console.ReadKey();
            }
            else
            {
                var dietLabelssplited = dietLabels.Split(',').ToList();
                Console.WriteLine($"\nWprowadzono zmianę etykiet dietetycznych");
                Console.WriteLine("\nNaciśnij dowolny przycisk, żeby kontynuować");
                Console.ReadKey();
                recip.DietLabels = dietLabelssplited;
            }
        }

        public static void RecipeHLEdif(Recipe recip)
        {
            Console.Clear();
            Console.WriteLine("Podaj nowe etykiety zdrowotne po przecinku. Jeśli nie chcesz ich zmieniać kliknij 'Enter'");
            var healthLabels = Console.ReadLine();
            if (string.IsNullOrEmpty(healthLabels))
            {
                Console.WriteLine("\nNie wprowadzono zmian.\n\nNaciśnij dowolny przycisk, żeby kontynuować");
                recip.HealthLabels = recip.HealthLabels;
                Console.ReadKey();
            }
            else
            {
                var healthLabelssplited = healthLabels.Split(',').ToList();
                Console.WriteLine($"\nWprowadzono zmianę etykiet zdrowotnych");
                Console.WriteLine("\nNaciśnij dowolny przycisk, żeby kontynuować");
                Console.ReadKey();
                recip.HealthLabels = healthLabelssplited;
            }
        }

        public static void RecipeCautionEdit(Recipe recip)
        {
            Console.Clear();
            Console.WriteLine("Podaj nowe środki konserwujące po przecinku. Jeśli nie chcesz ich zmieniać kliknij 'Enter'");
            var cautions = Console.ReadLine();
            if (string.IsNullOrEmpty(cautions))
            {
                Console.WriteLine("\nNie wprowadzono zmian.\n\nNaciśnij dowolny przycisk, żeby kontynuować");
                Console.ReadKey();
                recip.Cautions = recip.Cautions;
            }
            else
            {
                var cautionsList = cautions.Split(',').ToList();
                Console.WriteLine($"\nWprowadzono zmianę środków konserwujących");
                Console.WriteLine("\nNaciśnij dowolny przycisk, żeby kontynuować");
                Console.ReadKey();
                recip.Cautions = cautionsList;
            }
        }

        public static void RecipeIngEdit(Recipe recip)
        {
            Console.Clear();
            var newIngredientsList = AddIngredients();
            Console.WriteLine($"\nWprowadzono nową listę składników");
            Console.WriteLine("\nNaciśnij dowolny przycisk, żeby kontynuować");
            Console.ReadKey();
            recip.IngredientLines = newIngredientsList;
        }

        public static void RecipeCuisineEdit(Recipe recip)
        {
            Console.Clear();
            Console.WriteLine("Podaj nowe rodzaje kuchni po przecinku. Jeśli nie chcesz ich zmieniać kliknij 'Enter'");
            string cuisineType = Console.ReadLine();
            if (string.IsNullOrEmpty(cuisineType))
            {
                Console.WriteLine("\nNie wprowadzono zmian.\n\nNaciśnij dowolny przycisk, żeby kontynuować");
                recip.CuisineType = recip.CuisineType;
                Console.ReadKey();
            }
            else
            {
                var newCuisineTypeList = cuisineType.Split(',').ToList();
                Console.WriteLine($"\nWprowadzono nowy rodzaj/rodzaje kuchni");
                Console.WriteLine("\nNaciśnij dowolny przycisk, żeby kontynuować");
                Console.ReadKey();
                recip.CuisineType = newCuisineTypeList;
            }
        }

        public static void RecipeMealTypeEdit(Recipe recip)
        {
            Console.Clear();
            var newMealTypeList = AddMealType();
            Console.WriteLine($"\nWprowadzono nowy typ posiłku");
            Console.WriteLine("\nNaciśnij dowolny przycisk, żeby kontynuować");
            Console.ReadKey();
            recip.MealType = newMealTypeList;
        }
    }
}
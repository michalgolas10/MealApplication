using KuceZBronksuDAL;
using KuceZBronksuLogic;
using System.Text.RegularExpressions;

namespace KuceZBronksuConsole
{
    internal class Options
    {
        public static void FirstOption()
        {
            Console.Clear();
            Console.WriteLine("Podaj ilość kalori jaka ma się znajdować w daniu");
            string ?kcal = Console.ReadLine();
            Regex rx = new Regex(@"^[0-9]+$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (rx.IsMatch(kcal))
            {
            Console.Clear();
            var wynik = Search.SearchByKcal(double.Parse(kcal), 150d);
            PrintRecipes(wynik);
            }
            else
            {
                Console.WriteLine("Podana wartość nie jest prawidłowa prosze podaj poprawną");
                Console.ReadLine();
                FirstOption();
            }
        }

        public static void SecondOption()
        {
            Console.Clear();
            Console.WriteLine("Podaj składniki (oddziel przecinkami)");
            string input = Console.ReadLine();
            List<string> ingredients = input.Split(',').ToList();
            Console.Clear();
            var wynik = Search.SearchByIngredients(ingredients);
            PrintRecipes(wynik);
        }

        public static void ThirdOption()
        {
            Console.Clear();
            string print = "Wybierz porę jedzenia";
            string[] mealTypes = { "Breakfast", "Teatime", "Lunch/Dinner" };
            ConsoleInterface optionInterface = new ConsoleInterface(mealTypes, print);
            int optionIndex = optionInterface.Run();
            string input;
            switch (optionIndex)
            {
                case 0:
                    input = "breakfast";
                    break;

                case 1:
                    input = "teatime";
                    break;

                case 2:
                    input = "lunch/dinner";
                    break;

                default:
                    input = "";
                    break;
            }

            Console.Clear();
            List<string> mealType = input.Split(',').ToList();
            var wynik = Search.SearchByMealType(mealType);
            PrintRecipes(wynik);
        }

        public static void FourthOption()
        {
            AddAndEdition.AddRecipe();
        }

        public static void FifthOption()
        {
            AddAndEdition.EditRecipe();
        }

        public static void SixthOption()
        {
            Console.Clear();
            Console.WriteLine("Podaj jaką ilość kalorii chcesz dostarczyć w ciągu dnia");
            string ?amountOfTodayCalories= Console.ReadLine();
            Regex rx = new Regex(@"^[0-9]+$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (rx.IsMatch(amountOfTodayCalories))
            {
                var wynik = Search.DrawRecipesForDay(int.Parse(amountOfTodayCalories));
                if (!(wynik[0].Label == "Brak danych"))
                    PrintRecipes(wynik);
                else
                {
                    Console.WriteLine("Nie udało się znaleźć odpowiednich przepisów");
                    Console.WriteLine("Wciśnij dowolny przycisk, aby kontynuować");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Podana wartość nie jest prawidłowa");
                Console.WriteLine("Wciśnij dowolny przycisk, aby kontynuować");
                Console.ReadKey();
            }

        }

        public static void SeventhOption()
        {
            Environment.Exit(0);
        }

        private static void PrintRecipes(List<Recipe> wynik)
        {
            if (wynik.Any())
            {
                foreach (var item in wynik)
                {
                    Console.WriteLine($"{item.Label}");
                    Console.WriteLine($"Meal Type: {String.Join(", ", item.MealType.ToArray())} ");
                    Console.WriteLine($"KCAL: {Math.Round(item.Calories, 2)}");
                    Console.WriteLine($"Recipe: {item.Url}");
                    Console.WriteLine($"Ingredients:{String.Join(", ", item.IngredientLines.ToArray())}");
                    Console.WriteLine();
                }
                Console.WriteLine("Wciśnij dowolny przycisk, aby kontynuować");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Nie można znaleźć przepisu z podanymi kryteriami");
                Console.WriteLine();
                Console.WriteLine("Wciśnij dowolny przycisk, aby kontynuować");
                Console.ReadKey();
            }
        }
    }
}
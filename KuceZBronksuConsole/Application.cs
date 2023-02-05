using KuceZBronksuDAL;
using KuceZBronksuLogic;

namespace KuceZBronksuConsole
{
    internal class Application
    {
        public void Start()

        {
            RunMainMenu();
        }


        private void RunMainMenu()
        {
            string prompt = @"Witaj w Aplikacji Kulinarnej. Co chcesz zrobić?

(Użyj strzałek do nawigowania po menu - naciśnij ENTER by zaakceptować)
";
            string[] options = { "1. Wyszukiwanie przepisu po kaloryczności", "2. Wyszukiwanie przepisu po posiadanych składnikach ", "3. Wyszukiwanie przepisu do określonej pory dnia", "4. Wprowadzanie danych z konsoli ", "5. Edycja danych z konsoli", "6. Losuj Śniadanie-Obiad-Kolacja", "7. Wyjście z aplikacji " };
            ConsoleInterface aplicationinterface = new ConsoleInterface(options, prompt);
            int selectedIndex = aplicationinterface.Run();
            switch (selectedIndex)
            {
                case 0:
                    {
                        Console.Clear();
                        Options.FirstOption();
                    }
                    break;

                case 1:
                    {
                        Console.Clear();
                        Options.SecondOption();
                    }
                    break;

                case 2:
                    {
                        Console.Clear();
                        Options.ThirdOption();
                    }
                    break;

                case 3:
                    {
                        Console.Clear();
                        Options.FourthOption();
                    }
                    break;

                case 4:
                    {
                        Console.Clear();
                        Options.FifthOption();
                    }
                    break;

                case 5:
                    {
                        Console.Clear();
                        Options.SixthOption();
                    }
                    break;

                case 6:
                    {
                        Console.Clear();
                        Console.WriteLine("Wychodzisz z aplikacji...");
                        Options.SeventhOption();
                    }
                    break;
            }
        }
    }
    internal class Edition
    {
        public void Start(Recipe recip)
        {
            RunMainMenu(recip);
        }
        private void RunMainMenu(Recipe recip)
        {
            Console.Clear();
            string print = $"Wybrano przepis: {recip.Label}\r\n\r\nWybierz co chcesz zedytować";
            string[] mealTypes = { "Nazwa", "Adres URL", "Kaloryczność", "Etykiety dietetyczne", "Etykiety zdrowotne", "Środki konserwujące", "Składniki", "Rodzaj kuchni", "Rodzaj posiłku", "Koniec edycji" };
            ConsoleInterface optionInterface = new ConsoleInterface(mealTypes, print);
            int optionIndex = optionInterface.Run();
            string input;
            switch (optionIndex)
            {
                case 0:
                    input = "Nazwa";
                    AddAndEdition.RecipeNameEdit(recip);
                    break;
                case 1:
                    input = "Adres URL";
                    AddAndEdition.RecipeURLEdit(recip);
                    break;
                case 2:
                    input = "Kaloryczność";
                    AddAndEdition.RecipeKcalEdit(recip);
                    break;
                case 3:
                    input = "Etykiety dietetyczne";
                    AddAndEdition.RecipeDLEdit(recip);
                    break;
                case 4:
                    input = "Etykiety zdrowotne";
                    AddAndEdition.RecipeHLEdif(recip);
                    break;
                case 5:
                    input = "Środki konserwujące";
                    AddAndEdition.RecipeCautionEdit(recip);
                    break;
                case 6:
                    input = "Składniki";
                    AddAndEdition.RecipeIngEdit(recip);
                    break;
                case 7:
                    input = "Rodzaj kuchni";
                    AddAndEdition.RecipeCuisineEdit(recip);
                    break;
                case 8:
                    input = "Rodzaj posiłku";
                    AddAndEdition.RecipeMealTypeEdit(recip);
                    break;
                case 9:
                    input = "Koniec edycji";
                    Application Application = new Application();
                    while (true)
                    {
                        Application.Start();
                    }
                default:
                    input = "";
                    break;
            }
        }
    }
}
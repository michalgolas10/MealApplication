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
}
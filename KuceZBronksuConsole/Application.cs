using KuceZBronksuDAL;
using KuceZBronksuLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string[] options = { "1. Wyszukiwanie przepisu po kaloryczności", "2. Wyszukiwanie przepisu po posiadanych składnikach ", "3. Wyszukiwanie przepisu do określonej pory dnia","4. Wprowadzanie danych z konsoli ","5. Edycja danych z konsoli","6. Losuj Śniadanie-Obiad-Kolacja","7. Wyjście z aplikacji "};
            ConsoleInterface aplicationinterface = new ConsoleInterface(options, prompt);
            int selectedIndex = aplicationinterface.Run();
            switch (selectedIndex)
            {
                case 0:
                    {   
                        Console.Clear();
                        Console.WriteLine("Wyszukiwanie przepisu po kaloryczności...");
                    }
                    break;
                case 1:
                    {
                        Console.Clear();
                        Console.WriteLine("Wyszukiwanie przepisu po posiadanych składnikach...");
                        
                    }
                    break;
                case 2: {
                        Console.Clear();
                        Console.WriteLine("Wyszukiwanie przepisu do określonej pory dnia...");
                    }
                    break;
                case 3:
                    {
                        Console.Clear();
                        Console.WriteLine("Wprowadzanie danych z konsoli...");
                    }
                    break;
                case 4:
                    {
                        Console.Clear();
                        Console.WriteLine("Edycja danych z konsoli...");
                    }
                    break;
                case 5: {
                        Console.Clear();
                        Console.WriteLine("Losuj Śniadanie-Obiad-Kolacja...");
                    } break;
                case 6: {
                        Console.Clear();
                        Console.WriteLine("Wychodzisz z aplikacji...");
                        ExitApplication(); }
                    break;
            }
        }
        private void ExitApplication()
        {
            Console.WriteLine("Wybrano wyjście z aplikacji");
            Console.WriteLine("Naciśnij dowolny przycisk by wyjść");
            Console.ReadKey();
            Environment.Exit(0);
        }

    }
}

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
            string prompt = @"
 $$$$$$\          $$\$$\$$\                                          $$\   $$\        $$\$$\                                              
$$  __$$\         $$ \__$$ |                                         $$ | $$  |       $$ \__|                                             
$$ /  $$ |$$$$$$\ $$ $$\$$ |  $$\$$$$$$\  $$$$$$$\$$\ $$$$$$\        $$ |$$  $$\   $$\$$ $$\$$$$$$$\  $$$$$$\  $$$$$$\ $$$$$$$\  $$$$$$\  
$$$$$$$$ $$  __$$\$$ $$ $$ | $$  \____$$\$$  _____\__|\____$$\       $$$$$  /$$ |  $$ $$ $$ $$  __$$\ \____$$\$$  __$$\$$  __$$\ \____$$\ 
$$  __$$ $$ /  $$ $$ $$ $$$$$$  /$$$$$$$ $$ /     $$\ $$$$$$$ |      $$  $$< $$ |  $$ $$ $$ $$ |  $$ |$$$$$$$ $$ |  \__$$ |  $$ |$$$$$$$ |
$$ |  $$ $$ |  $$ $$ $$ $$  _$$<$$  __$$ $$ |     $$ $$  __$$ |      $$ |\$$\$$ |  $$ $$ $$ $$ |  $$ $$  __$$ $$ |     $$ |  $$ $$  __$$ |
$$ |  $$ $$$$$$$  $$ $$ $$ | \$$\$$$$$$$ \$$$$$$$\$$ \$$$$$$$ |      $$ | \$$\$$$$$$  $$ $$ $$ |  $$ \$$$$$$$ $$ |     $$ |  $$ \$$$$$$$ |
\__|  \__$$  ____/\__\__\__|  \__\_______|\_______$$ |\_______|      \__|  \__\______/\__\__\__|  \__|\_______\__|     \__|  \__|\_______|
         $$ |                               $$\   $$ |                                                                                    
         $$ |                               \$$$$$$  |                                                                                    
         \__|                                \______/                                                                                     
Witaj w Aplikacji Kulinarnej. Co chcesz zrobić?
(Użyj strzałek do nawigowania po menu - naciśnij ENTER by zaakceptować)
";
            string[] options = { "1. ", "2. ", "3. ","4. ","5. ","6. ","7. Wyjście z aplikacji "};
            ConsoleInterface aplicationinterface = new ConsoleInterface(options, prompt);
            int selectedIndex = aplicationinterface.Run();
            switch (selectedIndex)
            {
                case 0:break;
                case 1: break;
                case 2: break;
                case 3: break;
                case 4: break;
                case 5: break;
                case 6: ExitApplication(); break;
            }
        }
        private void ExitApplication()
        {
            Console.WriteLine("Naciśnij dowolny przycisk by wyjść");
            Console.ReadKey();
            Environment.Exit(0);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuceZBronksuConsole
{
    class ConsoleInterface
    {
        private int SelectedIndex;
        private string[] Options;
        private string Prompt;
        public ConsoleInterface(string[] options, string prompt)
        {
            Options = options;
            Prompt = prompt;
            SelectedIndex = 0;
        }
        private void DisplayOptions()
        {
            Console.WriteLine(Prompt);
            for(int i = 0; i < Options.Length; i++)
            {
                string currentoption = Options[i];
                string prefix;
                if( i == SelectedIndex)
                {
                    prefix = "*";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine($"{prefix}<<{currentoption}>>");
            }
            Console.ResetColor();
        }
        public int Run()
        {
            ConsoleKey keypressed;
            do
            {
                Console.Clear();
                DisplayOptions();
                ConsoleKeyInfo Keyinfo = Console.ReadKey(true);
                keypressed = Keyinfo.Key;
                if (keypressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if (SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }
                else if(keypressed== ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;
                    }
                }
            }  
            while (keypressed != ConsoleKey.Enter);
            return SelectedIndex;
        }
    }
}

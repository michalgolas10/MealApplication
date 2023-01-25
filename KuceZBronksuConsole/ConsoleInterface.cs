namespace KuceZBronksuConsole
{
    internal class ConsoleInterface
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
            var defaultForegroudColor = Console.ForegroundColor;
            var defaultBackgroudColor = Console.BackgroundColor;
            Console.WriteLine(Prompt);
            for (int i = 0; i < Options.Length; i++)
            {
                string currentoption = Options[i];
                string prefix;
                if (i == SelectedIndex)
                {
                    prefix = "*";
                    Console.ForegroundColor = defaultBackgroudColor;
                    Console.BackgroundColor = defaultForegroudColor;
                }
                else
                {
                    prefix = " ";
                    Console.ForegroundColor = defaultForegroudColor;
                    Console.BackgroundColor = defaultBackgroudColor;
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
                else if (keypressed == ConsoleKey.DownArrow)
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
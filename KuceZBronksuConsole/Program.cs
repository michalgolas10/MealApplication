using static KuceZBronksuLogic.DataFileHandler;

namespace KuceZBronksuConsole

{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ReadingDataFromFile();
            Application Application = new Application();
            while (true)
            {
                Application.Start();
            }
        }
    }
}
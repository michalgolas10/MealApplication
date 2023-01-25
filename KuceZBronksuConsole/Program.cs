using KuceZBronksuDAL;
using Newtonsoft.Json.Linq;
using System;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Text.Json.Serialization;
using KuceZBronksuLogic;
using static KuceZBronksuLogic.DataFileHandler;

namespace KuceZBronksuConsole 

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Application Application = new Application();
            Application.Start();
            ReadingDataFromFile();
        }
    }
}
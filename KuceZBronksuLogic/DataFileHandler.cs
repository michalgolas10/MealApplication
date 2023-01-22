using KuceZBronksuDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;
using KuceZBronksuDAL.Models;

namespace KuceZBronksuLogic
{
    public class DataFileHandler
    {
        public static void ReadingDataFromFile()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            string JsonDeserialized = File.ReadAllText(@".\JsonFiles\recipies.json");
            
            var RecipeList = JsonSerializer.Deserialize<List<Root>>(JsonDeserialized, options);
            
        }

    }
}

using KuceZBronksuDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;

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
            string IngredientsDeserialized = File.ReadAllText(@"C:\Users\shazu\source\repos\jcszr8-KuceZBronksu\flavours.json");
            var IngredientsList = JsonSerializer.Deserialize<List<Ingredient>>(IngredientsDeserialized,options);
            string FlavoursCombinationsDeserialized = File.ReadAllText(@"C:\Users\shazu\source\repos\jcszr8-KuceZBronksu\flavours combinations.json");
            var FlavourCombinationsList = JsonSerializer.Deserialize<List<FlavoursCombionations>>(FlavoursCombinationsDeserialized);
        }

    }
}

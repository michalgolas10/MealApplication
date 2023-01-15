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
            string IngredientsDeserialized = File.ReadAllText(@"C:\Users\Baja\Desktop\jcszr8-KuceZBronksu\flavours.json");
            var IngredientsList = JsonSerializer.Deserialize<List<Ingredient>>(IngredientsDeserialized);
            string FlavoursCombinationsDeserialized = File.ReadAllText(@"C:\Users\Baja\Desktop\jcszr8-KuceZBronksu\flavours combinations.json");
            var FlavourCombinationsList = JsonSerializer.Deserialize<List<FlavoursCombionations>>(FlavoursCombinationsDeserialized);
        }

    }
}

using KuceZBronksuDAL;
using KuceZBronksuDAL.Models;
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
            string JsonDeserialized = File.ReadAllText(@".\JsonFiles\recipies.json");

            var recipeList = JsonSerializer.Deserialize<List<Root>>(JsonDeserialized, options);
            if (recipeList != null)
            {
                TempDb.Recipes = recipeList.Select(x => x.Recipe).ToList();
            }
            else
            {
                throw new ArgumentException("Error while deserializing file.");
            }
        }
    }
}
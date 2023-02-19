using System.Text.Json.Serialization;

namespace KuceZBronksuDAL
{
    public class Recipe
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("shareAs")]
        public string ShareAs { get; set; }

        [JsonPropertyName("dietLabels")]
        public List<string> DietLabels { get; set; }

        [JsonPropertyName("healthLabels")]
        public List<string> HealthLabels { get; set; }

        [JsonPropertyName("cautions")]
        public List<string> Cautions { get; set; }

        [JsonPropertyName("ingredientLines")]
        public List<string> IngredientLines { get; set; }

        [JsonPropertyName("calories")]
        public double Calories { get; set; }

        [JsonPropertyName("cuisineType")]
        public List<string> CuisineType { get; set; }

        [JsonPropertyName("mealType")]
        public List<string> MealType { get; set; }

        [JsonPropertyName("totalNutrients")]
        public TotalNutrients TotalNutrients { get; set; }
    }
}
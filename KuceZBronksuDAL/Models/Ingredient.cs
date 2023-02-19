using System.Text.Json.Serialization;

namespace KuceZBronksuDAL
{
    public class Ingredient
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("quantity")]
        public double Quantity { get; set; }

        [JsonPropertyName("measure")]
        public string Measure { get; set; }

        [JsonPropertyName("food")]
        public string Food { get; set; }

        [JsonPropertyName("weight")]
        public double Weight { get; set; }

        [JsonPropertyName("foodCategory")]
        public string FoodCategory { get; set; }

        [JsonPropertyName("foodId")]
        public string FoodId { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }
    }
}
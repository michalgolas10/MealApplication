using System.Text.Json.Serialization;

namespace KuceZBronksuDAL
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class CA
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("quantity")]
        public double Quantity { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; }
    }
}
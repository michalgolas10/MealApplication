using System.Text.Json.Serialization;

namespace KuceZBronksuDAL
{
    public class FATRN
        {
            [JsonPropertyName("label")]
            public string Label { get; set; }

            [JsonPropertyName("quantity")]
            public double Quantity { get; set; }

            [JsonPropertyName("unit")]
            public string Unit { get; set; }
        }
    }

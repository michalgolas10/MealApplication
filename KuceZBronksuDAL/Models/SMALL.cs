using System.Text.Json.Serialization;

namespace KuceZBronksuDAL
{
    public class SMALL
        {
            [JsonPropertyName("url")]
            public string Url { get; set; }

            [JsonPropertyName("width")]
            public int Width { get; set; }

            [JsonPropertyName("height")]
            public int Height { get; set; }
        }
    }

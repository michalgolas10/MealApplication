using System.Text.Json.Serialization;

namespace KuceZBronksuDAL
{
    public class Images
        {
            [JsonPropertyName("THUMBNAIL")]
            public THUMBNAIL THUMBNAIL { get; set; }

            [JsonPropertyName("SMALL")]
            public SMALL SMALL { get; set; }

            [JsonPropertyName("REGULAR")]
            public REGULAR REGULAR { get; set; }

            [JsonPropertyName("LARGE")]
            public LARGE LARGE { get; set; }
        }
    }

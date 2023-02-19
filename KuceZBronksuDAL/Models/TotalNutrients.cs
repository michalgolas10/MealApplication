using System.Text.Json.Serialization;

namespace KuceZBronksuDAL
{
    public class TotalNutrients
    {
        [JsonPropertyName("FAT")]
        public FAT FAT { get; set; }

        [JsonPropertyName("CHOCDF")]
        public CHOCDF CHOCDF { get; set; }

        [JsonPropertyName("PROCNT")]
        public PROCNT PROCNT { get; set; }
    }
}
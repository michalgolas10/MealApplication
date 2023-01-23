using System.Text.Json.Serialization;

namespace KuceZBronksuDAL
{
    public class Sub
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        [JsonPropertyName("schemaOrgTag")]
        public string SchemaOrgTag { get; set; }

        [JsonPropertyName("total")]
        public double Total { get; set; }

        [JsonPropertyName("hasRDI")]
        public bool HasRDI { get; set; }

        [JsonPropertyName("daily")]
        public double Daily { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; }
    }
}
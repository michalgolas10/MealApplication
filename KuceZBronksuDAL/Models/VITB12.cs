﻿using System.Text.Json.Serialization;

namespace KuceZBronksuDAL
{
    public class VITB12
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("quantity")]
        public double Quantity { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; }
    }
}
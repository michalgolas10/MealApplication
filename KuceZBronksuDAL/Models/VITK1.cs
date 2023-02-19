﻿using System.Text.Json.Serialization;

namespace KuceZBronksuDAL
{
    public class VITK1
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("quantity")]
        public double Quantity { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; }
    }
}
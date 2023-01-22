using System.Text.Json.Serialization;

namespace KuceZBronksuDAL
{
    public class TotalDaily
        {
            [JsonPropertyName("ENERC_KCAL")]
            public ENERCKCAL ENERCKCAL { get; set; }

            [JsonPropertyName("FAT")]
            public FAT FAT { get; set; }

            [JsonPropertyName("FASAT")]
            public FASAT FASAT { get; set; }

            [JsonPropertyName("CHOCDF")]
            public CHOCDF CHOCDF { get; set; }

            [JsonPropertyName("FIBTG")]
            public FIBTG FIBTG { get; set; }

            [JsonPropertyName("PROCNT")]
            public PROCNT PROCNT { get; set; }

            [JsonPropertyName("CHOLE")]
            public CHOLE CHOLE { get; set; }

            [JsonPropertyName("NA")]
            public NA NA { get; set; }

            [JsonPropertyName("CA")]
            public CA CA { get; set; }

            [JsonPropertyName("MG")]
            public MG MG { get; set; }

            [JsonPropertyName("K")]
            public K K { get; set; }

            [JsonPropertyName("FE")]
            public FE FE { get; set; }

            [JsonPropertyName("ZN")]
            public ZN ZN { get; set; }

            [JsonPropertyName("P")]
            public P P { get; set; }

            [JsonPropertyName("VITA_RAE")]
            public VITARAE VITARAE { get; set; }

            [JsonPropertyName("VITC")]
            public VITC VITC { get; set; }

            [JsonPropertyName("THIA")]
            public THIA THIA { get; set; }

            [JsonPropertyName("RIBF")]
            public RIBF RIBF { get; set; }

            [JsonPropertyName("NIA")]
            public NIA NIA { get; set; }

            [JsonPropertyName("VITB6A")]
            public VITB6A VITB6A { get; set; }

            [JsonPropertyName("FOLDFE")]
            public FOLDFE FOLDFE { get; set; }

            [JsonPropertyName("VITB12")]
            public VITB12 VITB12 { get; set; }

            [JsonPropertyName("VITD")]
            public VITD VITD { get; set; }

            [JsonPropertyName("TOCPHA")]
            public TOCPHA TOCPHA { get; set; }

            [JsonPropertyName("VITK1")]
            public VITK1 VITK1 { get; set; }
        }
    }

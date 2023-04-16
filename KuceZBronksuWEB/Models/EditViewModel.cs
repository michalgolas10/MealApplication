using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using KuceZBronksuWEB.Models;

namespace KuceZBronksuWEB.Models
{
    public class EditViewModel 
    {

        public List<string>? MealType { get; set; }

        public List<string>? HealthLabels { get; set; }

        public List<string>? DietLabels { get; set; }

        public List<string>? Cautions { get; set; }

        public List<string>? CuisineType { get; set; }

    }
}

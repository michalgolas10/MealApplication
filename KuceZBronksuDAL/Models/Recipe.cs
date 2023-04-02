using KuceZBronksuDAL.Models;
using KuceZBronksuDAL.Models.BaseEntity;

namespace KuceZBronksuDAL
{
    public class Recipe : Entity
    {
        public string Label { get; set; }

        public string ShareAs { get; set; }

        public List<string> DietLabels { get; set; }

        public List<string> HealthLabels { get; set; }

        public List<string> Cautions { get; set; }

        public List<string> IngredientLines { get; set; }

        public List<string> RecipeSteps { get; set; }

        public double Calories { get; set; }

        public List<string> CuisineType { get; set; }

        public List<string> MealType { get; set; }
        public ICollection<User> Users { get; set; }
        public string? Image { get; set; }
    }
}
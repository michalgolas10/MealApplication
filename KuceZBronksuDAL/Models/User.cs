using KuceZBronksuDAL.Models.BaseEntity;

namespace KuceZBronksuDAL.Models
{
    public class User : Entity
    {
        public string Name { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
    }
}
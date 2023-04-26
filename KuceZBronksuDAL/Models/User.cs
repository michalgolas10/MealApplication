using KuceZBronksuDAL.Enums;
using KuceZBronksuDAL.Models.BaseEntity;

namespace KuceZBronksuDAL.Models
{
    public class User : Entity
    {
        public string? Name { get; set; }
        //public string Password { get; set; }
        //public string Email { get; set; }
        //public UserRole Role { get; set; }
        public ICollection<FavouritesRecipes> UsersFavouritesRecipies { get; set; }
    }
}
using KuceZBronksuDAL.Models.BaseEntity;
using Microsoft.EntityFrameworkCore.Infrastructure;
namespace KuceZBronksuDAL.Models
{
	public class User : Entity
	{
        private readonly ILazyLoader _lazyLoader;
        public User()
        {
            
        }
        public User(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }
        public string? Name { get; set; }

        //public string Password { get; set; }
        //public string Email { get; set; }
        //public UserRole Role { get; set; }
        private List<Recipe> _recipes;
        public List<Recipe> Recipes
        {
            get => _lazyLoader.Load(this, ref _recipes);
            set => _recipes = value;
        }
    }
}
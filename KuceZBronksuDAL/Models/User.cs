using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace KuceZBronksuDAL.Models
{
	public class User : IdentityUser<int>
	{
        private readonly ILazyLoader _lazyLoader;

        public User()
        {
        }

        public User(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

        private List<Recipe> _recipes;

        public List<Recipe> Recipes
        {
            get => _lazyLoader.Load(this, ref _recipes);
            set => _recipes = value;
        }
    }
}
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace KuceZBronksuDAL.Models
{
	public class User : IdentityUser<int>
	{
		public ICollection<Recipe>? Recipes;
	}
}
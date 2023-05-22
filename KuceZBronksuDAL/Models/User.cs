using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace KuceZBronksuDAL.Models
{
	public class User : IdentityUser<int>
	{
		public List<Recipe>? Recipes;
	}
}
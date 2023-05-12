using KuceZBronksuBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuceZBronksuBLL.Services.IServices
{
	public interface IUserService
	{
		public Task<bool> AddRecipeToFavourites(int idOfRecipe, int idOfUser);
		public Task<List<RecipeViewModel>> GetFavouritesRecipesOfUser(int iduser);
		public Task DeleteRecipeFromFavourites(int idOfRecipeToRemove, int iduser);
		public Task<List<UserViewModel>> ShowAllUsers();
	}
}

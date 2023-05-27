using KuceZBronksuBLL.Models;

namespace KuceZBronksuBLL.Services.IServices
{
	public interface IUserService
	{
		public Task<bool> AddRecipeToFavourites(int idOfRecipe, int idOfUser);

		public Task<IEnumerable<RecipeViewModel>> GetFavouritesRecipesOfUser(int iduser);

		public Task DeleteRecipeFromFavourites(int idOfRecipeToRemove, int iduser);

		public Task<IEnumerable<UserViewModel>> ShowAllUsers();
	}
}
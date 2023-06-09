using KuceZBronksuBLL.Models;

namespace KuceZBronksuBLL.Services.IServices
{
	public interface IPostReportService
	{
		Task ReportRecipeVisitAsync(RecipeViewModel visitedRecipe);

		Task ReportUserLoginAsync(int userId);

		Task<int> GetUserIdAsync(string email);

		Task ReportAddedToFavouriteAsync(RecipeViewModel favouriteRecipe, int userId);
		Task ReportRemoveFromFavouriteAsync(RecipeViewModel favouriteRecipe, int userId);
    }
}
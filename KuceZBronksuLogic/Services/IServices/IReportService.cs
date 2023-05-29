using KuceZBronksuAPIBLL.Models;
using KuceZBronksuBLL.Models;

namespace KuceZBronksuBLL.Services.IServices
{
	public interface IReportService
	{
		Task ReportRecipeVisitAsync(RecipeViewModel visitedRecipe);

		Task ReportUserLoginAsync(int userId);

		Task<int> GetUserIdAsync(string email);

		Task ReportAddedToFavouriteAsync(RecipeViewModel favouriteRecipe, int userId);
		Task CreateVisitedRecipeReportAsync(IEnumerable<VisitedRecipesDTO>? visitedRecipesDTOs);
        Task<List<VisitedRecipeDTO>> GetAll();
    }
}
using KuceZBronksuBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuceZBronksuBLL.Services.IServices
{
	public interface IReportService
	{
		Task ReportRecipeVisitAsync(RecipeViewModel visitedRecipe, string userId);
		Task ReportUserLoginAsync(int userId);
		Task<int> GetUserIdAsync(string email);
		Task ReportAddedToFavouriteAsync(RecipeViewModel favouriteRecipe, int userId)
	}
}

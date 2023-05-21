using KuceZBronksuWebApi.DAL.Database;

namespace KuceZBronksuWebApi.BLL.Services.IServices
{
	public interface IRecipeAnalysisService
	{
		public Task<RecipeAnalysis> GetAll();

		public Task<RecipeAnalysis> GetRecipeFavs();

		public Task<RecipeAnalysis> UpdateFav();
		public Task<RecipeAnalysis> UpdateViews();
	}
}

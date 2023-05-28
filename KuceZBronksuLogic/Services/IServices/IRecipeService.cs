using KuceZBronksuBLL.Models;

namespace KuceZBronksuBLL.Services.IServices
{
	public interface IRecipeService
	{
		public Task<RecipeViewModel> GetRecipe(int Id);

		public Task<IEnumerable<RecipeViewModel>> GetAllRecipies();

		public Task<IEnumerable<RecipeViewModel>> Search(SearchViewModel model);

		public void AddRecipeFromCreateView(EditAndCreateViewModel pageModel);

		public Task<EditAndCreateViewModel> CreateEditViewModelForEdit(int id);

		public Task UpdateEditedRecipe(EditAndCreateViewModel editAndCreateViewModel);

		public Task<IEnumerable<RecipeViewModel>> GetThreeMostViewedRecipes();

		public void DeleteRecipe(int id);

		public Task<IEnumerable<RecipeViewModel>> RecipeWaitingToBeAdd();

		public Task ChangeApprovedOfRecipe(int id);
	}
}
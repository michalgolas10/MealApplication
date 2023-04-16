using KuceZBronksuDAL;
using KuceZBronksuWEB.Models;

namespace KuceZBronksuWEB.Interfaces
{
    public interface ISearch<T>
    {
        Task<List<T>> Search(SearchViewModel model);

        Task<List<T>> GetAll();

        Task<RecipeViewModel> GetByName(string name);
        Task<Recipe> GetByNameRecipe(string name);
        Task<List<Recipe>> GetRecipesOfUser(string userId);

        Task<RecipeViewModel> GetById(string id);
        Task<EditViewModel> CreateEditViewModel();
        Task<EditViewModel> GetEditViewModel(RecipeViewModel model);

    }
}
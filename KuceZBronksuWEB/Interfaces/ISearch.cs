using KuceZBronksuWEB.Models;

namespace KuceZBronksuWEB.Interfaces
{
    public interface ISearch<T>
    {
        Task<List<T>> Search(SearchViewModel model);

        Task<List<T>> GetAll();

        Task<RecipeViewModel> GetByName(string name);
    }
}
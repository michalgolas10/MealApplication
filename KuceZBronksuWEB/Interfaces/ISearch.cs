using KuceZBronksuWEB.Models;

namespace KuceZBronksuWEB.Interfaces
{
    public interface ISearch<T>
    {
        List<T> Search(SearchViewModel model);

        List<T> GetAll();

        RecipeViewModel GetByName(string name);
    }
}
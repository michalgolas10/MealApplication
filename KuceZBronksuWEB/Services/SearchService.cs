using KuceZBronksuDAL;
using KuceZBronksuWEB.Interfaces;
using KuceZBronksuWEB.Models;
using KuceZBronksuBLL.Services.IService;

namespace KuceZBronksuWEB.Services
{
    public class SearchService : ISearch<RecipeViewModel>
    {
        readonly private IService<Recipe> _recipeService;
        public SearchService(IService<Recipe> recipeService)
        {
            _recipeService= recipeService;
        }
        public List<RecipeViewModel> Search(SearchViewModel model)
        {
            List<RecipeViewModel> result = new List<RecipeViewModel>();
            var recipies = _recipeService.GetAll();
            if (model.IngrediendsList != null)
            {
                List<string> ingrediends = model.IngrediendsList.Split(',').ToList();
                recipies = KuceZBronksuLogic.Search.SearchByIngredients(ingrediends, recipies);
            }
            if (model.MealType != null)
            {
                recipies = KuceZBronksuLogic.Search.SearchByMealType(model.MealType.Split(',').ToList(), recipies);
            }
            if (model.KcalAmount != null)
            {
                recipies = KuceZBronksuLogic.Search.SearchByKcal(model.KcalAmount.Value, 300d, recipies);
            }
            foreach (var recipe in recipies)
            {
                //result.Add(new RecipeViewModel().FillModel(recipe));
            }

            return result;
        }

        public List<RecipeViewModel> GetAll()
        {
            List<RecipeViewModel> result = new List<RecipeViewModel>();
            var recipies = TempDb.Recipes;

            foreach (var recipe in recipies)
            {
                //result.Add(new RecipeViewModel().FillModel(recipe));
            }
            return result;
        }

        public RecipeViewModel GetByName(string name)
        {
            var recipe = TempDb.Recipes.FirstOrDefault(x => x.Label == name);
            //var result = new RecipeViewModel().FillModel(recipe);

            return null ;
        }
    }
}
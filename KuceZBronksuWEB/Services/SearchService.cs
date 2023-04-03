using KuceZBronksuDAL;
using KuceZBronksuWEB.Interfaces;
using KuceZBronksuWEB.Models;
using KuceZBronksuBLL.Services.IService;
using AutoMapper;

namespace KuceZBronksuWEB.Services
{
    public class SearchService : ISearch<RecipeViewModel>
    {
        readonly private IService<Recipe> _recipeService;
        readonly private IMapper _mapper;  
        public SearchService(IService<Recipe> recipeService,IMapper mapper)
        {
            _mapper = mapper;
            _recipeService= recipeService;
        }
        public async Task<List<RecipeViewModel>> Search(SearchViewModel model)
        {
            var recipies = await _recipeService.GetAll();
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
            var result = recipies.Select(e => _mapper.Map<RecipeViewModel>(e)).ToList();
            return result;
        }

        public async Task<List<RecipeViewModel>> GetAll()
        {
            List<RecipeViewModel> result = new List<RecipeViewModel>();
            var recipies = await _recipeService.GetAll();
            var productsViews = recipies.Select(e => _mapper.Map<RecipeViewModel>(e)).ToList();
            return result;
        }

        public async Task<RecipeViewModel> GetByName(string name)
        {
            var recipies = await _recipeService.GetAll();
            var recipe = recipies.FirstOrDefault(x => x.Label == name);
            var result = _mapper.Map<RecipeViewModel>(recipe);
            return result ;
        }
    }
}
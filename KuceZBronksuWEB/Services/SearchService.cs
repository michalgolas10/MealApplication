using KuceZBronksuDAL;
using KuceZBronksuWEB.Interfaces;
using KuceZBronksuWEB.Models;
using KuceZBronksuBLL.Services.IService;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

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
            if (model.ListOfMealType != null)
            {
                recipies = KuceZBronksuLogic.Search.SearchByMealType(model.ListOfMealType, recipies);
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

        public async Task<RecipeViewModel> GetById(string id)
        {
            var recipies = await _recipeService.GetAll();
            var recipe = recipies.FirstOrDefault(x => x.Id == id);
            var result = _mapper.Map<RecipeViewModel>(recipe);
            return result;
        }

        public async Task<Recipe> GetByNameRecipe(string name)
		{
			var recipies = await _recipeService.GetAll();
			return recipies.FirstOrDefault(x => x.Label == name);
		}
		public async Task<List<Recipe>> GetRecipesOfUser(string userId)
		{
			var recipies = await _recipeService.GetAll();
            var userFavouritesRecipes = recipies.Where(x => x.Users.Where(x=>x.Id== userId).Any()).ToList();
            return userFavouritesRecipes;
		}

        public async Task<EditViewModel> CreateEditViewModel()
        {
            var allRecipes = await _recipeService.GetAll();
            EditViewModel editViewModel= new EditViewModel();
            foreach(var recipe in allRecipes)
            {
               foreach(var healthLabel in recipe.HealthLabels)
               {
                    editViewModel.HealthLabels.Add(healthLabel);
               }

               foreach(var mealType in recipe.MealType)
                {
                    editViewModel.MealType.Add(mealType);
                }

               foreach(var dietLabel in recipe.DietLabels)
                {
                    editViewModel.DietLabels.Add(dietLabel);
                }

               foreach(var caution in recipe.Cautions)
                {
                    editViewModel.Cautions.Add(caution);
                }

               foreach(var cuisineType in recipe.CuisineType)
                {
                    editViewModel.CuisineType.Add(cuisineType);
                }

                editViewModel.MealType.Distinct();
                editViewModel.DietLabels.Distinct();
                editViewModel.Cautions.Distinct();
                editViewModel.HealthLabels.Distinct();
                editViewModel.CuisineType.Distinct();
                }
            return editViewModel;
        }
	}
}
using AutoMapper;
using KuceZBronksuDAL;
using KuceZBronksuDAL.Repository.IRepository;
using KuceZBronksuWEB.Models;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.ComponentModel;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace KuceZBronksuBLL.Services
{
    public class RecipeService
    {
        private readonly IRepository<Recipe> _repository;

        readonly private IMapper _mapper;
        public RecipeService(IRepository<Recipe> repository, IMapper mapper)
        {
            this._repository = repository;
            _mapper = mapper;
        }
        public async Task<RecipeViewModel> GetRecipe(string Id)
        {
            return _mapper.Map<RecipeViewModel>(await _repository.Get(DescriptString(Id)));
        }
		public async Task<List<RecipeViewModel>> GetAllRecipies()
        {
            var recipes = await _repository.GetAll(x => x.Users);
            var result = recipes.Select(e => _mapper.Map<RecipeViewModel>(e)).ToList();
            return result;
        }
        public async Task<SearchViewModel> CreateSearchModelWithMealTypes()
        {
            return new SearchViewModel()
            {
                ListOfMealType = new List<string>()
                {
                    "breakfast",
                    "lunch/dinner",
                    "teatime"
                }
            };
        }
        public async Task<List<RecipeViewModel>> Search(SearchViewModel model)
        {
            var recipies = await _repository.GetAll(x => x.Users);
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
        public EditAndCreateViewModel GetUniqueValuesOfRecipeLists(List<Recipe> allRecipes)
        {
            var uniqueMealTypes = new List<string>()
                {
                    "breakfast",
                    "dinner/lunch",
                    "teatime"
                };
            var uniqueHealthLabels = new List<string>();
            var uniqueDietLabels = new List<string>();
            var uniqueCautions = new List<string>();
            var uniqueCuisinTypes = new List<string>();
            foreach (var recipe in allRecipes)
            {
                foreach (var healthLabels in recipe.HealthLabels)
                {
                    if (!uniqueHealthLabels.Contains(healthLabels))
                        uniqueHealthLabels.Add(healthLabels);
                }
                foreach (var dietLabels in recipe.DietLabels)
                {
                    if (!uniqueDietLabels.Contains(dietLabels))
                        uniqueDietLabels.Add(dietLabels);
                }
                foreach (var caution in recipe.Cautions)
                {
                    if (!uniqueCautions.Contains(caution))
                        uniqueCautions.Add(caution);
                }
                foreach (var cuisinType in recipe.CuisineType)
                {
                    if (!uniqueCuisinTypes.Contains(cuisinType))
                        uniqueCuisinTypes.Add(cuisinType);
                }
            }
            return new EditAndCreateViewModel()
            {
                MealType = uniqueMealTypes,
                HealthLabels = uniqueHealthLabels,
                DietLabels = uniqueDietLabels,
                Cautions = uniqueCautions,
                CuisineType = uniqueCuisinTypes
            };

        }
        public async Task<EditAndCreateViewModel> CreateModelForEditAndCreate()
        {
            var allRecipes = await _repository.GetAll();
            return GetUniqueValuesOfRecipeLists(allRecipes);
        }
        public void AddRecipeFromCreateView(EditAndCreateViewModel pageModel)
        {
            _repository.Insert(_mapper.Map<Recipe>(pageModel));
        }
        public async Task<EditAndCreateViewModel> CreateEditViewModelForEdit(string id)
        {
            return _mapper.Map<EditAndCreateViewModel>(await GetRecipe(id));
        }
        public async Task UpdateEditedRecipe(EditAndCreateViewModel editAndCreateViewModel)
        {
            _repository.Update(_mapper.Map<Recipe>(editAndCreateViewModel));
        }
        //This method will throw 3 most Viewed recipe last days for now just rndm 3 recipes;
        public async Task<List<RecipeViewModel>> GetThreeMostViewedRecipes()
        {
            var listOfRecipes = await GetAllRecipies();
            Random rand = new Random();
            List<RecipeViewModel> rndmRecipes = new()
            {
                listOfRecipes[rand.Next(0,listOfRecipes.Count)],
                listOfRecipes[rand.Next(0,listOfRecipes.Count)],
                listOfRecipes[rand.Next(0,listOfRecipes.Count)]
            };
            return rndmRecipes;
        }
        public async Task DeleteRecipe(string id)
        {
            _repository.Delete(_mapper.Map<Recipe>(await GetRecipe(id)));
        }
		private static string DescriptString(string input)
		{
            return input;
		}
	}
}
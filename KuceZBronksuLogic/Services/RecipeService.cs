using AutoMapper;
using KuceZBronksuDAL;
using KuceZBronksuDAL.Repository.IRepository;
using KuceZBronksuWEB.Models;

namespace KuceZBronksuBLL.Services
{
	public class RecipeService
	{
		private readonly IRepository<Recipe> _repository;

		private readonly IMapper _mapper;

		public RecipeService(IRepository<Recipe> repository, IMapper mapper)
		{
			this._repository = repository;
			_mapper = mapper;
		}

		public async Task<RecipeViewModel> GetRecipe(string Id)
		{
			return _mapper.Map<RecipeViewModel>(await _repository.Get(Id));
		}

		public async Task<List<RecipeViewModel>> GetAllRecipies()
		{
			var recipes = await _repository.GetAll(x=>x.User);
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
			var recipies = await _repository.GetAll(x => x.User);
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
			var uniqueMealTypes = new List<string>();
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
				foreach (var mealType in recipe.MealType)
				{
					if (!uniqueMealTypes.Contains(mealType))
						uniqueMealTypes.Add(mealType);
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

		public async Task<string> GenerateNewId()
		{
			return Guid.NewGuid().ToString();
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
			_repository.Delete(id);
		}
	}
}
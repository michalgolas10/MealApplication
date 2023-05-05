using AutoMapper;
using KuceZBronksuDAL.Repository.IRepository;
using System.Reflection;
using System;
using Azure;
using Microsoft.SqlServer.Server;
using System.Security.Cryptography;
using System.Security.Policy;
using KuceZBronksuBLL.Models;
using KuceZBronksuDAL.Models;

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

		public async Task<RecipeViewModel> GetRecipe(int Id)
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
				recipies = KuceZBronksuBLL.Search.SearchByIngredients(ingrediends, recipies);
			}
			if (model.ListOfMealType != null)
			{
				recipies = KuceZBronksuBLL.Search.SearchByMealType(model.ListOfMealType, recipies);
			}
			if (model.KcalAmount != null)
			{
				recipies = KuceZBronksuBLL.Search.SearchByKcal(model.KcalAmount.Value, 300d, recipies);
			}
			var result = recipies.Select(e => _mapper.Map<RecipeViewModel>(e)).ToList();
			return result;
		}

		public EditAndCreateViewModel GetUniqueValuesOfRecipeLists()
		{
			return new EditAndCreateViewModel()
			{
				MealType = new List<string>()
				{
					"breakfast",
					"lunch/dinner",
					"teatime"
				},
				HealthLabels = new List<string>()
				{
					"Vegan",
					"Vegetarian",
					"Pescatarian",
					"Dairy-Free",
					"Gluten-Free",
					"Wheat-Free",
					"Egg-Free",
					"Peanut-Free",
					"Tree-Nut-Free",
					"Soy-Free",
					"Fish-Free",
					"Shellfish-Free",
					"Pork-Free",
					"Red-Meat-Free",
					"Crustacean-Free",
					"Celery-Free",
					"Mustard-Free",
					"Sesame-Free",
					"Lupine-Free",
					"Mollusk-Free",
					"Alcohol-Free",
					"No oil Added",
					"Kosher",
					"FODMAP-Free",
					"Mediterranean",
					"Sulfite-Free",
					"Immuno-Supportive",
					"Low Potassium",
					"Kidney-Friendly",
					"Sugar-Conscious",
					"Keto-Friendly",
					"Paleo",
					"DASH",
				},
				DietLabels = new List<string>() 
				{
					"Low-Fat",
					"Low-Sodium",
					"Balanced",
					"Low-Carb",
					"High-Fiber"
				},
				Cautions = new List<string>()
				{
					"Sulfites",
					"FODMAP",
					"Gluten",
					"Wheat",
					"Soy",
					"Tree-Nuts",
				},
				CuisineType = new List<string>()
				{
					"american",
					"indian",
					"british",
					"mediterranean",
					"french",
					"nordic",
					"mexican",
					"italian"
				}
			};
		}

		public void AddRecipeFromCreateView(EditAndCreateViewModel pageModel)
		{
			_repository.Insert(_mapper.Map<Recipe>(pageModel));
		}

		public async Task<EditAndCreateViewModel> CreateEditViewModelForEdit(int id)
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

		public async Task DeleteRecipe(int id)
		{
			_repository.Delete(id);
		}
	}
}
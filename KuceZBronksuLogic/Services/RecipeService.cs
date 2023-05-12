using AutoMapper;
using KuceZBronksuBLL.Models;
using KuceZBronksuBLL.Services.IServices;
using KuceZBronksuDAL.Models;
using KuceZBronksuDAL.Repository.IRepository;
using System;
using System.Text.RegularExpressions;
using System.Xml;

namespace KuceZBronksuBLL.Services
{
	public class RecipeService : IRecipeService
	{
		private readonly IRepository<Recipe> _repository;

		private readonly IMapper _mapper;

		public RecipeService(IRepository<Recipe> repository, IMapper mapper)
		{
			this._repository = repository ?? throw new NullReferenceException("Database cant be null");
			_mapper = mapper;
		}

		public async Task<RecipeViewModel> GetRecipe(int Id)
		{
			return (_mapper.Map<RecipeViewModel>(await (_repository.Get(Id))));
		}

		public async Task<List<RecipeViewModel>> GetAllRecipies()
		{
			var recipes = await _repository.GetAll();
			var result = recipes.Select(e => _mapper.Map<RecipeViewModel>(e)).ToList();
			return result.Where(x => x.Approved == true).ToList();
		}

		public SearchViewModel CreateSearchModelWithMealTypes()
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
			model.ListOfMealType = model.ListOfEmptyMealType;
			var recipies = await _repository.GetAll();
			var result = new List<Recipe>();
			if (model.IngrediendsList != null)
			{
				var matches = new List<Recipe>();
				var ingredients = model.IngrediendsList.Split(',').ToList();
				foreach (var ingredient in ingredients)
				{
					matches = recipies.Where(x => x.IngredientLines.Any(r => r.Contains(ingredient))).ToList();
				}
				result.AddRange(matches);
			}
			if (model.ListOfMealType != null)
			{
				var matches = new List<Recipe>();
				foreach (var mealtype in model.ListOfMealType)
				{
					matches = recipies.Where(x => x.MealType.Any(r => r.Contains(mealtype))).ToList();
				}
				result.AddRange(matches);
			}
			if (model.KcalAmount != null)
			{
				var matches = recipies.Where(x => x.Calories < model.KcalAmount + 150 && x.Calories > model.KcalAmount - 150).ToList();
				result.AddRange(matches);
			}
			return result.Select(e => _mapper.Map<RecipeViewModel>(e)).ToList();
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

		public void UpdateEditedRecipe(EditAndCreateViewModel editAndCreateViewModel)
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

		public void DeleteRecipe(int id)
		{
			_repository.Delete(id);
		}

		public async Task<List<RecipeViewModel>> RecipeWaitingToBeAdd()
		{
			var result = (await _repository.GetAll()).Where(x => x.Approved == false);
			var recipeViewModelToBePassed = result.ToList();
			return recipeViewModelToBePassed.Select(e => _mapper.Map<RecipeViewModel>(e)).ToList();
		}

		public async Task ChangeApprovedOfRecipe(int id)
		{
			var recipeToChangeApprove = await _repository.Get(id);
			recipeToChangeApprove.Approved = true;
			_repository.Update(recipeToChangeApprove);
		}
	}
}
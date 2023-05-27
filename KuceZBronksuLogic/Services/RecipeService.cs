using AutoMapper;
using KuceZBronksuBLL.Models;
using KuceZBronksuBLL.Services.IServices;
using KuceZBronksuDAL.Models;
using KuceZBronksuDAL.Repository.IRepository;
using Microsoft.Extensions.Logging;

namespace KuceZBronksuBLL.Services
{
	public class RecipeService : IRecipeService
	{
		private readonly IRepository<Recipe> _repository;

		private readonly IMapper _mapper;

		private readonly ILogger<IRecipeService> _logger;

		public RecipeService(IRepository<Recipe> repository, IMapper mapper, ILogger<IRecipeService> logger)
		{
			_logger = logger;
			this._repository = repository;
			_mapper = mapper;
		}

		public async Task<RecipeViewModel> GetRecipe(int Id)
		{
			try
			{
				var result = await (_repository.Get(Id));
				return (_mapper.Map<RecipeViewModel>(result));
			}
			catch (NullReferenceException)
			{
				_logger.LogError($"Problem with download recipe of Id:{Id}");
				throw new NullReferenceException($"Problem with download recipe of Id:{Id}");
			}
		}

		public async Task<IEnumerable<RecipeViewModel>> GetAllRecipies()
		{
			try
			{
				var recipes = await _repository.GetAll();
				var result = recipes.Select(e => _mapper.Map<RecipeViewModel>(e));
				return result.Where(x => x.Approved == true).ToList();
			}
			catch (NullReferenceException)
			{
				_logger.LogError("recipes get from DB are null");
				throw new NullReferenceException("recipes get from DB are null");
			}
		}

		public async Task<IEnumerable<RecipeViewModel>> Search(SearchViewModel model)
		{
			model.ListOfMealType = model.ListOfEmptyMealType;
			try
			{
				var recipes = await _repository.GetAll();
				if (model.IngrediendsList != null)
				{
					var ingredients = model.IngrediendsList.Split(',');
					foreach (var ingredient in ingredients)
					{
						recipes = recipes.Where(x => x.IngredientLines.Any(r => r.Contains(ingredient)));
					}
				}
				if (model.ListOfMealType != null)
				{
					var matches = new List<Recipe>();
					foreach (var mealtype in model.ListOfMealType)
					{
						recipes = recipes.Where(x => x.MealType.Any(r => r.Contains(mealtype)));
					}
				}
				if (model.KcalAmount != null)
				{
					recipes = recipes.Where(x => x.Calories < model.KcalAmount + 150 && x.Calories > model.KcalAmount - 150);
				}
				return recipes.Select(e => _mapper.Map<RecipeViewModel>(e)).ToList();
			}
			catch (NullReferenceException)
			{
				_logger.LogError("recipes get from DB are null");
				throw new NullReferenceException("Recipes from db are null");
			}
		}

		public void AddRecipeFromCreateView(EditAndCreateViewModel pageModel)
		{
			_logger.LogInformation("Adding Recipe To DB");
			_repository.Insert(_mapper.Map<Recipe>(pageModel));
		}

		public async Task<EditAndCreateViewModel> CreateEditViewModelForEdit(int id)
		{
			try
			{
				var recipePassedToView = await GetRecipe(id);
				return _mapper.Map<EditAndCreateViewModel>(recipePassedToView);
			}
			catch (NullReferenceException)
			{
				_logger.LogError("Couldnt load recipe from DB");
				throw new NullReferenceException("Couldnt load recipe from DB");
			}
		}

		public void UpdateEditedRecipe(EditAndCreateViewModel editAndCreateViewModel)
		{
			_logger.LogInformation("Updating Recipe From DB");
			_repository.Update(_mapper.Map<Recipe>(editAndCreateViewModel));
		}

		//This method will throw 3 most Viewed recipe last days for now just rndm 3 recipes;
		public async Task<IEnumerable<RecipeViewModel>> GetThreeMostViewedRecipes()
		{
			var listOfRecipes = await GetAllRecipies();
			listOfRecipes = listOfRecipes.Take(3).ToList();
			return listOfRecipes;
		}

		public void DeleteRecipe(int id)
		{
			_logger.LogInformation("Deleting Recipe From DB");
			_repository.Delete(id);
		}

		public async Task<IEnumerable<RecipeViewModel>> RecipeWaitingToBeAdd()
		{
			try
			{
				var recipeWaitingToBeAdd = (await _repository.GetAll()).Where(x => x.Approved == false);
				var result = (recipeWaitingToBeAdd);
				var recipeViewModelToBePassed = result;
				return recipeViewModelToBePassed.Select(e => _mapper.Map<RecipeViewModel>(e));
			}
			catch (NullReferenceException)
			{
				_logger.LogError("Problem with load unaccepted recipes");
				throw new NullReferenceException("Problem with load unaccepted recipes");
			}
		}

		public async Task ChangeApprovedOfRecipe(int id)
		{
			try
			{
				var recipeToChangeApprove = await _repository.Get(id);
				recipeToChangeApprove.Approved = true;
				_repository.Update(recipeToChangeApprove);
			}
			catch (NullReferenceException)
			{
				_logger.LogError($"Recipe of ID :{id} couldnt be loaded");
				throw new NullReferenceException($"Recipe of ID :{id} couldnt be loaded");
			}
		}
	}
}
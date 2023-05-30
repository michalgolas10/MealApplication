using AutoMapper;
using KuceZBronksuBLL.Models;
using KuceZBronksuBLL.Services.IServices;
using KuceZBronksuDAL.Models;
using KuceZBronksuDAL.Repository.IRepository;
using Microsoft.Extensions.Logging;
using MimeKit.Cryptography;
using System.Collections;

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

		public async Task UpdateEditedRecipe(EditAndCreateViewModel editAndCreateViewModel)
		{
			_logger.LogInformation("Updating Recipe From DB");
			var editedRecipe = _mapper.Map<Recipe>(editAndCreateViewModel);
			var recipeDO = await _repository.Get(editedRecipe.Id.Value);
			editedRecipe.Approved = false;
			_repository.Update(editedRecipe);
			recipeDO.Approved = true;
			recipeDO.Id = null;
			_repository.Insert(recipeDO);
		}

		//This method will throw 3 most Viewed recipe last days for now just rndm 3 recipes;
		public async Task<IEnumerable<RecipeViewModel>> GetThreeMostViewedRecipes(IEnumerable<VisitedRecipesDTO> listofViewedRecipes)
		{
			var listOfViewedRecipes = listofViewedRecipes.ToList();
            Dictionary<VisitedRecipesDTO,int> occurrences = new Dictionary<VisitedRecipesDTO,int>();
			foreach(var recipe in listOfViewedRecipes)
			{
				var counter = listofViewedRecipes.Count(x => x.RecipeId == recipe.RecipeId);
				occurrences.Add(recipe, counter);
			}
            List<KeyValuePair<VisitedRecipesDTO, int>> sortedList = occurrences.ToList();
            sortedList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair1.Value));
			var threeMostViewedRecipes = sortedList.Take(3).ToList();
			return new List<RecipeViewModel>
			{
				_mapper.Map<RecipeViewModel>(await _repository.Get(threeMostViewedRecipes[0].Key.RecipeId)),
                _mapper.Map<RecipeViewModel>(await _repository.Get(threeMostViewedRecipes[1].Key.RecipeId)),
                _mapper.Map<RecipeViewModel>(await _repository.Get(threeMostViewedRecipes[2].Key.RecipeId))
            };
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
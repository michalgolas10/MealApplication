using AutoMapper;
using KuceZBronksuBLL.Models;
using KuceZBronksuBLL.Services.IServices;
using KuceZBronksuDAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace KuceZBronksuBLL.Services
{
	public class UserService : IUserService
	{
		private readonly IRecipeService _recipeService;
		private readonly IMapper _mapper;
		private readonly UserManager<User> _userManager;
		private readonly ILogger<UserService> _logger;
		private readonly IReportService _reportService;

		public UserService(IReportService reportService, UserManager<User> userManager, IRecipeService recipeService, IMapper mapper, ILogger<UserService> logger)
		{
			_reportService = reportService;
			_mapper = mapper;
			_userManager = userManager;
			_recipeService = recipeService;
			_logger = logger;
		}

		public async Task<bool> AddRecipeToFavourites(int idOfRecipe, int idOfUser)
		{
			var recipeThatIsAddedToFavourite = await _recipeService.GetRecipe(idOfRecipe);
			var resultRecipe = _mapper.Map<Recipe>(recipeThatIsAddedToFavourite);
			try
			{
				var user = await _userManager.FindByIdAsync(idOfUser.ToString());
				if (user.Recipes == null)
				{
					var UsersRecipes = new List<Recipe>();
					user.Recipes = UsersRecipes;
				}
				if (user.Recipes.Contains(resultRecipe))
				{
					return false;
				}
				user.Recipes.Add(resultRecipe);
				await _userManager.UpdateAsync(user);
				return true;
			}
			catch (NullReferenceException)
			{
				_logger.LogError($"User of Id:{idOfUser} Couldnt be loaded");
				throw new NullReferenceException($"User of Id:{idOfUser} Couldnt be loaded");
			}
		}

		public async Task<bool> ItsRecipeInUsersFavourite(int userId, int recipeId)
		{
			var user = await _userManager.FindByIdAsync(userId.ToString());
			var recipe = await _recipeService.GetRecipe(recipeId);
			return user.Recipes.Contains(_mapper.Map<Recipe>(recipe));
		}

		public async Task<IEnumerable<RecipeViewModel>> GetFavouritesRecipesOfUser(int idOfUser)
		{
			try
			{
				var user = await _userManager.FindByIdAsync(idOfUser.ToString());
				if (user.Recipes != null)
				{
					var ListOfRecipiesToBePassedToView = user.Recipes;
					return ListOfRecipiesToBePassedToView.Select(e => _mapper.Map<RecipeViewModel>(e));
				}
				return new List<RecipeViewModel>();
			}
			catch (NullReferenceException)
			{
				_logger.LogError($"User of Id:{idOfUser} Couldnt be loaded");
				throw new NullReferenceException($"User of Id:{idOfUser} Couldnt be loaded");
			}
		}

		public async Task DeleteRecipeFromFavourites(int idOfRecipeToRemove, int idOfUser)
		{
			try
			{
				var user = await _userManager.FindByIdAsync(idOfUser.ToString());
				user.Recipes = user.Recipes.Where(x => x.Id != idOfRecipeToRemove).ToList();
				await _userManager.UpdateAsync(user);
			}
			catch (NullReferenceException)
			{
				_logger.LogError($"User of Id:{idOfUser} Couldnt be loaded");
				throw new NullReferenceException($"User of Id:{idOfUser} Couldnt be loaded");
			}
		}

		public async Task<IEnumerable<UserViewModel>> ShowAllUsers()
		{
			try
			{
				var allUsers = await _userManager.GetUsersInRoleAsync("NormalUser");
				var adminUsers = await _userManager.GetUsersInRoleAsync("Admin");
				foreach (var adminUser in adminUsers)
				{
					allUsers.Add(adminUser);
				}
				var UserViewModelsToPass = allUsers.Select(e => _mapper.Map<UserViewModel>(e)).ToList();
				foreach (var userViewModel in UserViewModelsToPass)
				{
					var roleOfUser = (await _userManager.GetRolesAsync(await _userManager.FindByEmailAsync(userViewModel.Email))).ToList();

					userViewModel.Roles = roleOfUser;
				}
				return UserViewModelsToPass.ToList();
			}
			catch (NullReferenceException)
			{
				_logger.LogError("Users NormalUser / Admin couldnt be loaded from DB");
				throw new NullReferenceException("Users NormalUser / Admin couldnt be loaded from DB");
			}
		}
		public async Task ListOfRecipesWithFavButton(List<RecipeViewModel> listOfRecipes, ClaimsPrincipal principal)
		{
			var user = await _userManager.GetUserAsync(principal);
			var userRecipes = user.Recipes;
			var userRecipesMapped = userRecipes.Select(e => _mapper.Map<RecipeViewModel>(e));
			var result = new List<RecipeViewModel>();
			foreach (var recipe in listOfRecipes)
			{
				foreach (var recipeofUser in userRecipesMapped)
				{
					if (recipeofUser.Id == recipe.Id)
					{
						recipe.IsFavourite = true;
					}
				}
			}
		}
	}
}
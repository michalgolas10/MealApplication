using AutoMapper;
using KuceZBronksuBLL.Models;
using KuceZBronksuBLL.Services.IServices;
using KuceZBronksuDAL.Models;
using KuceZBronksuDAL.Repository;
using KuceZBronksuDAL.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using static Azure.Core.HttpHeader;

namespace KuceZBronksuBLL.Services
{
	public class UserService : IUserService
	{
		private readonly IRecipeService _recipeService;
		private readonly IMapper _mapper;
		private readonly UserManager<User> _userManager;

		public UserService(UserManager<User> userManager, IRecipeService recipeService, IMapper mapper)
        {
            _mapper = mapper;
			_userManager = userManager ?? throw new NullReferenceException("DatabaseIdentityUser cant be null");
            _recipeService = recipeService ?? throw new NullReferenceException("RecipeService cant be null");
        }
		public async Task<bool> AddRecipeToFavourites(int idOfRecipe, int idOfUser)
		{
			var recipeThatIsAddedToFavourite = await _recipeService.GetRecipe(idOfRecipe);
			var resultRecipe = _mapper.Map<Recipe>(recipeThatIsAddedToFavourite);
			try
			{
				var user = await _userManager.FindByIdAsync(idOfUser.ToString());
				if (user.Recipes.Contains(resultRecipe))
				{
					return false;
				}
				user.Recipes.Add(resultRecipe);
				await _userManager.UpdateAsync(user);
				return true;
			}
			catch(NullReferenceException)
			{
				throw new NullReferenceException($"User of Id:{idOfUser} Couldnt be loaded");
			}
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
				var UserViewModelsToPass = allUsers.Select(e => _mapper.Map<UserViewModel>(e));
				foreach (var userViewModel in UserViewModelsToPass)
				{
					userViewModel.Roles = (await _userManager.GetRolesAsync(await _userManager.FindByEmailAsync(userViewModel.Email))).ToList();
				}
				return UserViewModelsToPass;
			}
			catch(NullReferenceException)
			{
				throw new NullReferenceException("Users NormalUser / Admin couldnt be loaded from DB");
			}
		}
	}
}

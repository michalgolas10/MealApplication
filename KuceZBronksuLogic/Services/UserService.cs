using AutoMapper;
using KuceZBronksuBLL.Models;
using KuceZBronksuDAL.Models;
using KuceZBronksuDAL.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using static Azure.Core.HttpHeader;

namespace KuceZBronksuBLL.Services
{
    public class UserService
	{
		private readonly RecipeService _recipeService;
		private readonly IMapper _mapper;
		private readonly UserManager<User> _userManager;

		public UserService(UserManager<User> userManager, RecipeService recipeService, IMapper mapper)
		{
			_mapper = mapper;
			_userManager = userManager;
			_recipeService = recipeService;
		}
		public async Task<bool> AddRecipeToFavourites(int idOfRecipe, int idOfUser)
		{
            var resultRecipe = _mapper.Map<Recipe>(await _recipeService.GetRecipe(idOfRecipe));
			var user = await _userManager.FindByIdAsync(idOfUser.ToString());
			if(user.Recipes.Contains(resultRecipe))
			{
				return false;
			}
			user.Recipes.Add(resultRecipe);
			await _userManager.UpdateAsync(user);
			return true;
		}

		public async Task<List<RecipeViewModel>> GetFavouritesRecipesOfUser(int iduser)
		{
			var user = await _userManager.FindByIdAsync(iduser.ToString());
			var ListOfRecipiesToBePassedToView = user.Recipes;
			return ListOfRecipiesToBePassedToView.Select(e => _mapper.Map<RecipeViewModel>(e)).ToList();
        }


        public async Task DeleteRecipeFromFavourites(int idOfRecipeToRemove, int iduser)         
		{
            //Usuwamy na razie recepture jedynego użytkownika jakiego mamy czyli admina!
            var user = await _userManager.FindByIdAsync(iduser.ToString());
            user.Recipes = user.Recipes.Where(x => x.Id != idOfRecipeToRemove).ToList();
			await _userManager.UpdateAsync(user);
		}
    }
}
﻿using AutoMapper;
using KuceZBronksuBLL.Models;
using KuceZBronksuDAL.Models;
using KuceZBronksuDAL.Repository.IRepository;

namespace KuceZBronksuBLL.Services
{
    public class UserService
	{
		private readonly IRepository<User> _repository;
		private readonly RecipeService _recipeService;
		private readonly IMapper _mapper;

		public UserService(IRepository<User> repository, RecipeService recipeService, IMapper mapper)
		{
			_mapper = mapper;
			this._repository = repository;
			_recipeService = recipeService;
		}

		public async Task<User> GetUserById(int id) => await _repository.Get(id);

		//Metoda GetUserById bez parametrów wejściowych wyrzuca pierwszego napotkanego użytkownika
		public async Task<User> GetUserById()
		{
			var allUsers = await _repository.GetAll(x => x.Recipes);
			return allUsers.FirstOrDefault();
		}
		public async Task<bool> AddRecipeToFavourites(int id)
		{
			var resultRecipe = _mapper.Map<Recipe>(await _recipeService.GetRecipe(id));
			var user = (await _repository.GetAll(x => x.Recipes)).FirstOrDefault();
			if(user.Recipes.Contains(resultRecipe))
			{
				return false;
			}
			user.Recipes.Add(resultRecipe);
			_repository.Update(user);
			return true;
		}

		public async Task<List<RecipeViewModel>> GetFavouritesRecipesOfUser()
		{
			var user = await GetUserById();
			var ListOfRecipiesToBePassedToView = user.Recipes;
			return ListOfRecipiesToBePassedToView.Select(e => _mapper.Map<RecipeViewModel>(e)).ToList();
        }


        public async Task DeleteRecipeFromFavourites(int idOfRecipeToRemove)
        {
            //Usuwamy na razie recepture jedynego użytkownika jakiego mamy czyli admina!
            var user = await GetUserById();
			user.Recipes.Remove(_mapper.Map < Recipe > (await _recipeService.GetRecipe(idOfRecipeToRemove)));
			_repository.UpdateForDelete(user);
        }
    }
}
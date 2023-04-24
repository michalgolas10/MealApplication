using AutoMapper;
using KuceZBronksuDAL;
using KuceZBronksuDAL.Models;
using KuceZBronksuDAL.Repository.IRepository;
using KuceZBronksuLogic;
using KuceZBronksuWEB.Models;
using Microsoft.Identity.Client;

namespace KuceZBronksuBLL.Services
{
    public class UserService
    {
        private readonly IRepository<User> _repository;
        private readonly RecipeService _recipeService;
        private readonly IMapper _mapper;
        public UserService(IRepository<User> repository, RecipeService recipeService, IMapper mapper)
        {
            _mapper= mapper;
            this._repository = repository;
            _recipeService = recipeService;
        }
        public async Task<User> GetUserById(string id) => await _repository.Get(id);
        //Metoda GetUserById bez parametrów wejściowych wyrzuca pierwszego napotkanego użytkownika
        public async Task<User> GetUserById()
        {
            var allUsers = await _repository.GetAll(x=>x.Recipes);
            return allUsers.FirstOrDefault();   
        }
        public async Task AddRecipeToFavourites(string label)
        {
            var resultRecipe = _mapper.Map<Recipe>(await _recipeService.GetByName(label));
            var users = await _repository.GetAll(x=>x.Recipes);
            //przypisujemy ulubione przepisy do pierwszego znalezionego użytkownika (admin)
            var user = users.FirstOrDefault();
            user.Recipes.Add(resultRecipe);
            }
        
        public async Task<List<RecipeViewModel>> GetFavouritesRecipesOfUser()
        {
            var user = await GetUserById();
            return user.Recipes.Select(e => _mapper.Map<RecipeViewModel>(e)).ToList();
        }
        public async Task DeleteRecipeFromFavourites(string label)
        {
            var recipeToDelete = await _recipeService.GetByName(label);
            //Usuwamy na razie recepture jedynego użytkownika jakiego mamy czyli admina!
            var user = await GetUserById();
            foreach(var userRecipe in user.Recipes)
            {
                if (userRecipe.Label == recipeToDelete.Label)
                    user.Recipes.Remove(userRecipe);
            }
            var recipes = user.Recipes;
            _repository.Update(user);
        }


    }
}
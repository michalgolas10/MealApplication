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
        private readonly DescriptionService _descriptionService;
        public UserService(IRepository<User> repository, RecipeService recipeService, IMapper mapper, DescriptionService descriptionService)
        {
            _mapper = mapper;
            this._repository = repository;
            _recipeService = recipeService;
            _descriptionService = descriptionService;
        }
        public async Task<User> GetUserById(string id) => await _repository.Get(id);
        //Metoda GetUserById bez parametrów wejściowych wyrzuca pierwszego napotkanego użytkownika
        public async Task<User> GetUserById()
        {
            var allUsers = await _repository.GetAll(x=>x.FavouritesRecipes);
            return allUsers.FirstOrDefault();   
        }
        public async Task AddRecipeToFavourites(string id)
        {
            var resultRecipe = _mapper.Map<Recipe>(await _recipeService.GetRecipe(id));
            var users = await _repository.GetAll(x => x.FavouritesRecipes);
            //przypisujemy ulubione przepisy do pierwszego znalezionego użytkownika (admin)
            var user = users.FirstOrDefault();
            user.FavouritesRecipes.Add(new FavouritesRecipes()
            {
                RecipeId = resultRecipe.Id,
                UserId = user.Id,
                Recipe = resultRecipe,
                User = user
            }) ;
            var model = user;
            _repository.Update(user);
            }
        
        public async Task<List<RecipeViewModel>> GetFavouritesRecipesOfUser()
        {
            var user = await GetUserById();
            return user.FavouritesRecipes.Select(e => _mapper.Map<RecipeViewModel>(e)).ToList();
        }
        public async Task DeleteRecipeFromFavourites(string id)
        {
            //Usuwamy na razie recepture jedynego użytkownika jakiego mamy czyli admina!
            var user = await GetUserById();
            foreach(var userRecipe in user.FavouritesRecipes)
            {
                if (userRecipe.RecipeId == _descriptionService.Descript(id))
                    user.FavouritesRecipes.Remove(new FavouritesRecipes()
                    {
                        Recipe = _mapper.Map<Recipe>(await _recipeService.GetRecipe(_descriptionService.Descript(id))),
                        User = user,
                        RecipeId = _descriptionService.Descript(id),
                        UserId = user.Id
                    }) ;
            }
            _repository.Update(user);

        }
	}
}
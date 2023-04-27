using AutoMapper;
using KuceZBronksuDAL;
using KuceZBronksuDAL.Models;
using KuceZBronksuDAL.Repository.IRepository;
using KuceZBronksuLogic;
using KuceZBronksuWEB.Models;
using Microsoft.Identity.Client;
using System.Security.Cryptography.X509Certificates;

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
            var allUsers = await _repository.GetAll(x=>x.UsersFavouritesRecipies);
            return allUsers.FirstOrDefault();   
        }
        //public async Task AddRecipeToFavourites(string id)
        //{
        //    var resultRecipe = _mapper.Map<Recipe>(await _recipeService.GetRecipe(_descriptionService.Descript(id)));
        //    var users = await _repository.GetAll(x => x.UsersFavouritesRecipies);
        //    //przypisujemy ulubione przepisy do pierwszego znalezionego użytkownika (admin)
        //    var user = users.FirstOrDefault();
        //    var recipe =
        //        new FavouritesRecipes
        //        {
        //            User = user,
        //            Recipe = resultRecipe,
        //            RecipeId = resultRecipe.Id,
        //            UserId = user.Id
        //        };
        //    user.UsersFavouritesRecipies.Add(recipe);
        //    _repository.Update(user);
        //    }
		public async Task AddRecipeToFavourites(string id)
		{
			var resultRecipe = _mapper.Map<Recipe>(await _recipeService.GetRecipe(_descriptionService.Descript(id)));
			var users = await _repository.GetAll(x => x.UsersFavouritesRecipies);
			//przypisujemy ulubione przepisy do pierwszego znalezionego użytkownika (admin)
			var user = users.FirstOrDefault();
			user.UsersFavouritesRecipies = new List<FavouritesRecipes>
			{
				new FavouritesRecipes
				{
					User = user,
					Recipe = resultRecipe
				}
			};
			_repository.Update(user);
		}

		public async Task<List<RecipeViewModel>> GetFavouritesRecipesOfUser()
        {
            var user = await GetUserById();
            var favouritesRecipesToView = new List<RecipeViewModel>();
            foreach (var favRecipe in user.UsersFavouritesRecipies)
            {
                favouritesRecipesToView.Add(await _recipeService.GetRecipe(favRecipe.RecipeId));
            };
            return favouritesRecipesToView;
        }
        public async Task DeleteRecipeFromFavourites(string idOfRecipeToRemove)
        {
            //Usuwamy na razie recepture jedynego użytkownika jakiego mamy czyli admina!
            var user = await GetUserById();
            List<FavouritesRecipes> favouritesRecipes = new();
            foreach (var favRecipe in user.UsersFavouritesRecipies)
            {
                if(favRecipe.RecipeId!=idOfRecipeToRemove)
                favouritesRecipes.Add(favRecipe);
            };
            var NewUser = new User()
            {
                Id = user.Id,
                Name = user.Name,
                UsersFavouritesRecipies = favouritesRecipes
            };
            _repository.Delete(user.Id);
            _repository.Insert(NewUser);
        }
	}
}
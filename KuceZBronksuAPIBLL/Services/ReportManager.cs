using AutoMapper;
using KuceZBronksuAPIBLL.Services.IServices;
using KuceZBronksuDAL.Models;
using KuceZBronksuDAL.Repository.IRepository;
using KuceZBronksuAPIBLL.Models;
using KuceZBronksuDAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;

namespace KuceZBronksuAPIBLL.Services
{
	public class ReportManager : IReportManager
	{

        private readonly MealAppContext _context;
        private readonly IMapper _mapper;

		public ReportManager(MealAppContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
        public async Task<List<VisitedRecipeDTO>> GetAllVisitedRecipe()
        {
            var recipes = _context.VisitedRecipes.AsEnumerable();
            var result = recipes.Select(e => _mapper.Map<VisitedRecipeDTO>(e));
            return result.ToList();
        }

        public async Task<List<LastLoggedUsersDTO>> GetAllLoggedUsers()
        {
            var users = _context.LastLoggings.AsEnumerable();
            var result = users.Select(e => _mapper.Map<LastLoggedUsersDTO>(e));
            return result.ToList();
        }

        public async Task<List<RecipeAddedToFavouriteDTO>> GetAllAddedToFavouriteRecipes()
        {
            var recipes = _context.RecipeAddedToFavourites.AsEnumerable();
            var result = recipes.Select(e => _mapper.Map<RecipeAddedToFavouriteDTO>(e));
            return result.ToList();
        }
        public async Task<string> CompleteReportCreate()
        {
            var allLastLoggedUsers = await GetAllLoggedUsers();
            var allRecipesAddedToFavourites = await GetAllAddedToFavouriteRecipes();
            var allRecipesVisited = await CountHowManyClickedRecipeAsync();
            var completeReportOfUsersLogged = string.Empty;
            var completeReportOfRecipeViewed = string.Empty;
            var completeReportOfRecipeAddedToFav = string.Empty;
            foreach (var userAdded in  allLastLoggedUsers)
            {
                completeReportOfUsersLogged = @$"Id użytkownika :{userAdded.UserId} zalogował się : {userAdded.LastLogged}
";
            }
            foreach (var recipesAddedToFav in allRecipesAddedToFavourites)
            {
                completeReportOfRecipeAddedToFav = @$"{ completeReportOfRecipeAddedToFav} 
Użytkownik {recipesAddedToFav.UserId} dodał przepis o nazwe {recipesAddedToFav.LabelOfRecipe} do ulubionych";
            }
            foreach (var recipesVisited in allRecipesVisited)
            {
                completeReportOfRecipeViewed = @$"{completeReportOfRecipeViewed}
Przepis o nazwie {recipesVisited.Item1} został wybrany {recipesVisited.Item2} razy";
            }
            return @$"{completeReportOfUsersLogged}{completeReportOfRecipeAddedToFav}
{completeReportOfRecipeViewed}";
        }
        public async Task<List<Tuple<string?, int>>> CountHowManyClickedRecipeAsync()
        {
            var listOfRecipesNamesWithCounter = new List<Tuple<string?, int>>();
            var allRecipesVisited = await GetAllVisitedRecipe();
            foreach(var recipeClicked in allRecipesVisited)
            {
                var nameOfRecipe = recipeClicked.LabelOfRecipe;
                var howManyClicked = allRecipesVisited.Where(x => x.LabelOfRecipe == recipeClicked.LabelOfRecipe).Count();
                Tuple<string?,int> itemToAdd= Tuple.Create(nameOfRecipe, howManyClicked);
                listOfRecipesNamesWithCounter.Add(itemToAdd);
            }
            return listOfRecipesNamesWithCounter;
        }
    }
}

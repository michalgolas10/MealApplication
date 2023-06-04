using AutoMapper;
using KuceZBronksuBLL.Models;
using KuceZBronksuBLL.Services.IServices;
using KuceZBronksuDAL.Models;
using KuceZBronksuDAL.Repository;
using KuceZBronksuDAL.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using System.Text;

namespace KuceZBronksuBLL.Services
{
	public class PostReportService : IPostReportService
	{
		private readonly UserManager<User> _userManager;
		private readonly ILogger<PostReportService> _logger;
		private readonly IHttpClientFactory _httpClientFactory;

		public PostReportService(UserManager<User> userManager, ILogger<PostReportService> logger, IHttpClientFactory httpClientFactory)
		{
			_userManager = userManager;
			_logger = logger;
			_httpClientFactory = httpClientFactory;
        }

		private async Task<HttpResponseMessage> PostUserActivityAsync(object reportModel, string apiEndpoint)
		{
			var json = Newtonsoft.Json.JsonConvert.SerializeObject(reportModel);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			return await _httpClientFactory.CreateClient().PostAsync(apiEndpoint, content);
		}

		public async Task<int> GetUserIdAsync(string email)
		{
			var user = _userManager.Users.FirstOrDefault(c => c.Email == email);
			var userId = user.Id;
			return userId;
		}

		public async Task ReportRecipeVisitAsync(RecipeViewModel visitedRecipe)
		{
			var apiEndpoint = "https://localhost:7294/VisitedRecipe";
			var recipeToPost = new VisitedRecipesDTO
			{
				RecipeId = visitedRecipe.Id,
				DateWhenClicked = DateTime.Now,
				LabelOfRecipe = visitedRecipe.Label
			};
			var response = await PostUserActivityAsync(recipeToPost, apiEndpoint);
			if (!response.IsSuccessStatusCode)
			{
				_logger.LogError("Couldnt do report of RecipeVisited");
			}
		}

		public async Task ReportUserLoginAsync(int userId)
		{
			var apiEndpoint = "https://localhost:7294/LoggedUser";
			var userToPost = new LastLoggedUsersDTO
			{
				UserId = userId,
				LastLogged = DateTime.Now,
			};
			var response = await PostUserActivityAsync(userToPost, apiEndpoint);
			if (!response.IsSuccessStatusCode)
			{
				_logger.LogError("Couldnt Report User Login");
			}
		}

		public async Task ReportAddedToFavouriteAsync(RecipeViewModel favouriteRecipe, int userId)
		{
			var apiEndpoint = "https://localhost:7294/AddedFavouriteRecipe";
			var recipeToPost = new KuceZBronksuBLL.Models.RecipeAddedToFavouriteDTO
            {
				UserId = userId,
				RecipeId = favouriteRecipe.Id,
				DateWhenClicked = DateTime.Now,
				LabelOfRecie = favouriteRecipe.Label
			};
			var response = await PostUserActivityAsync(recipeToPost, apiEndpoint);
			if (!response.IsSuccessStatusCode)
			{
				_logger.LogError("Couldnt Report Adding To Favourite By User");
			}
		}
    }
}
using AutoMapper;
using KuceZBronksuBLL.Models;
using KuceZBronksuBLL.Services.IServices;
using KuceZBronksuDAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuceZBronksuBLL.Services
{
	public class ReportService : IReportService
	{
		private readonly HttpClient httpClient;
		private readonly IMapper _mapper;
		private readonly UserManager<User> _userManager;
		private readonly ILogger<ReportService> _logger;
		public ReportService(IMapper mapper, UserManager<User> userManager, ILogger<ReportService> logger )
        {
			_mapper = mapper;
			_userManager = userManager;
			_logger = logger;
			httpClient = new HttpClient();
        }
		private async Task<HttpResponseMessage> PostUserActivityAsync(object reportModel, string apiEndpoint)
		{
			var json = Newtonsoft.Json.JsonConvert.SerializeObject(reportModel);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			return await httpClient.PostAsync(apiEndpoint, content);
		}
		public async Task<int> GetUserIdAsync(string email)
		{
			var user = _userManager.Users.FirstOrDefault(c => c.Email == email);
			var userId = user.Id;
			return userId;
		}

		public async Task ReportRecipeVisitAsync(RecipeViewModel visitedRecipe, int userId)
		{
			int userIdToInt;
			userIdToInt = userId;
			var apiEndpoint = "https://localhost:7294/VisitedRecipes";
			var recipeToPost = new VisitedRecipesDTO
			{
				UserId = userIdToInt,
				RecipeId = visitedRecipe.Id,
				DateWhenClicked = DateTime.Now
			};
			_mapper.Map<VisitedRecipe>(recipeToPost);
			var response = await PostUserActivityAsync(recipeToPost, apiEndpoint);
			if (!response.IsSuccessStatusCode)
			{
				_logger.LogError("Couldnt do report of RecipeVisited");
			}
		}

		public async Task ReportUserLoginAsync(int userId)
		{
			var apiEndpoint = "https://localhost:7294/ReportUserLogin";
			var userToPost = new LastLoggedUsersReportDto
			{
				UserId = userId,
				LastLogged = DateTime.Now,
				LoginCount = +1
			};

			_mapper.Map<LastLoggedUsersReport>(userToPost);
			var response = await PostUserActivityAsync(userToPost, apiEndpoint);
			if (!response.IsSuccessStatusCode)
			{
				_logger.LogError("Couldnt Report User Login");
			}
		}
	}
}

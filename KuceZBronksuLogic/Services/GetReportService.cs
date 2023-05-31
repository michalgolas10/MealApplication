using KuceZBronksuBLL.Models;
using KuceZBronksuBLL.Services.IServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KuceZBronksuBLL.Services
{
	public class GetReportService : IGetReportService
	{
		private readonly HttpClient _httpClient;

        private readonly IHttpClientFactory _httpClientFactory;

        public GetReportService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
		
        public async Task<string> GetDataFromApi(string endpoint)
		{
			_httpClientFactory.CreateClient();
			var response = await _httpClientFactory.CreateClient().GetAsync($"https://localhost:7294/{endpoint}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return "Server error. Please contact administrator.";
            }
		}
        public async Task<IEnumerable<VisitedRecipesDTO>> GetVisitedRecipe()
        {
            var visitedRecipesJson = await GetDataFromApi("VisitedRecipe");
            var visitedRecipesDTOs = JsonConvert.DeserializeObject<IEnumerable<VisitedRecipesDTO>>(visitedRecipesJson);
            return visitedRecipesDTOs;
        }
        public async Task<IEnumerable<LastLoggedUsersDTO>> GetLoggedUsers()
        {
            var loggedUsersJson =  await GetDataFromApi("LoggedUser");
            var loggedUsersDtos = JsonConvert.DeserializeObject<IEnumerable<LastLoggedUsersDTO>>(loggedUsersJson);
            return loggedUsersDtos;
        }
        public async Task<IEnumerable<RecipeAddedToFavouriteDTO>> GetRecipeAddedToFavourite()
        {
            var recipeAddedToFavouriteJson = await GetDataFromApi("AddedFavouriteRecipe");
            var recipeAddedToFavouriteDtos = JsonConvert.DeserializeObject<IEnumerable<RecipeAddedToFavouriteDTO>>(recipeAddedToFavouriteJson);
            return recipeAddedToFavouriteDtos;
        }

    }
}

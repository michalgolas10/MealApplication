using KuceZBronksuBLL.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KuceZBronksuBLL.Services
{
	public class ApiService : IApiService
	{
		private readonly HttpClient _httpClient;

		public ApiService()
		{
			_httpClient = new HttpClient();
			_httpClient.BaseAddress = new Uri("https://localhost:7294");
			_httpClient.DefaultRequestHeaders.Accept.Clear();
			_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}

		public async Task<string> GetDataFromApi()
		{
			string responseString = null;

			HttpResponseMessage response = await _httpClient.GetAsync("/VisitedRecipe");

			if (response.IsSuccessStatusCode)
			{
				responseString = await response.Content.ReadAsStringAsync();
			}
			else
			{
				return "Server error. Please contact administrator.";
			}

			return responseString;
		}

	}
}

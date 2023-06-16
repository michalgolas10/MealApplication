using KuceZBronksuBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuceZBronksuBLL.Services.IServices
{
    public interface IGetReportService
    {
        public Task<string> GetDataFromApi(string endpoint);
        public Task<IEnumerable<VisitedRecipesDTO>> GetVisitedRecipe();
        public Task<IEnumerable<LastLoggedUsersDTO>> GetLoggedUsers();
        public Task<IEnumerable<RecipeAddedToFavouriteDTO>> GetRecipeAddedToFavourite();
    }
}

using KuceZBronksuBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuceZBronksuBLL.Services.IServices
{
    public interface ICreateReportService
    {
        public Task<IEnumerable<CountedRecipeViewsModel>> CountRecipeViews(IEnumerable<RecipeViewModel> recipesModel, IEnumerable<VisitedRecipesDTO> visitedRecipesDTO, IEnumerable<RecipeAddedToFavouriteDTO> favouritesDTO);
        public Task<IEnumerable<CountedRecipeAddedToFavouriteModel>> CountRecipeFavourites(IEnumerable<RecipeViewModel> recipesModel, IEnumerable<RecipeAddedToFavouriteDTO> favouritesDTO);
    }
}

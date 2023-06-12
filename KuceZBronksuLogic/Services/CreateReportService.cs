using AutoMapper;
using KuceZBronksuBLL.Models;
using KuceZBronksuBLL.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuceZBronksuBLL.Services
{
    public class CreateReportService : ICreateReportService
    {
        private readonly IMapper _mapper;
        public CreateReportService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<CountedRecipeViewsModel>> CountRecipeViews(IEnumerable<RecipeViewModel> recipesModel, IEnumerable<VisitedRecipesDTO> visitedRecipesDTO, IEnumerable<RecipeAddedToFavouriteDTO> favouritesDTO)
        {
            var countedRecipeViews = _mapper.Map<IEnumerable<CountedRecipeViewsModel>>(recipesModel);

            foreach (var recipe in visitedRecipesDTO)
            {
                foreach (var recipeCount in countedRecipeViews)
                {
                    if (recipeCount.RecipeId == recipe.RecipeId) recipeCount.Count++;
                }
            }

            foreach (var recipe in favouritesDTO)
            {
                foreach (var recipeFavCount in countedRecipeViews)
                {
                    if (recipeFavCount.RecipeId == recipe.RecipeId) recipeFavCount.FavouriteCount++;
                }
            }

            return countedRecipeViews;
        }

        public async Task<IEnumerable<CountedRecipeAddedToFavouriteModel>> CountRecipeFavourites(IEnumerable<RecipeViewModel> recipesModel, IEnumerable<RecipeAddedToFavouriteDTO> favouritesDTO)
        {
            var countedRecipeFavs = _mapper.Map<IEnumerable<CountedRecipeAddedToFavouriteModel>>(recipesModel);

            foreach (var recipe in favouritesDTO)
            {
                foreach (var recipeCount in countedRecipeFavs)
                {
                    if (recipeCount.RecipeId == recipe.RecipeId) recipeCount.FavouriteCount++;
                }
            }
            return countedRecipeFavs;
        }
    }
}

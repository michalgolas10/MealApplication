using AutoMapper;
using KuceZBronksuAPIBLL.Models;
using KuceZBronksuDAL.Models;

namespace KuceZBronksuAPI.AutoMapProfiles
{
	public class RecipeProfiles : Profile
	{
		public RecipeProfiles()
		{
			CreateMap<VisitedRecipeDTO, VisitedRecipe>().ReverseMap();
            CreateMap<LastLoggedUsersDTO, LastLoggedUsers>().ReverseMap();
            CreateMap<RecipeAddedToFavouriteDTO, RecipeAddedToFavourite>().ReverseMap();
        }
	}
}

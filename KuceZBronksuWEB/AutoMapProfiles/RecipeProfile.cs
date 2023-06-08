using AutoMapper;
using KuceZBronksuBLL.Models;
using KuceZBronksuDAL.Models;

namespace KuceZBronksuWEB.AutoMapProfiles
{
	public class RecipeProfile : Profile
	{
		public RecipeProfile()
		{
			CreateMap<Recipe, RecipeViewModel>()
				.ForMember(dest => dest.Calories, opts => opts.MapFrom(src => Math.Round(src.Calories)))
				.ReverseMap();
			CreateMap<EditAndCreateViewModel, Recipe>()
				.ForMember(dest => dest.Calories, opts => opts.MapFrom(src => src.Calories))
				.ForMember(dest => dest.Approved, opts => opts.Equals(false));
			CreateMap<EditAndCreateViewModel, RecipeViewModel>()
				.ReverseMap();
			CreateMap<VisitedRecipe, VisitedRecipesDTO>()
				.ReverseMap();
			CreateMap<LastLoggedUsers, LastLoggedUsersDTO>()
				.ReverseMap();
			CreateMap<RecipeAddedToFavourite, RecipeAddedToFavouriteDTO>()
				.ReverseMap();
			CreateMap<RecipeViewModel, CountedRecipeViewsModel>()
				.ForMember(dest => dest.RecipeId, opts => opts.MapFrom(src => src.Id))
				.ForMember(dest => dest.LabelOfRecipe, opts => opts.MapFrom(src => src.Label))
				.ForMember(dest => dest.Count, opts => opts.Equals(0));
		}
	}
}
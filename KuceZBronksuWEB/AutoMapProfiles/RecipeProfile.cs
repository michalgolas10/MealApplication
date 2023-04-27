using AutoMapper;
using KuceZBronksuWEB.Models;

namespace KuceZBronksuDAL.AutoMapProfiles
{
	public class RecipeProfile : Profile
	{
		public RecipeProfile()
		{
			CreateMap<Recipe, RecipeViewModel>()
				.ForMember(dest => dest.Calories, opts => opts.MapFrom(src => Math.Round(src.Calories)))
				.ReverseMap();
			CreateMap<EditAndCreateViewModel, Recipe>()
				.ForMember(dest => dest.Calories, opts => opts.MapFrom(src => src.Calories));
			CreateMap<EditAndCreateViewModel, RecipeViewModel>()
				.ReverseMap();
		}
	}
}
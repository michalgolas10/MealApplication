using AutoMapper;
using KuceZBronksuDAL.Models;
using KuceZBronksuWebApi.BLL.DTOs;
using KuceZBronksuWebApi.BLL.Services;

namespace KuceZBronksuWebApi.Automapper
{
	public class ReciepAnalysisProfiles : Profile
	{
		ReciepAnalysisProfiles()
		{
			CreateMap<RecipeActivityDto, RecipeActivity>().ReverseMap();
			CreateMap<FavoriteActivityDto, FavoriteActivity>().ReverseMap();
		}
	}
}

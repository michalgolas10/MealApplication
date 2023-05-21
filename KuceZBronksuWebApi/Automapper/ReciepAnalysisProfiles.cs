using AutoMapper;
using KuceZBronksuDAL.Models;
using KuceZBronksuWebApi.BLL.DTOs;

namespace KuceZBronksuWebApi.Automapper
{
	public class ReciepAnalysisProfiles : Profile
	{
		ReciepAnalysisProfiles()
		{
			CreateMap<RecipeAnalysisDto, Recipe>().ReverseMap();
		}
	}
}

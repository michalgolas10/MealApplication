using AutoMapper;
using KuceZBronksuWebApi.BLL.DTOs;
using KuceZBronksuWebApi.DAL.Database;

namespace KuceZBronksuWebApi.Automapper
{
	public class ErrorProfiles : Profile
	{
		public ErrorProfiles()
		{
			CreateMap<ErrorsDto, Errors>();
		}
	}
}

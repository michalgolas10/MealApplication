using AutoMapper;
using KuceZBronksuWebApi.BLL.Services.IServices;
using KuceZBronksuWebApi.Contracts;

namespace KuceZBronksuWebApi.BLL.Services
{
	public class RecipeAnalysisService : IRecipeAnalysisService
	{
		private readonly IMapper _mapper;

		public RecipeAnalysisService(IMapper mapper)
		{
			_mapper = mapper;
		}

		public Task<CreateDateForAnalysisRequest> IRecipeAnalysisService.GetAll()
		{

		}
	}
}

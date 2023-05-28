using AutoMapper;
using KuceZBronksuAPIBLL.Services.IServices;
using KuceZBronksuDAL.Models;
using KuceZBronksuDAL.Repository.IRepository;
using KuceZBronksuAPIBLL.Models;


namespace KuceZBronksuAPIBLL.Services
{
	public class RecipeManager : IRecipeManager
	{
		private readonly IRepository<VisitedRecipe> _repository;
		private readonly IMapper _mapper;

		public RecipeManager(IRepository<VisitedRecipe> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<List<VisitedRecipeDTO>> GetAll()
		{
			var recipes = await _repository.GetAll();
			var result = recipes.Select(e => _mapper.Map<VisitedRecipeDTO>(e));
			return result.ToList();
		}
	}
}

using AutoMapper;
using KuceZBronksuAPIBLL.Models;
using KuceZBronksuAPIBLL.Services.IServices;
using KuceZBronksuDAL.Models;
using KuceZBronksuDAL.Repository.IRepository;


namespace KuceZBronksuAPIBLL.Services
{
	public class RecipeManager : IRecipeManager
	{
		private readonly IRepository<VisitedRecipe> _visitedRecipeRepository;
		private readonly IMapper _mapper;

		public RecipeManager(IRepository<VisitedRecipe> visitedRecipe, IMapper mapper)
		{
			_visitedRecipeRepository = visitedRecipe;
			_mapper = mapper;
		}

		public async Task<IEnumerable<VisitedRecipeBO>> GetAll()
		{
			var result = new List<VisitedRecipeBO>();
			var recipes = await _visitedRecipeRepository.GetAll();

			foreach(var recipe in recipes)
			{
				var recipeBO = _mapper.Map<VisitedRecipeBO>(recipe);
				result.Add(recipeBO);
			}

			return result;
		}
	}
}

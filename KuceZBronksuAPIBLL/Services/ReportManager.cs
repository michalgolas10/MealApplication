using AutoMapper;
using KuceZBronksuAPIBLL.Services.IServices;
using KuceZBronksuDAL.Models;
using KuceZBronksuDAL.Repository.IRepository;
using KuceZBronksuAPIBLL.Models;
using KuceZBronksuDAL.Context;
using Microsoft.EntityFrameworkCore;

namespace KuceZBronksuAPIBLL.Services
{
	public class ReportManager : IReportManager
	{

        private readonly MealAppContext _context;
        private readonly IMapper _mapper;

		public ReportManager(MealAppContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
        public async Task<List<VisitedRecipeDTO>> GetAllVisitedRecipe()
        {
            var recipes = _context.VisitedRecipes.AsEnumerable();
            var result = recipes.Select(e => _mapper.Map<VisitedRecipeDTO>(e));
            return result.ToList();
        }

        public async Task<List<LastLoggedUsersDTO>> GetAllLoggedUsers()
        {
            var users = _context.LastLoggings.AsEnumerable();
            var result = users.Select(e => _mapper.Map<LastLoggedUsersDTO>(e));
            return result.ToList();
        }

        public async Task<List<RecipeAddedToFavouriteDTO>> GetAllAddedToFavouriteRecipes()
        {
            var recipes = _context.RecipeAddedToFavourites.AsEnumerable();
            var result = recipes.Select(e => _mapper.Map<RecipeAddedToFavouriteDTO>(e));
            return result.ToList();
        }
    }
}

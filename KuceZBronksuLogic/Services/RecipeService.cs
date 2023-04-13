using KuceZBronksuBLL.Services.IService;
using KuceZBronksuDAL;
using KuceZBronksuDAL.Repository.IRepository;

namespace KuceZBronksuBLL.Services
{
    public class RecipeService : IService<Recipe>
    {
        private readonly IRepository<Recipe> _repository;

        public RecipeService(IRepository<Recipe> repository)
        {
            this._repository = repository;
        }

        public void AddNew(Recipe t)
        {
            _repository.Update(t);
        }

        public void Delete(Recipe t)
        {
            _repository.Delete(t);
        }

        public async Task<List<Recipe>> GetAll()
        {
            var recipes = await _repository.GetAll("Users");
            return recipes;
        }

        public async Task<Recipe> GetValue(string id)
        {
            return await _repository.Get(id);
        }

		public void Update(Recipe t)
		{
            _repository.Update(t);
		}
	}
}
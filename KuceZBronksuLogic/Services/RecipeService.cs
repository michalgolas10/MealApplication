using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KuceZBronksuDAL.Models;
using KuceZBronksuBLL.Services.IService;
using KuceZBronksuDAL.Repository.IRepository;
using KuceZBronksuDAL.Context;

namespace KuceZBronksuBLL.Services
{
    public class RecipeService : IService<RecipeDb>
    {
        private readonly IRepository<RecipeDb> _repository;
        public RecipeService(IRepository<RecipeDb> repository, MealAppContext context)
        {
            this._repository = repository;
        }
        public void AddNew(RecipeDb t)
        {
            throw new NotImplementedException();
        }

        public void Delete(RecipeDb t)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RecipeDb>> GetAll()
        {
            var recipes = await _repository.GetAll();
            return recipes;
        }

        public Task<RecipeDb> GetValue(string id)
        {
            throw new NotImplementedException();
        }
    }
}

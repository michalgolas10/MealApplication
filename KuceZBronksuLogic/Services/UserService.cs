using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KuceZBronksuDAL.Models;
using KuceZBronksuBLL.Services.IService;
using KuceZBronksuDAL.Context;
using KuceZBronksuDAL.Repository.IRepository;

namespace KuceZBronksuBLL.Services
{
    public class UserService : IService<User>
    {
        private readonly IRepository<User> _repository;
        public UserService(IRepository<User> repository)
        {
            this._repository = repository;
        }
        public void AddNew(User t)
        {
            _repository.Insert(t);
        }

        public void Delete(User t)
        {
            _repository?.Delete(t);
        }

        public async Task<List<User>> GetAll()=> await _repository.GetAll();


        public async Task<User> GetValue(string id) => await _repository.Get(id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KuceZBronksuDAL.Models;
using KuceZBronksuBLL.Services.IService;

namespace KuceZBronksuBLL.Services
{
    public class UserService : IService<User>
    {
        public void AddNew(User t)
        {
            throw new NotImplementedException();
        }

        public void Delete(User t)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetValue(string id)
        {
            throw new NotImplementedException();
        }
    }
}

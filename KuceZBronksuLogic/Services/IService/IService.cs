using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuceZBronksuBLL.Services.IService
{
    
        public interface IService<T>
        {
            Task<List<T>> GetAll();
            Task<T> GetValue(string id);
            void AddNew(T t);
            void Delete(T t);
        }
    
}

using KuceZBronksuDAL.Models.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KuceZBronksuDAL.Repository.IRepository
{
    public interface IRepository<T> where T : Entity
    {
        Task<List<T>> GetAll();
        Task<T> Get(string Id);
        void Delete(T entity);
        void Insert(T entity);
        void Update(T entity);
    }
}

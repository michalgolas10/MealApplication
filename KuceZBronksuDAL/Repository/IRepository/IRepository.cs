using KuceZBronksuDAL.Models.BaseEntity;
using System.Linq.Expressions;

namespace KuceZBronksuDAL.Repository.IRepository
{
    public interface IRepository<T> where T : Entity
    {
        Task<List<T>> GetAll(string include);

        Task<T> Get(string Id);

        void Delete(T entity);

        void Insert(T entity);

        void Update(T entity);
    }
}
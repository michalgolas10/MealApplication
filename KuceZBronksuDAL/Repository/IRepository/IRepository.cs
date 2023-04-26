using KuceZBronksuDAL.Models.BaseEntity;
using System.Linq.Expressions;

namespace KuceZBronksuDAL.Repository.IRepository
{
    public interface IRepository<T> where T : Entity
    {
        Task<List<T>> GetAll(Expression<Func<T, object>>? include = null);

        Task<T> Get(string Id);

        void Delete(string Id);

        void Insert(T entity);

        void Update(T entity);
    }
}
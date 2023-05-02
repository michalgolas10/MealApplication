using KuceZBronksuDAL.Models.BaseEntity;
using System.Linq.Expressions;

namespace KuceZBronksuDAL.Repository.IRepository
{
	public interface IRepository<T> where T : Entity
	{
		Task<List<T>> GetAll(Expression<Func<T, object>>? include = null);

		Task<T> Get(int Id);

		void Delete(int Id);

		void Insert(T entity);

		void Update(T entity);
		
		void UpdateForDelete(T entity);
	}
}
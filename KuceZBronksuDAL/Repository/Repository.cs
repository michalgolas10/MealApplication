using KuceZBronksuDAL.Context;
using KuceZBronksuDAL.Models.BaseEntity;
using KuceZBronksuDAL.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KuceZBronksuDAL.Repository
{
	public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly MealAppContext _context;
		private readonly DbSet<T> _entities;
		public Repository(MealAppContext context)
		{
			this._context = context;
			_entities = context.Set<T>();
		}

		public async Task<T> Get(int id) => await this._entities.AsNoTracking().SingleOrDefaultAsync(e => e.Id == id);

		public void Delete(int id)
		{
			if (id != null)
			{
				var entity = _entities.Find(id);
				_entities.Remove(entity);
				_context.SaveChanges();
			}
		}

		public async Task<List<T>> GetAll(Expression<Func<T, object>>? include = null)
		{
			if (include != null)
			{
                return this._entities
					.Include(include).AsEnumerable().ToList()!;
			}

			return this._entities.AsEnumerable().ToList();
		}

		public void Insert(T entity)
		{
			if (entity != null)
			{
				_entities.AddAsync(entity);
				_context.SaveChanges();
			}
		}

		public void Update(T entity)
		{
			if (entity != null)
			{
                _entities.Update(entity);
				_context.SaveChanges();
			}
		}
    }
}
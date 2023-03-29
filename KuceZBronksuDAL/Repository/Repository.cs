using KuceZBronksuDAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using KuceZBronksuDAL.Context;
using Microsoft.EntityFrameworkCore;
using KuceZBronksuDAL.Models.BaseEntity;

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

        public void Delete(T entity)
        {
            if (entity != null)
            {
                _entities.Remove(entity);
                _context.SaveChanges();
            }
        }

        public T Get(string id) => _entities.SingleOrDefault(e => e.Id == id);

        public async Task<List<T>> GetAll(Expression<Func<T, object>>? include = null)
        {
            if (include != null)
            {
                return await this._entities.Include(include).ToListAsync();
            }

            return await this._entities.ToListAsync();
        }

        public void Insert(T entity)
        {
            if (entity != null)
            {
                _entities.Add(entity);
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


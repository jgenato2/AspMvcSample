using AspMvcSample.Application.Repositories;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AspMvcSample.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AspMvcSample.Infrastructure.Persistence.AppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(AspMvcSample.Infrastructure.Persistence.AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }
    }
}

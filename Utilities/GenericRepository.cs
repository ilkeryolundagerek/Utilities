using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DbContext _context;
        protected DbSet<T> _set;

        protected GenericRepository(DbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public virtual int Count(Expression<Func<T, bool>> predicate = null)
        {
            return predicate != null ? _set.Count(predicate) : _set.Count();
        }

        public virtual void CreateMany(IEnumerable<T> entites)
        {
            if (entites != null && entites.Any())
            {
                _set.AddRange(entites);
            }
        }

        public virtual async Task CreateManyAsync(IEnumerable<T> entites)
        {
            if (entites != null && entites.Any())
            {
                _set.AddRange(entites);
            }
        }

        public virtual void CreateOne(T entity)
        {
            if (entity != null)
            {
                _set.Add(entity);
            }
        }

        public virtual async Task CreateOneAsync(T entity)
        {
            if (entity != null)
            {
                _set.Add(entity);
            }
        }

        public virtual void DeleteMany(IEnumerable<T> entites)
        {
            _set.RemoveRange(entites);
        }

        public virtual void DeleteMany(Expression<Func<T, bool>> predicate = null)
        {
            var entities = ReadMany(predicate);
            _set.RemoveRange(entities);
        }

        //async: Asenkron metot tanımıdır, içinde mutlaka await olmasını beklemez, fakat await varsa mutlaka async metot olmalıdır.
        public virtual async Task DeleteManyAsync(IEnumerable<T> entites)
        {
            _set.RemoveRange(entites);
        }

        public virtual async Task DeleteManyAsync(Expression<Func<T, bool>> predicate = null)
        {
            var entities = ReadMany(predicate);
            _set.RemoveRange(entities);
        }

        public virtual void DeleteOne(object entityKey)
        {
            var entity = ReadOne(entityKey);
            _set.Remove(entity);
        }

        public virtual void DeleteOne(T entity)
        {
            _set.Remove(entity);
        }

        public virtual async Task DeleteOneAsync(object entityKey)
        {
            var entity = ReadOne(entityKey);
            _set.Remove(entity);
        }

        public virtual async Task DeleteOneAsync(T entity)
        {
            _set.Remove(entity);
        }

        public virtual bool Exists(Expression<Func<T, bool>> predicate)
        {
            return _set.Any(predicate);
        }

        public virtual T ReadFirst(Expression<Func<T, bool>> predicate = null)
        {
            return predicate != null ? _set.FirstOrDefault(predicate) : _set.FirstOrDefault();
        }

        public virtual async Task<T> ReadFirstAsync(Expression<Func<T, bool>> predicate = null)
        {
            return predicate != null ? await _set.FirstOrDefaultAsync(predicate) : await _set.FirstOrDefaultAsync();
        }

        public virtual IEnumerable<T> ReadMany(Expression<Func<T, bool>> predicate = null)
        {
            return predicate != null ? _set.Where(predicate) : _set;
        }

        public virtual async Task<IEnumerable<T>> ReadManyAsync(Expression<Func<T, bool>> predicate = null)
        {
            return predicate != null ? _set.Where(predicate) : _set;
        }

        public virtual T ReadOne(object entityKey)
        {
            return _set.Find(entityKey);
        }

        public virtual async Task<T> ReadOneAsync(object entityKey)
        {
            return await _set.FindAsync(entityKey);
        }

        public virtual void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void UpdateMany(IEnumerable<T> entites)
        {
            foreach (var item in entites)
            {
                _context.Entry(item).State = EntityState.Modified;
            }

        }

        public virtual async Task UpdateManyAsync(IEnumerable<T> entites)
        {
            foreach (var item in entites)
            {
                _context.Entry(item).State = EntityState.Modified;
            }
        }

        public virtual async Task UpdateOneAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}

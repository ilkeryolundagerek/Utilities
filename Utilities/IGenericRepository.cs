using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public interface IGenericRepository<T> where T : class
    {
        //Reading:
        T ReadOne(object entityKey);
        Task<T> ReadOneAsync(object entityKey);

        T ReadFirst(Expression<Func<T, bool>> predicate = null);
        Task<T> ReadFirstAsync(Expression<Func<T, bool>> predicate = null);

        IEnumerable<T> ReadMany(Expression<Func<T, bool>> predicate = null);
        Task<IEnumerable<T>> ReadManyAsync(Expression<Func<T, bool>> predicate = null);

        bool Exists(Expression<Func<T, bool>> predicate);

        int Count(Expression<Func<T, bool>> predicate = null);

        //Data works...
        void CreateOne(T entity);
        Task CreateOneAsync(T entity);

        void CreateMany(IEnumerable<T> entites);
        Task CreateManyAsync(IEnumerable<T> entites);

        void Update(T entity);
        Task UpdateOneAsync(T entity);

        void UpdateMany(IEnumerable<T> entites);
        Task UpdateManyAsync(IEnumerable<T> entites);

        void DeleteOne(object entityKey);
        Task DeleteOneAsync(object entityKey);

        void DeleteOne(T entity);
        Task DeleteOneAsync(T entity);

        void DeleteMany(IEnumerable<T> entites);
        Task DeleteManyAsync(IEnumerable<T> entites);

        void DeleteMany(Expression<Func<T, bool>> predicate = null);
        Task DeleteManyAsync(Expression<Func<T, bool>> predicate = null);
    }
}

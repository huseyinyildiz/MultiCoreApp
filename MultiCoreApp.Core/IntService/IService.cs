using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultiCoreApp.Core.IntService
{
    public interface IService<T> where T: class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();

        //Select * from Product where Name = "Apple"
        Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate); //tek kayıt listeler


        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate); //coklu kayıt listeler
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);

        Task<IQueryable<T>> QListAsync();

        Task<T> AddAsync(T entity); //tekli kayıt yapar
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities); //coklu kayıt yapar

        T Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(IEnumerable<T> entities);
    }
}

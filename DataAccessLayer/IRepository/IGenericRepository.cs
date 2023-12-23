
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface IGenericRepository<T> where T : Entity
    {
        Task<T> GetByIDAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<int> DeleteAsync(int id);

        IQueryable<T> GetWhereQuery(Expression<Func<T, bool>>? predicate);

        Task<bool> Exist(int id);
        Task<int> SaveChanges();
        IQueryable<T> AsQueryable();

	}
}

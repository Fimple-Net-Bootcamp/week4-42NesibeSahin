using DataAccessLayer.Context;
using DataAccessLayer.IRepository;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        protected ProjeDB _context = new ProjeDB();
        protected DbSet<T> _entity => _context.Set<T>();

        public GenericRepository(ProjeDB context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task<T> AddAsync(T entity)
        {
            await _entity.AddAsync(entity);
            await SaveChanges();
            return entity;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var entity = await GetByIDAsync(id);
            if (entity != null)
            {
                _entity.Remove(entity);
                return await SaveChanges();
            }
            else
                return 0;

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entity.ToListAsync();
        }

        public async Task<T> GetByIDAsync(int id)
        {
            return await _entity.FirstOrDefaultAsync(x => x.ID == id);
        }

        public IQueryable<T> GetWhereQuery(Expression<Func<T, bool>>? predicate)
        {
            return _entity.Where(predicate);
        }
        public async Task<bool> Exist(int id)
        {
            return await _entity.AnyAsync(c => c.ID == id);
        }
        public async Task<T> UpdateAsync(T entity)
        {
            _entity.Update(entity);
            await SaveChanges();
            return entity;
        }

        public virtual async Task<int> SaveChanges()
        {
            return (await _context.SaveChangesAsync());
        }

		public IQueryable<T> AsQueryable()
        {
            return ( _entity.AsQueryable());
        }

	}
}

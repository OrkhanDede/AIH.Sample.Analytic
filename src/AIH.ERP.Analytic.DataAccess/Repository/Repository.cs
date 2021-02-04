using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AIH.ERP.Analytic.DataAccess;
using AIH.ERP.Analytic.Domain.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AIH.ERP.Analytic.DataAccess.Repository
{
    public class Repository<T> : IRepository<T>
        where T : class, IEntity, new()
    {
        private readonly ApplicationDbContext _context;


        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        public virtual IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }
        public virtual IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties) query = query.IncludeAll(includeProperty);
            return query;
        }

        public virtual IQueryable<T> GetAll(params string[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties) query = query.IncludeAll(includeProperty);
            return query;
        }
        public Task<T> GetSingleFirstAsync()
        {
            return _context.Set<T>().FirstOrDefaultAsync();
        }


        public virtual Task<T> GetSingleFirstAsync(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefaultAsync(predicate);
        }
        public virtual Task<T> GetSingleFirstAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>().IncludeAll(includeProperties);

            return query.FirstOrDefaultAsync(predicate);
        }

        public virtual Task<T> GetSingleFirstAsync(Expression<Func<T, bool>> predicate, params string[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>().IncludeAll(includeProperties);


            return query.FirstOrDefaultAsync(predicate);
        }

        public virtual Task<T> GetSingleLastAsync(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _context.Set<T>();
            return query.LastOrDefaultAsync(predicate);
        }

        public Task<T> GetSingleLastAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>().IncludeAll(includeProperties);
            return query.LastOrDefaultAsync(predicate);
        }

        public Task<T> GetSingleLastAsync(Expression<Func<T, bool>> predicate, params string[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>().IncludeAll(includeProperties);
            return query.LastOrDefaultAsync(predicate);
        }

        public virtual Task<T> GetSingleLastAsync()
        {
            IQueryable<T> query = _context.Set<T>();
            return query.LastOrDefaultAsync();
        }


        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {

            IQueryable<T> query = _context.Set<T>().IncludeAll(includeProperties);
            return query.Where(predicate);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, params string[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> IsExistAsync(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AnyAsync(predicate);
        }
        public virtual Task<bool> IsExistAsync(Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>().IncludeAll(includeProperties);
            return query.AnyAsync(predicate);
        }

        public Task<bool> IsExistAsync(Expression<Func<T, bool>> predicate, params string[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>().IncludeAll(includeProperties);
            return query.AnyAsync(predicate);
        }

        public virtual async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity).ConfigureAwait(false);
        }
        public virtual Task AddRangeAsync(List<T> entity)
        {
            return _context.Set<T>().AddRangeAsync(entity);
        }
        public virtual void Update(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public virtual void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = _context.Set<T>().Where(predicate);
            _context.Set<T>().RemoveRange(entities);
        }
        /// <summary>
        /// Get a table
        /// </summary>
        public IQueryable<T> Table => _context.Set<T>();
    }

}

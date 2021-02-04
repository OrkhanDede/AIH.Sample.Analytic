using AIH.ERP.Analytic.Domain.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AIH.ERP.Analytic.DataAccess.Repository
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> GetAll(params string[] includeProperties);

        Task<T> GetSingleFirstAsync();
        Task<T> GetSingleFirstAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetSingleFirstAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetSingleFirstAsync(Expression<Func<T, bool>> predicate, params string[] includeProperties);

        Task<T> GetSingleLastAsync();
        Task<T> GetSingleLastAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetSingleLastAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetSingleLastAsync(Expression<Func<T, bool>> predicate, params string[] includeProperties);


        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate,
            params string[] includeProperties);


        Task<bool> IsExistAsync(Expression<Func<T, bool>> predicate);
        Task<bool> IsExistAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<bool> IsExistAsync(Expression<Func<T, bool>> predicate, params string[] includeProperties);

        Task AddAsync(T entity);
        Task AddRangeAsync(List<T> entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteWhere(Expression<Func<T, bool>> predicate);
        IQueryable<T> Table { get; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Abstract
{
    public partial interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> GetAll();
        int Count();
        T GetSingle(Guid id);
        T GetSingle(Expression<Func<T, bool>> predicate);
        T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteWhere(Expression<Func<T, bool>> predicate);
        void Commit();
    }

    public partial interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        Task <IAsyncEnumerable<T>> AllIncludingAsync(params Expression<Func<T, object>>[] includeProperties);
        Task<IAsyncEnumerable<T>> GetAllAsync();
        Task <int> CountAsync();
        Task<T> GetSingleAsync(Guid id);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<IAsyncEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteWhereAsync(Expression<Func<T, bool>> predicate);
        Task CommitAsync();
    }
}
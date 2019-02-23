﻿using Core.Models.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Repositories.Abstract
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
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteWhere(Expression<Func<T, bool>> predicate);
        void Commit();
    }

    public partial interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        Task <IEnumerable<T>> AllIncludingAsync(params Expression<Func<T, object>>[] includeProperties);
        Task <IEnumerable<T>> GetAllAsync();
        Task <int> CountAsync();
        Task <T> GetSingleAsync(Guid id);
        Task <T> GetSingleAsync(Expression<Func<T, bool>> predicate);
        Task <T> GetSingleAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task <IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate);
        Task <IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<bool> IsExistsAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task CommitAsync();
    }
}
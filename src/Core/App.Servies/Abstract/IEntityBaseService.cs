using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Models.Entities.Abstract;

namespace Core.Services.Abstract
{
    public interface IEntityBaseService<EntityType> where EntityType : class, IEntityBase, new()
    {
        Task<EntityType> GetAsync(Guid id);
        Task<EntityType> GetAsync(Expression<Func<EntityType, bool>> predicate);
        Task<EntityType> GetAsync(Guid id, params Expression<Func<EntityType, object>>[] includeProperties);
        Task<EntityType> GetAsync(Expression<Func<EntityType, bool>> predicate, params Expression<Func<EntityType, object>>[] includeProperties);

        Task AddAsync(EntityType entity);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(EntityType entity);
        Task<IEnumerable<EntityType>> GetAllAsync();

        Task<IEnumerable<EntityType>> FindByAsync(Expression<Func<EntityType, bool>> predicate);
        Task<IEnumerable<EntityType>> FindByAsync(Expression<Func<EntityType, bool>> predicate, params Expression<Func<EntityType, object>>[] includeProperties);

        Task<bool> IsExistsAsync(Guid id);
        Task<bool> IsExistsAsync(Expression<Func<EntityType, bool>> predicate);

        object SelectNeededObjects(IEnumerable<EntityType> enties, params Expression<Func<EntityType, object>>[] selectedProperties);

    }
}

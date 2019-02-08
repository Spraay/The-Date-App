using App.Model.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.Abstract
{
    public interface IEntityBaseService<EntityType> where EntityType : class, IEntityBase, new()
    {
        Task<EntityType> GetAsync(Guid id);
        Task<EntityType> GetAsync(Guid id, params Expression<Func<EntityType, object>>[] includeProperties);
        Task AddAsync(EntityType entity);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(EntityType entity);
        Task<IEnumerable<EntityType>> GetAllAsync();
        Task<IEnumerable<EntityType>> FindByAsync(Expression<Func<EntityType, bool>> predicate);
        Task<IEnumerable<EntityType>> FindByAsync(Expression<Func<EntityType, bool>> predicate, params Expression<Func<EntityType, object>>[] includeProperties);
    }
}

﻿using App.DAO.Data;
using App.Model.Assigned;
using App.Model.Entities;
using App.Model.Entities.Abstract;
using App.Repository;
using App.Repository.Abstract;
using App.Service.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Service
{
    public class BasicEntityService<EntityType> : IBasicEntityService<EntityType> where EntityType : class, IEntityBase, new()
    {
        private readonly IEntityBaseRepository<EntityType> _repository;

        public BasicEntityService(IEntityBaseRepository<EntityType> repository)
        {
            _repository = repository;
        }

        public async Task<EntityType> GetAsync(Guid id)
        {
            return await GetAsync(id, null);
        }

        public async Task<EntityType> GetAsync(Guid id, params Expression<Func<EntityType, object>>[] includeProperties)
        {
            return await _repository.GetSingleAsync(_=>_.Id == id, includeProperties);
        }

        public async Task AddAsync(EntityType entity)
        {
            await _repository.AddAsync(entity);
            await _repository.CommitAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            _repository.DeleteWhere(_ => _.Id == id);
            await _repository.CommitAsync();
        }

        public async Task UpdateAsync(EntityType entity)
        {
            _repository.Update(entity);
            await _repository.CommitAsync();
        }

        public async Task<IEnumerable<EntityType>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task <IEnumerable<EntityType>> FindByAsync(Expression<Func<EntityType, bool>> predicate)
        {
            return await FindByAsync(predicate, null);
        }

        public async Task <IEnumerable<EntityType>> FindByAsync(Expression<Func<EntityType, bool>> predicate, params Expression<Func<EntityType, object>>[] includeProperties)
        {
            return await _repository.FindByAsync(predicate, includeProperties);
        }
    }
}

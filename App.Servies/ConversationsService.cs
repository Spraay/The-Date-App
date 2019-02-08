using App.DAO.Data;
using App.Model.Assigned;
using App.Model.Entities;
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
    public class ConversationsService : IConversationsService
    {
        private readonly IConversationRepository _repository;
        private readonly IFriendRepository _friendRepository;
        public ConversationsService(IConversationRepository repository)
        {
            _repository = repository;
        }

        public async Task UpdateUsersAsync(Guid id, Guid[] userList)
        {
            var conversation = _repository.GetSingle(_=>_.Id == id, _=>_.Users);
            var newUsers = new List<ConversationUser>() { };
            foreach(var userId in userList)
            {
                newUsers.Add(new ConversationUser() { UserId = userId, ConversationId = id });
            }
            conversation.Users = newUsers;
            _repository.Update(conversation);
            await _repository.CommitAsync();
        }

        public async Task<IEnumerable<Conversation>> GetUserConversationsAsync(Guid currentUserId)
        {
            return await _repository.FindByAsync(_ => _.Users.Select(__ => __.UserId).Contains(currentUserId));
        }

        public async Task<Conversation> GetAsync(Guid id)
        {
            return await GetAsync(id, null);
        }

        public async Task<Conversation> GetAsync(Guid id, params Expression<Func<Conversation, object>>[] includeProperties)
        {
            return await _repository.GetSingleAsync(_=>_.Id == id, includeProperties);
        }

        public async Task AddAsync(Conversation entity)
        {
            await _repository.AddAsync(entity);
            await _repository.CommitAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            _repository.DeleteWhere(_ => _.Id == id);
            await _repository.CommitAsync();
        }

        public async Task UpdateAsync(Conversation entity)
        {
            _repository.Update(entity);
            await _repository.CommitAsync();
        }

        public async Task<IEnumerable<Conversation>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task <IEnumerable<Conversation>> FindByAsync(Expression<Func<Conversation, bool>> predicate)
        {
            return await FindByAsync(predicate, null);
        }

        public async Task <IEnumerable<Conversation>> FindByAsync(Expression<Func<Conversation, bool>> predicate, params Expression<Func<Conversation, object>>[] includeProperties)
        {
            return await _repository.FindByAsync(predicate, includeProperties);
        }

        public async Task UpdateNameAsync(Guid id, string name)
        {
            var entity = await GetAsync(id);
            entity.Name = name;
            _repository.Update(entity);
            await _repository.CommitAsync();
        }
    }
}

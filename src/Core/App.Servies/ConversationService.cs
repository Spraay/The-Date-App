using Core.Models.Entities;
using Core.Repositories.Abstract;
using Core.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ConversationService : EntityBaseService<Conversation>, IConversationService
    {
        private readonly IConversationRepository _repository;
        public ConversationService(IConversationRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task UpdateUsersAsync(Guid id, Guid[] userList)
        {
            var conversation = await GetAsync(id, _=>_.Users);
            var newUsers = new List<ConversationUser>() { };
            foreach(var userId in userList)
            {
                newUsers.Add(new ConversationUser() { UserId = userId, ConversationId = id });
            }
            conversation.Users = newUsers;
            await UpdateAsync(conversation);
        }

        public async Task UpdateNameAsync(Guid id, string name)
        {
            var entity = await GetAsync(id);
            entity.Name = name;
            await UpdateAsync(entity);
        }

        public async Task<IEnumerable<Conversation>> GetUserConversationsAsync(Guid userId)
        {
            return await FindByAsync(_ => _.Users.Select(__ => __.UserId).Contains(userId));
        }
    }
}

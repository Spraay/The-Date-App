using App.DAO.Data;
using App.Model.Assigned;
using App.Model.Entities;
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
    public class ConversationsService : BasicEntityService<Conversation>, IConversationsService 
    {
        public ConversationsService(IEntityBaseRepository<Conversation> repository) : base(repository)
        {
            
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

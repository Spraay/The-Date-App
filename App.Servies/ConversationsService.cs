using App.DAO.Data;
using App.Model.Assigned;
using App.Model.Entities;
using App.Service.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service
{
    public class ConversationsService : IConversationsService
    {
        private readonly ApplicationDbContext _context;

        public ConversationsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsersAsync(Guid id)
        {
            IQueryable<User> query = _context.Set<ConversationUser>()
                .Where(_ => _.UserId == id)
                .Select(_ => _.User);
            return await query.ToListAsync();
        }

        public async Task UpdateUsersAsync(Conversation conversation, IEnumerable<User> userFriends, string[] selectedUsers)
        {

            var id = conversation.Id;
            var conversationUsersIds = conversation.Users.Select(_=>_.UserId);
            
            foreach (var friendId in userFriends.Select(_ => _.Id))
            {
                if (selectedUsers.Contains(friendId.ToString()))
                {
                    if (!conversationUsersIds.Contains(friendId))
                    {
                        conversation.Users = (conversation.Users.Concat(new[] { new ConversationUser() { UserId = friendId } })).ToList();
                        
                    }
                }
                else
                {
                    if (conversationUsersIds.Contains(friendId))
                    {
                        conversation.Users = conversation.Users.Where(_ => _.UserId != friendId).ToList();  
                    }
                }
            }
            _context.Conversations.Update(conversation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(string name, IEnumerable<User> userFriends, string[] selectedUsers, Guid id)
        {
            var conversation = await _context.Set<Conversation>()
                 .Include(_ => _.Users)
                 .SingleOrDefaultAsync(_ => _.Id == id);

            conversation.Name = name;

            await UpdateUsersAsync(conversation, userFriends, selectedUsers);

        }
    }
}

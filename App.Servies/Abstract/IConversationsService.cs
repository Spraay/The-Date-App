using App.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Service.Abstract
{
    public interface IConversationsService
    {
        Task<IEnumerable<User>> GetUsersAsync(Guid id);

        Task UpdateUsersAsync(Conversation conversation, IEnumerable<User> userFriends, string[] selectedUsers);
        Task UpdateAsync(string name, IEnumerable<User> userFriends, string[] selectedUsers, Guid id);
    }
}
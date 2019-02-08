﻿using App.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Service.Abstract
{
    public interface IConversationsService : IBasicService<Conversation>
    {
        Task UpdateUsersAsync(Guid id, Guid[] userList);
        Task UpdateNameAsync(Guid id, string name);
        Task<IEnumerable<Conversation>> GetUserConversationsAsync(Guid userId);
    }
}
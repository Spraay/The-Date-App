using DAO;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.IService
{
    public interface IMessageService : IService<Message, Guid, ChatDbContext>
    {
    }
}

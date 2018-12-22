using DAO;
using DAO.Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.IService.IService
{
    public interface IMessageService : IService<Message, Guid, ApplicationDbContext>
    {
    }
}

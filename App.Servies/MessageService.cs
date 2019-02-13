using App.Model.Entities;
using App.Repository.Abstract;
using App.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Service
{
    public class MessageService : EntityBaseService<Message>, IMessageService
    {
        private readonly IMessageRepository _repository;

        public MessageService(IMessageRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}

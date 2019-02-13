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
        private readonly IMessageRepository _messageRepository;
        private readonly IConversationRepository _conversationRepository;

        public MessageService(IMessageRepository messageRepository, IConversationRepository conversationRepository) : base(messageRepository)
        {
            _messageRepository = messageRepository;
            _conversationRepository = conversationRepository;
        }
    }
}

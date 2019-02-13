using App.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Service
{
    public class MessageService : EntityBaseService<MessageService>, IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IConversationRepository _conversationRepository;

        public MessageService(IMessageRepository messageRepository, IConversationRepository conversationRepository)
        {
            _messageRepository = messageRepository;
            _conversationRepository = conversationRepository;
        }
    }
}

using Core.Models.Entities.Abstract;
using System;
namespace Core.Models.Entities
{
    public class ConversationUser 
    {
        public DateTime CreatedDate { get; }

        public Guid ConversationId { get; set; }

        public Conversation Conversation { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}

using System;
namespace Entity
{
    public class Message : IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; }
        public Guid SenderId { get; set; }
        public User Sender { get; set; }
        
        public string Content { get; set; }
        public Guid ConversationId { get; set; }
        public Conversation Conversation { get; set; }
    }
}

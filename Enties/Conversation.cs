using System;
using System.Collections.Generic;
namespace Entity
{
    public class Conversation : IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; } = DateTime.UtcNow;

        public string Name { get; set; }
        public List<ConversationUser> Users { get; set; }
        public List<Message> Messages { get; set; }
    }
}

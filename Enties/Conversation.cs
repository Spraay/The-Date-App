using System;
using System.Collections.Generic;
namespace Enties
{
    public class Conversation
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; } = DateTime.UtcNow;
        public List<ConversationUser> ConversationUsers { get; set; }
        public List<Message> Messages { get; set; }
    }
}

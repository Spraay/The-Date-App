using System;
namespace Enties
{
    public class Message
    {
        public Guid ID { get; set; }
        public Guid SenderId { get; set; }
        public ApplicationUser Sender { get; set; }
        public DateTime Created { get; } = DateTime.Now;
        public string Content { get; set; }
        public Guid ConversationID { get; set; }
        public Conversation Conversation { get; set; }
    }
}

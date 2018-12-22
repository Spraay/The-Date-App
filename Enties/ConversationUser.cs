using System;
namespace Entity
{
    public class ConversationUser
    {
        public Guid ConversationID { get; set; }
        public Conversation Conversation { get; set; }
        public Guid UserID { get; set; }
        public User User { get; set; }
    }
}

using System;
namespace Enties
{
    public class ConversationUser
    {
        public Guid ConversationID { get; set; }
        public Conversation Conversation { get; set; }
        public Guid UserID { get; set; }
        public ApplicationUser User { get; set; }
    }
}

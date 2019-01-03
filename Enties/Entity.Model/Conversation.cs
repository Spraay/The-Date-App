using App.Abstract;
using System;
using System.Collections.Generic;
namespace App.Model.Entity
{
    public class Conversation : IEntityBase
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; } = DateTime.UtcNow;

        public string Name { get; set; }
        public IEnumerable<ConversationUser> Users { get; set; }
        public IEnumerable<Message> Messages { get; set; }
    }
}

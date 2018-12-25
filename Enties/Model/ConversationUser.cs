﻿using App.Abstract;
using System;
namespace App.Model
{
    public class ConversationUser : IEntityBase
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; }

        public Guid ConversationId { get; set; }
        public Conversation Conversation { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}

﻿using App.Model.Entities.Abstract;
using System;
namespace App.Model.Entities
{
    public class Message : IEntityBase
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

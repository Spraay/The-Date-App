using System;
using System.ComponentModel.DataAnnotations;

namespace App.Model.View
{
    public class MessageViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public Guid CreatorId { get; set; }

        [Required]
        public Guid ConversationId { get; set; }

    }
}

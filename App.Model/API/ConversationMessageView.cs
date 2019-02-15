using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Model.API
{
    public class ConversationMessageView
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public Guid ConversationId { get; set; }

        [Required]
        public Guid SenderId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}

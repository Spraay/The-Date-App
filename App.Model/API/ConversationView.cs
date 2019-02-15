using App.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Model.API
{
    public class ConversationView
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public List<ConversationUserView> Users { get; set; }
        public List<ConversationMessageView> Messages { get; set; }
    }
}

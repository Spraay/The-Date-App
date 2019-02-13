using App.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Model.View
{
    public class ConversationViewModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public List<Guid> UserIds { get; set; }
        public List<MessageViewModel> Messages { get; set; }
    }
}

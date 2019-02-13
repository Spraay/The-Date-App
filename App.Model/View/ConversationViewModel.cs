using App.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Model.View
{
    public class ConversationViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public List<Message> Messages { get; set; }
    }
}

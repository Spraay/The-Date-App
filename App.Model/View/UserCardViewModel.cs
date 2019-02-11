using App.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Model.View
{
    public class UserCardViewModel
    {
        public User User { get; set; }
        public List<UserCardLinkViewModel> Links { get; set; }
    }
}

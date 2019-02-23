using Core.Models.Entities;
using System.Collections.Generic;

namespace Web.TheDate.ViewModels
{
    public class UserCardViewModel
    {
        public User User { get; set; }
        public List<UserCardLinkViewModel> Links { get; set; }
    }
}

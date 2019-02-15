using System;
using System.ComponentModel.DataAnnotations;

namespace App.Model.API
{
    public class ConversationUserView
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string ProfileImgSrc { get; set; }
    }
}

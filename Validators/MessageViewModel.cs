using AutoMapper.Configuration;
using Enties;
using System;
using System.ComponentModel.DataAnnotations;

namespace Validators
{
    public class MessageViewModel
    {
        [Required]
        public Guid ID { get; set; }
        [Required]
        [Display(Name = "Author ID")]
        public string AuthorID { get; set; }
        [Required]
        [Display(Name = "Recipient ID")]
        public string RecipientID { get; set; }
        [Required]
        [MinLength(1), MaxLength(256)]
        [Display(Name = "Content")]
        public string Content { get; set; }
        [Required]
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; } = DateTime.UtcNow;
        [Required]
        [Display(Name = "Author")]
        public User Author { get; set; }
        [Required]
        [Display(Name = "Recipient")]
        public User Recipient { get; set; }

        //public class Message_To_MessageViewModel : MapperConfigurationExpression
        //{
        //    public Message_To_MessageViewModel()
        //    {
        //        CreateMap<Message, MessageViewModel>();
        //    }
        //}

        //public class MessageViewModel_To_Message : MapperConfigurationExpression
        //{
        //    public MessageViewModel_To_Message()
        //    {
        //        CreateMap<MessageViewModel, Message>();
        //    }
        //}
    }
}

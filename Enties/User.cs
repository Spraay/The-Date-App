using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
namespace Entity
{
    public class User : IdentityUser<Guid>
    {
        public User() : base() { }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegisterDate { get; } = DateTime.Now;
        public Gender Gender { get; set; }
        public Eyes Eyes { get; set; }
        public Hair Hair { get; set; }
        public string Description { get; set; }
        public ICollection<InterestUser> InterestsApplicationUser { get; set; }
        public ICollection<Image> Gallery { get; set; }
        public ICollection<Friendship> InvitationsSent { get; set; }
        public ICollection<Friendship> InvitationsReceived { get; set; }
        public ICollection<Message> SentMessages { get; set; }
        public ICollection<ConversationUser> Conversations { get; set; }
        public ICollection<ImageLike> ImagesLikes { get; set; }
        public ICollection<ImageComment> ImagesComments { get; set; }
        public string ProfileImageSrc { get; set; } = "NoProfileImage.png";
        public string BackgroundImageSrc { get; set; } = "NoProfileBackground.png";
    }
}

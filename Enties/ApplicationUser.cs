using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
namespace Enties
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser() : base() { }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegisterDate { get; } = DateTime.Now;
        public Gender Gender { get; set; }
        public Eyes Eyes { get; set; }
        public string Description { get; set; }
        public List<InterestApplicationUser> InterestsApplicationUser { get; set; }
        public List<Image> Gallery { get; set; }
        public List<Friendship> InvitationsSent { get; set; }
        public List<Friendship> InvitationsReceived { get; set; }
        public List<Message> SentMessages { get; set; }
        public List<ConversationUser> Conversations { get; set; }
        public List<ImageLike> ImagesLikes { get; set; }
    }
}

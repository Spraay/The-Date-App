using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        //public string City { get; set; }
        //public string Country { get; set; }

        public virtual List<InterestApplicationUser> InterestsApplicationUser { get; set; }
        public virtual List<Image> Gallery { get; set; }

        public virtual List<Friendship> InvitationsSent { get; set; }

        public virtual List<Friendship> InvitationsReceived { get; set; }

        public virtual List<Message> SentMessages { get; set; }
        public List<ConversationUser> Conversations { get; set; }

    }
}

using System;
namespace Enties
{
    public class Friendship
    {
        public Guid SenderId { get; set; }
        public ApplicationUser Sender { get; set; }
        public Guid FriendId { get; set; }
        public ApplicationUser Friend { get; set; }
        public Status Status { get; set; }
        public DateTime Created { get; } = DateTime.Now;
    }
}

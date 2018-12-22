using System;
namespace Enties
{
    public class Friendship
    {
        public Guid SenderId { get; set; }
        public User Sender { get; set; }
        public Guid FriendId { get; set; }
        public User Friend { get; set; }
        public Status Status { get; set; }
        public DateTime Created { get; } = DateTime.Now;
    }
}

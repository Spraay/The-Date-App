using System;
namespace Entity
{
    public class Friendship : IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; }

        public Guid SenderId { get; set; }

        public User Sender { get; set; }

        public Guid FriendId { get; set; }

        public User Friend { get; set; }

        public Status Status { get; set; }
    }
}

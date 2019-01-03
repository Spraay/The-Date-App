using App.Abstract;
using System;
namespace App.Model.Entity
{
    public class Friendship : IEntityBase
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

using Core.Models.Entities.Abstract;
using Core.Models.Enumerations;
using System;
namespace Core.Models.Entities
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

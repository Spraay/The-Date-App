using App.Model.Entities.Abstract;
using App.Model.Enumerations;
using System;
namespace App.Model.Entities
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

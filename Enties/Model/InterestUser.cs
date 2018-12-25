using App.Abstract;
using System;
namespace App.Model
{
    public class InterestUser : IEntityBase
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; }
        public Guid InterestId { get; set; }
        public Interest Interest { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } 
    }
}

using App.Model.Entity.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace App.Model.Entity
{
    public class InterestUser : IEntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; }
        public Guid InterestId { get; set; }
        public Interest Interest { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } 
    }
}

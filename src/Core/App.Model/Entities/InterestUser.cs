using Core.Models.Entities.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Entities
{
    public class InterestUser 
    {
        public DateTime CreatedDate { get; }

        public Guid InterestId { get; set; }

        public Interest Interest { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; } 
    }
}

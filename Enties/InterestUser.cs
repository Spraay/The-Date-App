using System;
namespace Entity
{
    public class InterestUser : IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; }
        public Guid InterestId { get; set; }
        public Interest Interest { get; set; }
        public Guid ApplicationUserID { get; set; }
        public User ApplicationUser { get; set; } 
    }
}

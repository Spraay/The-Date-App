using System;
namespace Enties
{
    public class InterestUser
    {
        public Guid InterestId { get; set; }
        public Interest Interest { get; set; }
        public Guid ApplicationUserID { get; set; }
        public User ApplicationUser { get; set; }      
    }
}

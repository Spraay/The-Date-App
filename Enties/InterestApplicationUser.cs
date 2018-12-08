using System;
namespace Enties
{
    public class InterestApplicationUser
    {
        public Guid InterestId { get; set; }
        public Interest Interest { get; set; }
        public Guid ApplicationUserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }      
    }
}

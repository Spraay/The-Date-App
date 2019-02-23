using System;

namespace Core.Models.Entities
{
    public class RealMeet
    {
        public User Who { get; set; }
        public User With { get; set; }
        public Guid WhoId { get; set; }
        public Guid WithId { get; set; }
        public virtual Vote Vote { get; set; }
        public Guid? VoteId { get; set; }
    }
}

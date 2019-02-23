using System;

namespace Core.Models.Assigned
{
    public class AssignedInterestData
    {
        public Guid InterestID { get; set; }
        public string InterestName { get; set; }
        public bool Assigned { get; set; }
    }
}

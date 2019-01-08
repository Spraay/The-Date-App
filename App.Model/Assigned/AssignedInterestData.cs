using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Model.Assigned
{
    public class AssignedInterestData
    {
        public Guid InterestID { get; set; }
        public string InterestName { get; set; }
        public bool Assigned { get; set; }
    }
}

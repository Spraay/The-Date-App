using System;
using System.Collections.Generic;
namespace Enties
{
    public class Interest
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public List<InterestApplicationUser> InterestApplicationUsers { get; set; }
    }
}
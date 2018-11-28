using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Enties
{
    public class Interest
    {
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }

        public List<InterestApplicationUser> InterestApplicationUsers { get; set; }
    }
}
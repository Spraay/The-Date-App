using System;
using System.Collections.Generic;
namespace Entity
{
    public class Interest : IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; }
        public string Name { get; set; }
        public ICollection<InterestUser> Users { get; set; }
        
    }
}
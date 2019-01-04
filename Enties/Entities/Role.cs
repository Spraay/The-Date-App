using App.Model.Entities.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace App.Model.Entities
{
    public class Role : IdentityRole<Guid>, IEntityBase
    {
        public Role() : base() { }

        public Role(string roleName) : base(roleName) { }
        public Role(string roleName, string description,
            DateTime createdDate)
            : base(roleName)
        {
            base.Name = roleName;
            this.Description = description;
            this.CreatedDate = createdDate;
        }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public override string Name { get => base.Name; set => base.Name = value; }
    }
}

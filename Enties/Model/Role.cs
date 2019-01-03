﻿using App.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace App.Model
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
        public ICollection<UserRole> UsersInRole { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        
    }
}

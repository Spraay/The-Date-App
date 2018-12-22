using Microsoft.AspNetCore.Identity;
using System;
namespace Entity
{
    public class Role : IdentityRole<Guid>
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
    }
}

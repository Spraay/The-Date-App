using App.Model.Entities.Abstract;
using Microsoft.AspNetCore.Identity;
using System;

namespace App.Model.Entities
{
    public class UserRole : IdentityUserRole<Guid>, IEntityBase
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
        public DateTime CreatedDate { get; }
    }
}
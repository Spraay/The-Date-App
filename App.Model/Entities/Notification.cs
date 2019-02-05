using App.Model.Entities.Abstract;
using System;
namespace App.Model.Entities
{
    public class Notification : IEntityBase
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; } = DateTime.Now;
        public User User { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; }
    }
}
using System;
using System.Collections.Generic;
namespace Entity
{
    public class Image : IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; } = DateTime.UtcNow;

        public Guid UserId { get; set; }
        public string Src { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public User User { get; set; }
       
        public ICollection<ImageLike> Likes { get; set; }
        public ICollection<ImageComment> Comments { get; set; }
    }
}
using App.Model.Entities.Abstract;
using System;
using System.Collections.Generic;
namespace App.Model.Entities
{
    public class Image : IEntityBase
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; } = DateTime.UtcNow;

        public Guid UserId { get; set; }
        public string Src { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public User User { get; set; }
       
        public IEnumerable<ImageLike> Likes { get; set; }
        public IEnumerable<ImageComment> Comments { get; set; }
    }
}
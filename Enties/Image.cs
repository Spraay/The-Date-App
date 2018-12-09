using System;
using System.Collections.Generic;
namespace Enties
{
    public class Image
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public string Src { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime CreatedDate { get; } = DateTime.UtcNow;
        public List<ImageLike> Likes { get; set; }
        public List<ImageComment> Comments { get; set; }
    }
}
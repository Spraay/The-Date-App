using System;
namespace Enties
{
    public class ImageLike
    {
        public Guid ID { get; set; }
        public Image Image { get; set; }
        public Guid ImageID { get; set; }
        public ApplicationUser WhoLiked { get; set; }
        public Guid WhoLikedID { get; set; }
        public DateTime CreatedDate { get; } = DateTime.UtcNow;
    }
}

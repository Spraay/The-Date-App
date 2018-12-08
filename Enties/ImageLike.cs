using System;
using System.Collections.Generic;
using System.Text;

namespace Enties
{
    public class ImageLike
    {
        public Guid ID { get; set; }
        public Image Image { get; set; }
        public Guid ImageID { get; set; }
        public ApplicationUser UserWhoLiked { get; set; }
        public Guid UserWhoLikedID { get; set; }
    }
}

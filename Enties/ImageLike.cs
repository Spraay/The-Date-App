using Entity.IEnties;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class ImageLike : IEntity, ILike<Image>
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; } = DateTime.Now;

        public User Creator { get; set; }
        public Guid CreatorID { get; set; }
        public Image LikedItem { get; set; }
        public Guid LikedItemID { get; set; }
        
    }
}

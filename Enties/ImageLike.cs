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
        public Guid CreatorId { get; set; }
        public Image LikedItem { get; set; }
        public Guid LikedItemId { get; set; }
        
    }
}

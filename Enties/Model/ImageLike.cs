using App.Abstract;
using System;

namespace App.Model
{
    public class ImageLike : IEntityBase, ILike<Image>
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; } = DateTime.Now;
        public User Creator { get; set; }
        public Guid CreatorId { get; set; }
        public Image LikedItem { get; set; }
        public Guid LikedItemId { get; set; }
    }
}

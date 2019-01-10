using App.Model.Entities.Abstract;
using System;

namespace App.Model.Entities
{
    public class ImageComment : IEntityBase, IComment<Image>
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; } = DateTime.UtcNow;
        public User Creator { get; set; }
        public Guid CreatorId { get; set; }
        public Image CommentedItem { get; set; }
        public Guid CommentedItemId { get; set; }
        public string Content { get; set; }
    }
}

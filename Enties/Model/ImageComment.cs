using App.Abstract;
using System;

namespace App.Model
{
    public class ImageComment : IEntityBase, IComment<Image>
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; }
        public User Creator { get; set; }
        public Guid CreatorId { get; set; }
        public Image CommentedItem { get; set; }
        public Guid CommentedItemId { get; set; }
        public string Content { get; set; }
    }
}

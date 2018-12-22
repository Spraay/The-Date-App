using Entity.IEnties;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class ImageComment : IEntity, IComment<Image>
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

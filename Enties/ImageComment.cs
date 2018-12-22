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
        public Guid CreatorID { get; set; }
        public Image CommentedItem { get; set; }
        public Guid CommentedItemID { get; set; }
        public string Content { get; set; }
        
    }
}

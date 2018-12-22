using Enties.IEnties;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enties
{
    public class ImageComment : IComment<Image>
    {
        public Guid ID { get; set; }
        public User Creator { get; set; }
        public Guid CreatorID { get; set; }
        public Image CommentedItem { get; set; }
        public Guid CommentedItemID { get; set; }
        public DateTime Created { get; } = DateTime.Now;
        public string Content { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.IEnties
{
    public interface IComment<ItemType>
    {
        User Creator { get; set; }
        Guid CreatorID { get; set; }
        ItemType CommentedItem { get; set; }
        Guid CommentedItemID { get; set; }
        string Content { get; set; }
    }
}

using App.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Abstract
{
    public interface IComment<ItemType>
    {
        User Creator { get; set; }
        Guid CreatorId { get; set; }
        ItemType CommentedItem { get; set; }
        Guid CommentedItemId { get; set; }
        string Content { get; set; }
    }
}

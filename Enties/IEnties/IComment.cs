using System;
using System.Collections.Generic;
using System.Text;

namespace Enties.IEnties
{
    public interface IComment<ItemType>
    {
        Guid ID { get; set; }
        ApplicationUser Creator { get; set; }
        Guid CreatorID { get; set; }
        ItemType CommentedItem { get; set; }
        Guid CommentedItemID { get; set; }
        DateTime Created { get; }
    }
}

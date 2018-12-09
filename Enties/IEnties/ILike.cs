using System;
using System.Collections.Generic;
using System.Text;

namespace Enties.IEnties
{
    public interface ILike<ItemType>
    {
        Guid ID { get; set; }
        ApplicationUser Creator { get; set; }
        Guid CreatorID { get; set; }
        ItemType LikedItem { get; set; }
        Guid LikedItemID { get; set; }
        DateTime Created { get; }
    }
}

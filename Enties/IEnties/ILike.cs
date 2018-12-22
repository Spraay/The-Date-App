using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.IEnties
{
    public interface ILike<ItemType>
    {
        User Creator { get; set; }
        Guid CreatorID { get; set; }
        ItemType LikedItem { get; set; }
        Guid LikedItemID { get; set; }
    }
}

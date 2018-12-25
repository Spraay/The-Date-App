using App.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Abstract
{
    public interface ILike<ItemType>
    {
        User Creator { get; set; }
        Guid CreatorId { get; set; }
        ItemType LikedItem { get; set; }
        Guid LikedItemId { get; set; }
    }
}

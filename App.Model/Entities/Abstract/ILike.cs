using System;

namespace App.Model.Entities.Abstract
{
    public interface ILike<ItemType>
    {
        User Creator { get; set; }
        Guid CreatorId { get; set; }
        ItemType LikedItem { get; set; }
        Guid LikedItemId { get; set; }
    }
}

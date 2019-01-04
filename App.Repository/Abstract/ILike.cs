using App.Model.Entities;
using System;

namespace App.Repository.Abstract
{
    public interface ILike<ItemType>
    {
        User Creator { get; set; }
        Guid CreatorId { get; set; }
        ItemType LikedItem { get; set; }
        Guid LikedItemId { get; set; }
    }
}

using Core.Models.Entities;
using System;

namespace Core.Repositories.Abstract
{
    public interface ILike<ItemType>
    {
        User Creator { get; set; }
        Guid CreatorId { get; set; }
        ItemType LikedItem { get; set; }
        Guid LikedItemId { get; set; }
    }
}

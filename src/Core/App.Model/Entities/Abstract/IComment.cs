﻿using System;

namespace Core.Models.Entities.Abstract
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

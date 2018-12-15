﻿using Enties.IEnties;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enties
{
    public class ImageLike : ILike<Image>
    {
        public Guid ID { get; set; }
        public ApplicationUser Creator { get; set; }
        public Guid CreatorID { get; set; }
        public Image LikedItem { get; set; }
        public Guid LikedItemID { get; set; }
        public DateTime Created { get; } = DateTime.Now;
    }
}
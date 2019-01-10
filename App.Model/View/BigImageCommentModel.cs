using App.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Model.View
{
    public class BigImageCommentModel
    {
        public ImageComment ImageComment { get; set; }
        public IEnumerable<ImageComment> ImageComments { get; set; }
    }
}

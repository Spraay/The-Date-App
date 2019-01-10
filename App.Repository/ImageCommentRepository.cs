using App.DAO.Data;
using App.Model.Entities;
using App.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Repository
{
    public class ImageCommentRepository : EntityBaseRepository<ImageComment>, IImageCommentRepository
    {
        public ImageCommentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

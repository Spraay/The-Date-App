using Infrastructure.DAO.Data;
using Core.Models.Entities;
using Core.Repositories.Abstract;

namespace Core.Repositories
{
    public class ImageCommentRepository : EntityBaseRepository<ImageComment>, IImageCommentRepository
    {
        public ImageCommentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

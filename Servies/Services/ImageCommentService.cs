using DAO.Data;
using Enties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ImageCommentService : IImageCommentService
    {
        private readonly ApplicationDbContext _context;

        public ImageCommentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public ImageComment Get(Guid id)
        {
            return _context.ImagesComments.SingleOrDefault(_=>_.ID == id);
        }
        public List<ImageComment> GetList(Guid imageID)
        {
            return _context.ImagesComments.Where(_ => _.CommentedItemID == imageID).ToList();
        }
        public void Create(Guid imageID, Guid userID, string content)
        {
            _context.ImagesComments.Add(new ImageComment()
            {
                CreatorID = userID,
                CommentedItemID = imageID
            });
            _context.SaveChanges();
        }
        public void Delete(Guid commentID)
        {
            var comment = _context.ImagesComments.SingleOrDefault(_ => _.ID == commentID);
;            _context.ImagesComments.Remove(comment);
            _context.SaveChanges();
        }
        public void Edit(Guid commentID, string content)
        {
            var comment = _context.ImagesComments.SingleOrDefault(_ => _.ID == commentID);
            comment.Content = content;
            _context.ImagesComments.Update(comment);
            _context.SaveChanges();
        }
        public int Count(Guid imageID)
        {
            return _context.ImagesComments.Where(_ => _.CommentedItemID == imageID).Count();
        }
        public bool IsAny(Guid imageID)
        {
            return _context.ImagesComments.Where(_ => _.CommentedItemID == imageID).Any();
        }
        
    }

    //TASK PART
    public partial class ImageCommentService : IImageCommentService
    {
        public async Task<ImageComment> GetAsync(Guid id)
        {
            return await _context.ImagesComments.SingleOrDefaultAsync(_ => _.ID == id);
        }
        public async Task<List<ImageComment>> GetListAsync(Guid imageID)
        {
            return await _context.ImagesComments.Where(_ => _.CommentedItemID == imageID).ToListAsync();
        }
        public async Task CreateAsync(Guid imageID, Guid userID, string content)
        {
            await _context.ImagesComments.AddAsync(new ImageComment()
            {
                CreatorID = userID,
                CommentedItemID = imageID
            });
            await _context.SaveChangesAsync();
        }
        public async Task<int> CountAsync(Guid imageID)
        {
            return await _context.ImagesComments.Where(_ => _.CommentedItemID == imageID).CountAsync();
        }
        public async Task<bool> IsAnyAsync(Guid imageID)
        {
            return await _context.ImagesComments.Where(_ => _.CommentedItemID == imageID).AnyAsync();
        }
    }
}

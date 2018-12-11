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

        public void AddComment(Guid imageID, Guid userID, string content)
        {
            _context.ImagesComments.Add(new ImageComment()
            {
                CreatorID = userID,
                CommentedItemID = imageID
            });
            _context.SaveChanges();
        }
        public async Task AddCommentAsync(Guid imageID, Guid userID, string content)
        {
            await _context.ImagesComments.AddAsync(new ImageComment()
            {
                CreatorID = userID,
                CommentedItemID = imageID
            });
            await _context.SaveChangesAsync();
        }

        public void RemoveComment(Guid commentID)
        {
            var comment = _context.ImagesComments.SingleOrDefault(_ => _.ID == commentID);
;            _context.ImagesComments.Remove(comment);
            _context.SaveChanges();
        }

        public void EditComment(Guid commentID, string content)
        {
            var comment = _context.ImagesComments.SingleOrDefault(_ => _.ID == commentID);
            comment.Content = content;
            _context.ImagesComments.Update(comment);
            _context.SaveChanges();
        }

        public int CountImageComments(Guid imageID)
        {
            return _context.ImagesComments.Where(_ => _.CommentedItemID == imageID).Count();
        }

        public async Task<int> CountImageCommentsAsync(Guid imageID)
        {
            return await _context.ImagesComments.Where(_ => _.CommentedItemID == imageID).CountAsync();
        }

        public bool IsAnyComments(Guid imageID)
        {
            return _context.ImagesComments.Where(_ => _.CommentedItemID == imageID).Any();
        }

        public async Task<bool> IsAnyCommentsAsync(Guid imageID)
        {
            return await _context.ImagesComments.Where(_ => _.CommentedItemID == imageID).AnyAsync();
        }

        public async Task<ImageComment> GetAsync(Guid id)
        {
            return await _context.ImagesComments
                .Include(i => i.CommentedItem)
                .Include(i => i.Creator)
                .FirstOrDefaultAsync(m => m.CreatorID == id);
        }
    }
}

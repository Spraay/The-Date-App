using App.DAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Service.Abstract;
using App.Model.Entity;

namespace App.Service
{
    public partial class ImageCommentService : IImageCommentService
    {
        private readonly ApplicationDbContext _context;
        public ImageCommentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public ImageComment Get(Guid id)
        {
            return _context.ImagesComments.SingleOrDefault(_=>_.Id == id);
        }

        public List<ImageComment> GetList(Guid imageID)
        {
            return _context.ImagesComments.Where(_ => _.CommentedItemId == imageID).ToList();
        }

        public void Create(Guid imageId, Guid userId, string content)
        {
            _context.ImagesComments.Add(new ImageComment()
            {
                CreatorId = userId,
                CommentedItemId = imageId
            });
            _context.SaveChanges();
        }

        public void Delete(Guid commentID)
        {
            var comment = _context.ImagesComments.SingleOrDefault(_ => _.Id == commentID);
;           _context.ImagesComments.Remove(comment);
            _context.SaveChanges();
        }

        public void Edit(Guid commentID, string content)
        {
            var comment = _context.ImagesComments.SingleOrDefault(_ => _.Id == commentID);
            comment.Content = content;
            _context.ImagesComments.Update(comment);
            _context.SaveChanges();
        }

        public int Count(Guid imageID)
        {
            return _context.ImagesComments.Where(_ => _.CommentedItemId == imageID).Count();
        }

        public bool IsAny(Guid imageID)
        {
            return _context.ImagesComments.Where(_ => _.CommentedItemId == imageID).Any();
        }
    }

    //TASK PART
    public partial class ImageCommentService : IImageCommentService
    {
        public async Task<ImageComment> GetAsync(Guid id)
        {
            return await _context.ImagesComments.SingleOrDefaultAsync(_ => _.Id == id);
        }

        public async Task<List<ImageComment>> GetListAsync(Guid imageID)
        {
            return await _context.ImagesComments.Where(_ => _.CommentedItemId == imageID).ToListAsync();
        }

        public async Task CreateAsync(Guid imageID, Guid userID, string content)
        {
            await _context.ImagesComments.AddAsync(new ImageComment()
            {
                CreatorId = userID,
                CommentedItemId = imageID
            });
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Guid commentID, string content)
        {
            var comment = await _context.ImagesComments.SingleOrDefaultAsync(_ => _.Id == commentID);
            comment.Content = content;
            _context.ImagesComments.Update(comment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid commentID)
        {
            var comment = await _context.ImagesComments.SingleOrDefaultAsync(_ => _.Id == commentID);
            _context.ImagesComments.Remove(comment);
            await _context.SaveChangesAsync();
        }
        public async Task<int> CountAsync(Guid imageID)
        {
            return await _context.ImagesComments.Where(_ => _.CommentedItemId == imageID).CountAsync();
        }

        public async Task<bool> IsAnyAsync(Guid imageID)
        {
            return await _context.ImagesComments.Where(_ => _.CommentedItemId == imageID).AnyAsync();
        }
    }
}

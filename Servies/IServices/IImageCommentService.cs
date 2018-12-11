using Enties;
using System;
using System.Threading.Tasks;

namespace Services
{
    public interface IImageCommentService
    {
        void AddComment(Guid imageID, Guid userID, string content);
        Task AddCommentAsync(Guid imageID, Guid userID, string content);
        int CountImageComments(Guid imageID);
        void EditComment(Guid commentID, string content);
        bool IsAnyComments(Guid imageID);
        void RemoveComment(Guid commentID);
        Task<ImageComment> GetAsync(Guid id);
    }
}
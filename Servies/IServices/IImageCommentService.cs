using Enties;
using System;
using System.Threading.Tasks;

namespace Services
{
    public partial interface IImageCommentService
    {
        void Create(Guid imageID, Guid userID, string content);
        void Edit(Guid commentID, string content);
        void Delete(Guid commentID);
        int Count(Guid imageID);
        bool IsAny(Guid imageID);
    }

    //TASK PARTIAL
    public partial interface IImageCommentService
    {
        void CreateAsync(Guid imageID, Guid userID, string content);
        void EditAsync(Guid commentID, string content);
        void DeleteAsync(Guid commentID);
        int CountAsync(Guid imageID);
        bool IsAnyAsync(Guid imageID);
    }
}


   
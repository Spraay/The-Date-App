using Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public partial interface IImageCommentService
    {
        ImageComment Get(Guid id);
        List<ImageComment> GetList(Guid imageID);
        void Create(Guid imageID, Guid userID, string content);
        void Edit(Guid commentID, string content);
        void Delete(Guid commentID);
        int Count(Guid imageID);
        bool IsAny(Guid imageID);
    }

    //TASK PARTIAL
    public partial interface IImageCommentService
    {
        Task<ImageComment> GetAsync(Guid id);
        Task<List<ImageComment>> GetListAsync(Guid imageID);
        Task CreateAsync(Guid imageID, Guid userID, string content);
        Task EditAsync(Guid commentID, string content);
        Task DeleteAsync(Guid commentID);
        Task <int> CountAsync(Guid imageID);
        Task <bool> IsAnyAsync(Guid imageID);
    }
}


   
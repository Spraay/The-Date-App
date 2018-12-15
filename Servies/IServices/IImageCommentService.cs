﻿using Enties;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
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
        void CreateAsync(Guid imageID, Guid userID, string content);
        void EditAsync(Guid commentID, string content);
        void DeleteAsync(Guid commentID);
        int CountAsync(Guid imageID);
        bool IsAnyAsync(Guid imageID);
    }
}


   
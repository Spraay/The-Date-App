using App.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository.Abstract
{
    public interface IImageRepository : IEntityBaseRepository<Image>
    {
        bool IsOwner(Guid id, Guid imgId);

        Task<bool> IsOwnerAsync(Guid id, Guid imgId);
        bool IsExists(Guid id);
        Task<bool> IsExistsAsync(Guid id);
    }
}

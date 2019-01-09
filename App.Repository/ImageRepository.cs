using App.DAO.Data;
using App.Model.Entities;
using App.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository
{
    public class ImageRepository : EntityBaseRepository<Image>, IImageRepository
    {
        public ImageRepository(ApplicationDbContext context) : base(context)
        {
        }

        public bool IsExists(Guid id)
        {
            return GetSingle(id)!=null;
        }

        public async Task<bool> IsExistsAsync(Guid id)
        {
            var r = await GetSingleAsync(id);
            return r != null;
        }

        public bool IsOwner(Guid id, Guid imgId)
        {
            var result = GetSingle(_ => _.Id == imgId);
            if (result != null && result.UserId == id)
                return true;
            return false;
        }

        public async Task<bool> IsOwnerAsync(Guid id, Guid imgId)
        {
            var result = await GetSingleAsync(_ => _.Id == imgId);
            if (result != null && result.UserId == id)
                return true;
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Models.Entities;
using Core.Models.ViewModels;
using Core.Pagination;

namespace Core.Services.Abstract
{
    public interface IExploreService
    {
        Task<IEnumerable<User>> GetOnlyFilledProfilesAsync();
        Task<PaginatedList<ApplicationUserViewModel>> SortUsers(string currentFilter, string searchString, int? pageSize, int? page, bool sortDesc, params Expression<Func<User, object>>[] sortParams);
    }
}
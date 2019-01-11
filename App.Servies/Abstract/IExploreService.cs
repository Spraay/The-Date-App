using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using App.Model.Entities;
using App.Model.View;
using AutoMapper;
using Pagination;

namespace App.Service.Abstract
{
    public interface IExploreService
    {
        Task<IEnumerable<User>> GetOnlyFilledProfilesAsync();
        Task<PaginatedList<ApplicationUserViewModel>> SortUsers(string currentFilter, string searchString, int? pageSize, int? page, bool sortDesc, params Expression<Func<User, object>>[] sortParams);
    }
}
using Core.Models.Entities;
using Core.Repositories.Abstract;
using Core.Services.Abstract;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Pagination;
using Core.Models.ViewModels;

namespace Core.Services
{
    public class ExploreService : IExploreService
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public ExploreService(IUserService userService, IUserRepository userRepository, IMapper mapper)
        {
            _userService = userService;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<User>> GetOnlyFilledProfilesAsync()
        {
            var usersToSort = await _userRepository.GetAllAsync();
            foreach (var user in usersToSort) // remove not filled profiles
            {
                if (!await _userService.IsFilledAsync(user.Id))
                {
                    usersToSort = usersToSort.Where(_ => _.Id != user.Id);
                }
            }
            return usersToSort;
        }

        public async Task<PaginatedList<ApplicationUserViewModel>> SortUsers(
            string currentFilter,
            string searchString,
            int? pageSize,
            int? page,
            bool sortDesc,
            params Expression<Func<User, object>>[] sortParams)
        {
            var usersToSort = await GetOnlyFilledProfilesAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                usersToSort = usersToSort
                    .Where(s =>s.FirstName.Contains(searchString) || s.LastName.Contains(searchString) )
                    .ToList();
            }

            var userQuery = (IQueryable<User>) usersToSort;
            foreach (var param in sortParams){
                if (sortDesc)
                    usersToSort = userQuery.OrderByDescending(param);
                usersToSort = userQuery.OrderBy(param);
            }
            usersToSort = userQuery;
            var viewModel = _mapper.Map<List<User>, List<ApplicationUserViewModel>>(usersToSort.ToList());
            var result = (PaginatedList<ApplicationUserViewModel>.Create(viewModel, page ?? 1, pageSize ?? 10));
            return (result);
        }
    }
}

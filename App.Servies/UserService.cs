using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using App.Service.Abstract;
using App.Model.Entities;
using App.Model.View;
using App.Repository.Abstract;
using App.Model.Enumerations;

namespace App.Service
{
    public partial class UserService : EntityBaseService<User>, IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly IInterestRepository _interestRepository;
        private readonly IUserInterestsService _userInterestService;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository repository, IHttpContextAccessor httpContextAccessor, IMapper mapper, IInterestRepository interestRepository, IUserInterestsService userInterestService) : base(repository)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _interestRepository = interestRepository;
            _userInterestService = userInterestService;
            _userRepository = repository;
        }

        public Guid CurrentUserId
        {
            get
            {
                if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
                    return Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                return Guid.Empty;
            }
        }

        public async Task<bool> IsFilledAsync(Guid id)
        {
            List<ValidationResult> validationResults = new List<ValidationResult>();
            var destination = _mapper.Map<User, ApplicationUserViewModel>(await _userRepository.GetSingleAsync(id));
            var vc = new System.ComponentModel.DataAnnotations.ValidationContext(destination);
            Validator.TryValidateObject(destination, vc, validationResults, true);
            if (validationResults.Count > 0)
            {
                //throw new Exception(validationResults.Select(_ => $"{_.MemberNames}: {_.ErrorMessage}").Aggregate((e, f) => $"{e},  {f}"));
                return false;
            }
            return true;
        }

        public async Task UpdateAsync(ApplicationUserViewModel user, string[] selectedInterests, string selectedGender, string selectedEyes)
        {
            var userFromDB = await _userRepository.GetSingleAsync(user.Id);
            userFromDB.FirstName = user.FirstName;
            userFromDB.LastName = user.LastName;
            userFromDB.Height = user.Height;
            userFromDB.Weight = user.Weight;
            userFromDB.Hair = user.Hair;
            userFromDB.BirthDate = user.BirthDate;
            userFromDB.Description = user.Description;
            userFromDB.Gender = (Gender)Enum.Parse(typeof(Gender), selectedGender);
            userFromDB.Eyes = (Eyes)Enum.Parse(typeof(Eyes), selectedEyes);
            _userRepository.Update(userFromDB);
            await _userRepository.CommitAsync();
            await _userInterestService.UpdateUserInterestsAsync(selectedInterests, user.Id);
        }
    }
}

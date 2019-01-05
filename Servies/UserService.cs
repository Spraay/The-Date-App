using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using App.Service.Abstract;
using App.Model.Entities;
using App.Model.View;
using App.Model.Assigned;
using App.Repository.Abstract;
using App.Model.Enumerations;

namespace App.Service
{
    public partial class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly IInterestUserRepository _interestUserRepository;
        private readonly IInterestRepository _interestRepository;
        private readonly IUserRepository _userRepository;

        public UserService(IHttpContextAccessor httpContextAccessor, IMapper mapper, IInterestUserRepository interestUserRepository, IInterestRepository interestRepository, IUserRepository userRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _interestUserRepository = interestUserRepository;
            _interestRepository = interestRepository;
            _userRepository = userRepository;
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

        public bool IsFilled(Guid id)
        {
            List<ValidationResult> validationResults = new List<ValidationResult>();
            var destination = _mapper.Map<User, ApplicationUserViewModel>(_userRepository.GetSingle(id));
            var vc = new System.ComponentModel.DataAnnotations.ValidationContext(destination);
            Validator.TryValidateObject(destination, vc, validationResults, true);
            if (validationResults.Count > 0)
            {
                //throw new Exception(validationResults.Select(_ => $"{_.MemberNames}: {_.ErrorMessage}").Aggregate((e, f) => $"{e},  {f}"));
                return false;
            }
            return true;
        }

        public void Update(ApplicationUserViewModel user, string[] selectedInterests, string selectedGender, string selectedEyes)
        {
            var userFromDB = _userRepository.GetSingle(user.Id);
            userFromDB.FirstName = user.FirstName;
            userFromDB.LastName = user.LastName;
            userFromDB.Height = user.Height;
            userFromDB.Weight = user.Weight;
            userFromDB.Hair = user.Hair;
            userFromDB.BirthDate = user.BirthDate;
            _userRepository.Update(userFromDB);
            _userRepository.Commit();
            //TODO FIX THIS FUCKING SHIT UpdateInterests(selectedInterests, user.Id);
        }

        public void UpdateInterests(string[] selectedInterests, Guid id)
        {
            var selectedInterestsHS = new HashSet<string>(selectedInterests);
            var userInterestsHS = new HashSet<Guid>(_interestUserRepository.FindBy(_=>_.UserId == id).Select(_=>_.InterestId));
            var allInterestsHS = new HashSet<Guid>(_interestRepository.GetAll().Select(_=>_.Id));

            foreach (var interest in allInterestsHS)
            {
                if (selectedInterestsHS.Contains(interest.ToString()))
                {
                    if (!userInterestsHS.Contains(interest))
                    {
                        _interestUserRepository.Add(new InterestUser()
                        {
                            InterestId = interest,
                            UserId = id
                        });
                    }
                }
                else
                {
                    if (userInterestsHS.Contains(interest))
                    {
                        _interestUserRepository.DeleteWhere(_ => _.InterestId == interest && _.UserId == id);
                    }
                }
            }
            _interestUserRepository.Commit();
        } 
    }

    //TASK PART
    public partial class UserService : IUserService
    {
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

        public async Task<List<AssignedInterestData>> PopulateAssignedInterestDataAsync(User user)
        {
            var allInterests = await _interestRepository.GetAllAsync();
            var userInterestsHS = new HashSet<Guid>(user.Interests.Select(_ => _.InterestId));
            var viewModel = new List<AssignedInterestData>();
            foreach (var interest in allInterests)
            {
                viewModel.Add(new AssignedInterestData
                {
                    InterestID = interest.Id,
                    InterestName = interest.Name,
                    Assigned = userInterestsHS.Contains(interest.Id)
                });
            }
            return viewModel;
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
            await UpdateInterestsAsync(selectedInterests, user.Id);
        }

        public async Task UpdateInterestsAsync(string[] selectedInterests, Guid id)
        {
            var selectedInterestsHS = new HashSet<string>(selectedInterests);
            var userInterests = await _interestUserRepository.FindByAsync(_ => _.UserId == id);
            var userInterestsHS = new HashSet<Guid>(userInterests.Select(_=>_.InterestId));
            var allInterests = await _interestRepository.GetAllAsync();
            var allInterestsHS = new HashSet<Guid>(allInterests.Select(_ => _.Id));

            foreach (var interest in allInterestsHS)
            {
                if (selectedInterestsHS.Contains(interest.ToString()))
                {
                    if (!userInterestsHS.Contains(interest))
                    {
                        await _interestUserRepository.AddAsync(new InterestUser()
                        {
                            InterestId = interest,
                            UserId = id
                        });
                    }
                }
                else
                {
                    if (userInterestsHS.Contains(interest))
                    {
                        _interestUserRepository.DeleteWhere(_ => _.InterestId == interest && _.UserId == id);
                    }
                }
            }
            await _interestUserRepository.CommitAsync();
        }
    }
}

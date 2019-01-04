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

        public void UpdateGender(string selectedGender)
        {
            var user = _userRepository.GetSingle(CurrentUserId);
            Enum.TryParse(selectedGender, out Gender gender);
            user.Gender = gender;
            _userRepository.Update(user);
            _userRepository.Commit();
        }

        public void UpdateEyes(string selectedEyes)
        {
            var user = _userRepository.GetSingle(CurrentUserId);
            Enum.TryParse(selectedEyes, out Eyes eyes);
            user.Eyes = eyes;
            _userRepository.Update(user);
            _userRepository.Commit();
        }

        public void UpdateInterests(string[] interests)
        {
            List<Guid> interestGuid = new List<Guid>();
            foreach(var i in interests)
            {
                interestGuid.Add(new Guid(i));
            }
            _interestUserRepository.UpdateUserInterest(CurrentUserId, interestGuid.ToArray());
        }

        public void Update(User user)
        {
            var userToUpdate = _userRepository.GetSingle(_=>_.Id == user.Id, _=>_.Interests);
            userToUpdate.BirthDate = user.BirthDate;
            userToUpdate.Description = user.Description;
            userToUpdate.Email = user.Email;
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Height = user.Height;
            userToUpdate.Weight = user.Weight;
            userToUpdate.Gallery = user.Gallery;
            _userRepository.Update(userToUpdate);
            _userRepository.Commit();
        }

        public void Update(User user, string[]interests = null, string selectedEyes = null, string selectedGender= null/*TODO:, string selectedHair = null*/)
        {
            if (user != null)
                Update(user);
            if (interests.Any())
                UpdateInterests(interests);
            if (selectedEyes != null)
                UpdateEyes(selectedEyes);
            if (selectedGender != null)
                UpdateGender(selectedGender);
            //TODO: if (selectedHair != null)
            //    UpdateHair(selectedHair);
        }

        public User Get(Guid id)
        {
            return _userRepository.GetSingle(_ => _.Id == id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }



        //public void UpdateInterests(string[] selectedInterests, Guid id)
        //{
        //    var user = Get(id);
        //    if (selectedInterests == null)
        //    {
        //        user.InterestsApplicationUser = new List<InterestUser>();
        //        return;
        //    }

        //    var selectedInterestsHS = new HashSet<string>(selectedInterests);
        //    var userInterests = new HashSet<Guid>(user.InterestsApplicationUser.Select(_ => _.InterestId));
        //    var allInterests = _interestRepository.GetAll();

        //    foreach (var interest in allInterests)
        //    {
        //        if (selectedInterestsHS.Contains(interest.Id.ToString()))
        //        {
        //            if (!userInterests.Contains(interest.Id))
        //            {
        //                user.InterestsApplicationUser.Add(new InterestUser()
        //                {
        //                    Interest = allInterests.SingleOrDefault(_ => _.Id == interest.Id),
        //                    User = user,
        //                    InterestId = allInterests.SingleOrDefault(_ => _.Name == interest.Name).Id,
        //                    UserId = user.Id
        //                });
        //            }
        //        }
        //        else
        //        {
        //            if (userInterests.Contains(interest.Id))
        //            {
        //                user.InterestsApplicationUser.Remove(user.InterestsApplicationUser.SingleOrDefault(_ => _.InterestId == interest.Id));
        //            }
        //        }
        //    }
        //    Update(user);
        //    _context.SaveChanges();
        //}
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

        public async Task UpdateEyesAsync(string selectedEyes)
        {
            var user = await _userRepository.GetSingleAsync(CurrentUserId);
            Enum.TryParse(selectedEyes, out Eyes eyes);
            user.Eyes = eyes;
            _userRepository.Update(user);
            await _userRepository.CommitAsync();
        }

        public async Task UpdateGenderAsync(string selectedGender)
        {
            var user = await _userRepository.GetSingleAsync(CurrentUserId);
            Enum.TryParse(selectedGender, out Gender gender);
            user.Gender = gender;
            _userRepository.Update(user);
            await _userRepository.CommitAsync();
        }

        public async Task UpdateInterestsAsync(string[] selectedInterests)
        {
            List<Guid> interestGuid = new List<Guid>();
            foreach (var i in selectedInterests)
            {
                interestGuid.Add(new Guid(i));
            }
            await _interestUserRepository.UpdateUserInterestAsync(CurrentUserId, interestGuid.ToArray());
        }

        public async Task UpdateAsync(User user)
        {
            var userToUpdate = await _userRepository.GetSingleAsync(_ => _.Id == user.Id, _ => _.Interests);
            userToUpdate.BirthDate = user.BirthDate;
            userToUpdate.Description = user.Description;
            userToUpdate.Email = user.Email;
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Height = user.Height;
            userToUpdate.Weight = user.Weight;
            userToUpdate.Gallery = user.Gallery;
            _userRepository.Update(userToUpdate);
            await _userRepository.CommitAsync();
        }

        public async Task UpdateAsync(User user, string[] interests = null, string selectedEyes = null, string selectedGender = null)
        {
            if (user != null)
                await UpdateAsync(user);
            if (interests.Any())
                await UpdateInterestsAsync(interests);
            if (selectedEyes != null)
                await UpdateEyesAsync(selectedEyes);
            if (selectedGender != null)
                await UpdateGenderAsync(selectedGender);
        }

        public async Task<User> GetAsync(Guid id)
        {
            return await _userRepository.GetSingleAsync(_ => _.Id == id);
        }

        public async Task<List<AssignedInterestData>> PopulateAssignedInterestData(User user)
        {
            var allInterests = await _interestRepository.GetAllAsync();
            var userInterests = await _interestUserRepository.GetUserInterestsAsync(user.Id);
            var applicationUserInterests = new HashSet<Guid>(userInterests.Select(_ => _.Id));
            var viewModel = new List<AssignedInterestData>();
            foreach (var interest in allInterests)
            {
                viewModel.Add(new AssignedInterestData
                {
                    InterestID = interest.Id,
                    InterestName = interest.Name,
                    Assigned = applicationUserInterests.Contains(interest.Id)
                });
            }
            return viewModel;
        }

        public async Task<User> GetSingleWithAllPropertiesAsync(Guid id)
        {
            return await _userRepository.GetSingleAsync(
                _ => _.Id == id,
                _ => _.Interests,
                _ => _.Gallery,
                _ => _.ImagesComments,
                _ => _.ImagesLikes,
                _ => _.InvitationsReceived,
                _ => _.InvitationsSent
            );
        }
    }
}

using AutoMapper;
using App.DAO;
using App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using App.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Validators;
using App.Model;
using App.Service.Abstract;
using App.Model.Abstract;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using App.Repository;

namespace App.Service
{
    public partial class UserService : UserRepository, IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public UserService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(context)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
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
            var destination = _mapper.Map<User, ApplicationUserViewModel>(GetSingle(id));
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
            var user = GetSingle(CurrentUserId);
            Enum.TryParse(selectedGender, out Gender gender);
            user.Gender = gender;
            Update(user);
        }

        public void UpdateEyes(string selectedEyes)
        {
            var user = GetSingle(CurrentUserId);
            Enum.TryParse(selectedEyes, out Eyes eyes);
            user.Eyes = eyes;
            Update(user);
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
            var destination = _mapper.Map<User, ApplicationUserViewModel>(await GetSingleAsync(id));
            var vc = new System.ComponentModel.DataAnnotations.ValidationContext(destination);
            Validator.TryValidateObject(destination, vc, validationResults, true);
            if (validationResults.Count > 0)
            {
                //throw new Exception(validationResults.Select(_ => $"{_.MemberNames}: {_.ErrorMessage}").Aggregate((e, f) => $"{e},  {f}"));
                return false;
            }
            return true;
        }  
    }
}

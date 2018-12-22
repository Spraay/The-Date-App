using AutoMapper;
using DAO.Data;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Service.IService;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Validators;

namespace Service.Service
{
    public partial class UserService : IUserService
    {
        private readonly IInterestService _interestService;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public UserService(IInterestService interestService, ApplicationDbContext context, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _interestService = interestService;
            _context = context;
            _userManager = userManager;
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

       

        public User Get(Guid id)
        {
            return _context.Users
                .Include(_=>_.InterestsApplicationUser)
                .SingleOrDefault(_ => _.Id == id);   
        }

        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public void Update(User user)
        {
            var userToUpdate = Get(user.Id);
            userToUpdate.BirthDate = user.BirthDate;
            userToUpdate.Description = user.Description;
            userToUpdate.Email = user.Email;
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.InterestsApplicationUser = user.InterestsApplicationUser;
            userToUpdate.Height = user.Height;
            userToUpdate.Weight = user.Weight;
            userToUpdate.Gender = user.Gender;
            userToUpdate.Eyes = user.Eyes;
            userToUpdate.Gallery = user.Gallery;

            _context.Users.Update(userToUpdate);
            _context.SaveChanges();
        }
        public void Delete(Guid id)
        {
            _context.Users.Remove(Get(id));
        }
        public List<Interest> GetInterests(Guid id)
        {
            return Get(id).InterestsApplicationUser.Select(_ => _.Interest).ToList();
        }
        public void AddInterest(Guid userId, Guid interestId)
        {
            AddInterest(Get(userId), interestId);
        }
        public void AddInterest(User user, Guid interestId)
        {
            var interest = _interestService.Get(interestId);
            user.InterestsApplicationUser.Add(new InterestUser
            {
                User = user,
                UserId = user.Id,
                Interest = interest,
                InterestId = interestId
            });
            _context.SaveChanges();
        }
        
        public bool IsFilled(User user)
        {
            if (user != null)
            {
                List<ValidationResult> validationResults = new List<ValidationResult>();
                var destination = _mapper.Map<User, ApplicationUserViewModel>(user);
                var vc = new System.ComponentModel.DataAnnotations.ValidationContext(destination);
                Validator.TryValidateObject(destination, vc, validationResults, true);
                if (validationResults.Count > 0)
                {
                    //throw new Exception(validationResults.Select(_ => $"{_.MemberNames}: {_.ErrorMessage}").Aggregate((e, f) => $"{e},  {f}"));
                    return false;
                }
                return true;
            }
            return false;
        }
        public bool IsFilled(Guid applicationuserid)
        {
            return _context.Users
                .Where(p => p.Id == applicationuserid)
                .Any(p => IsFilled(p));
        }
        
        public void UpdateInterests(string[] selectedInterests, Guid id)
        {
            var user = Get(id);
            if (selectedInterests == null)
            {
                user.InterestsApplicationUser = new List<InterestUser>();
                return;
            }

            var selectedInterestsHS = new HashSet<string>(selectedInterests);
            var userInterests = new HashSet<Guid>(user.InterestsApplicationUser.Select(_ => _.InterestId));
            var allInterests = _interestService.GetList();

            foreach (var interest in allInterests)
            {
                if (selectedInterestsHS.Contains(interest.Id.ToString()))
                {
                    if (!userInterests.Contains(interest.Id))
                    {
                        user.InterestsApplicationUser.Add(new InterestUser()
                        {
                            Interest = allInterests.SingleOrDefault(_ => _.Id == interest.Id),
                            User = user,
                            InterestId = allInterests.SingleOrDefault(_ => _.Name == interest.Name).Id,
                            UserId = user.Id
                        });
                    }
                }
                else
                {
                    if (userInterests.Contains(interest.Id))
                    {
                        user.InterestsApplicationUser.Remove(user.InterestsApplicationUser.SingleOrDefault(_ => _.InterestId == interest.Id));
                    }
                }
            }
            Update(user);
            _context.SaveChanges();
        }

        public List<User> GetList()
        {
            return _context.Users.ToList();
        }

        public void Update(User user, string[] selectedInterests, string selectedGender, string selectedEyes)
        {
            if (!Enum.TryParse(selectedEyes, out Eyes eyesValue))
                eyesValue = Eyes.None;
            if (!Enum.TryParse(selectedGender, out Gender genderValue))
                genderValue = Gender.None;
            user.Gender = genderValue;
            user.Eyes = eyesValue;
            Update(user);
            UpdateInterests(selectedInterests, user.Id);
        }

        public bool UserExists(Guid userID)
        {
            return _context.Users.Any(_ => _.Id == userID);
        } 
    }

    //TASK PART
    public partial class UserService : IUserService
    {
        public async Task<User> GetAsync(Guid id)
        {
            return await _context.Users
                .Include(_ => _.InterestsApplicationUser)
                .SingleOrDefaultAsync(_ => _.Id == id);
        }
        public Task<List<User>> GetListAsync()
        {
            return _context.Users
            .Include(_ => _.InterestsApplicationUser)
            .ToListAsync();
        }
        public async Task<bool> IsFilledAsync(Guid applicationUserId)
        {
            return await _context.Users
                     .Where(p => p.Id == applicationUserId)
                     .AnyAsync(_ => IsFilled(_));
        }
    }
}

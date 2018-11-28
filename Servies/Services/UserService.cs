using AutoMapper;
using DAO.Data;
using Enties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Validators;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IInterestService _interestService;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public UserService(IInterestService interestService, ApplicationDbContext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _interestService = interestService;
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public ApplicationUser CurrentUser
        {
            get { return Get(CurrentUserId); }
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

        public ApplicationUser Get(Guid id)
        {
            return _context.Users
                .Include(_=>_.InterestsApplicationUser)
                .SingleOrDefault(_ => _.Id == id);   
        }

        public async Task<ApplicationUser> GetAsync(Guid id)
        {
            return await _context.Users
                .Include(_ => _.InterestsApplicationUser)
                .SingleOrDefaultAsync(_ => _.Id == id);
        }

        public void Create(ApplicationUser user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public void Update(ApplicationUser user)
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
        public void AddInterest(ApplicationUser user, Guid interestId)
        {
            var interest = _interestService.Get(interestId);
            user.InterestsApplicationUser.Add(new InterestApplicationUser
            {
                ApplicationUser = user,
                ApplicationUserID = user.Id,
                Interest = interest,
                InterestId = interestId
            });
            _context.SaveChanges();
        }
        public string GetEmail(Guid applicationUserId)
        {
            return _context.Users
                .Where(p => p.Id == applicationUserId)
                .Select(p => p.Email).FirstOrDefault();
        }
        public string GetFirstName(Guid applicationUserId)
        {
            return _context.Users
                 .Where(p => p.Id == applicationUserId)
                 .Select(p => p.FirstName).FirstOrDefault();
        }
        public string GetLastName(Guid applicationUserId)
        {
            return _context.Users
                 .Where(p => p.Id == applicationUserId)
                 .Select(p => p.LastName).FirstOrDefault();
        }
        public bool IsFilled(ApplicationUser user)
        {
            if (user != null)
            {
                //try
                //{
                //    var destination = _mapper.Map<ApplicationUser, ApplicationUserViewModel>(user);
                //    var vc = new System.ComponentModel.DataAnnotations.ValidationContext(destination);
                //    Validator.ValidateObject(destination, vc, true);
                //}
                //catch (ValidationException e)
                //{
                //    return false;
                //}
                //if (user.FirstName != String.Empty && user.LastName != String.Empty && user.BirthDate != null && user.Height != 0 && user.Weight != 0)
                //    return true;

                List<ValidationResult> validationResults = new List<ValidationResult>();
                var destination = _mapper.Map<ApplicationUser, ApplicationUserViewModel>(user);
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
        public async Task<bool> IsFilledAsync(Guid applicationUserId)
        {
            return await _context.Users
                     .Where(p => p.Id == applicationUserId)
                     .AnyAsync(_ => IsFilled(_));
        }
        public void UpdateInterests(string[] selectedInterests, Guid id)
        {
            var user = Get(id);
            if (selectedInterests == null)
            {
                user.InterestsApplicationUser = new List<InterestApplicationUser>();
                return;
            }

            var selectedInterestsHS = new HashSet<string>(selectedInterests);
            var userInterests = new HashSet<Guid>(user.InterestsApplicationUser.Select(_ => _.InterestId));
            var allInterests = _interestService.GetList();

            foreach (var interest in allInterests)
            {
                if (selectedInterestsHS.Contains(interest.ID.ToString()))
                {
                    if (!userInterests.Contains(interest.ID))
                    {
                        user.InterestsApplicationUser.Add(new InterestApplicationUser()
                        {
                            Interest = allInterests.SingleOrDefault(_ => _.ID == interest.ID),
                            ApplicationUser = user,
                            InterestId = allInterests.SingleOrDefault(_ => _.Name == interest.Name).ID,
                            ApplicationUserID = user.Id
                        });
                    }
                }
                else
                {
                    if (userInterests.Contains(interest.ID))
                    {
                        user.InterestsApplicationUser.Remove(user.InterestsApplicationUser.SingleOrDefault(_ => _.InterestId == interest.ID));
                    }
                }
            }
            Update(user);
            _context.SaveChanges();
        }

        public List<ApplicationUser> GetList()
        {
            return _context.Users.ToList();
        }

        public void Update(ApplicationUser user, string[] selectedInterests, string selectedGender, string selectedEyes)
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

        public Task<List<ApplicationUser>> GetListAsync()
        {
            return _context.Users
            .Include(_ => _.InterestsApplicationUser)
            .ToListAsync();  
        }

    }
}

using AutoMapper.Configuration;
using Core.Models.Entities;
using Core.Models.ViewModels;

namespace Core.Validators
{
    public class User_To_ApplicationUserViewModel : MapperConfigurationExpression
    {
        public User_To_ApplicationUserViewModel()
        {
            CreateMap<User, ApplicationUserViewModel>();
        }
    }

    public class ApplicationUserViewModel_To_User : MapperConfigurationExpression
    {
        public ApplicationUserViewModel_To_User()
        {
            CreateMap<ApplicationUserViewModel, User>();
        }
    }
}

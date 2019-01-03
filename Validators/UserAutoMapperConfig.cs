using AutoMapper.Configuration;
using App.Model.Entity;
using App.Model.View;

namespace Validators
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


using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Core.Models.Entities;
using Infrastructure.DAO.Data;

[assembly: HostingStartup(typeof(Web.TheDate.Areas.Identity.IdentityHostingStartup))]
namespace Web.TheDate.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddIdentity<User, Role>(options =>
                {
                    options.Stores.MaxLengthForKeys = 128;
                    options.User.RequireUniqueEmail = true;
                    options.SignIn.RequireConfirmedEmail = true;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();
            });
        }
    }
}
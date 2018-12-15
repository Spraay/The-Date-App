using Enties;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAO.Data
{
    public class DummyData
    {
      
        public static async Task Initialize(ApplicationDbContext context,
                              UserManager<ApplicationUser> userManager,
                              RoleManager<ApplicationRole> roleManager)
        {
            context.Database.EnsureCreated();
            var contextOLD = context;
            var defaultRoles = new List<ApplicationRole>()
            {
                new ApplicationRole() { Name="Admin",   Description = "This is the administrator role" },
                new ApplicationRole() { Name="User",    Description = "This is the user role" }
            };

            var defaultUsers = new List<ApplicationUser>()
            {
                new ApplicationUser
                {
                    UserName = "admin",
                    Email = "kubarytel@gmail.com",
                    FirstName = "Krystian",
                    LastName = "Rytel",
                    PhoneNumber = "6902341234",
                    Eyes = Eyes.Brown,
                    Gender = Gender.Male,
                    Weight = 75,
                    Height = 180,
                    BirthDate = DateTime.Parse("24.07.1996"),
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    UserName = "user",
                    Email = "bobbaker@gmail.com",
                    FirstName = "Bob",
                    LastName = "Barker",
                    PhoneNumber = "7788951456",
                    EmailConfirmed = true,

                },
                new ApplicationUser
                {
                    UserName = "user2",
                    Email = "gigihadid@gmail.com",
                    FirstName = "Gigi",
                    LastName = "Hadid",
                    PhoneNumber = "6572136821",
                    Eyes = Eyes.Blue,
                    Gender = Gender.Male,
                    Weight = 57,
                    Height = 179,
                    BirthDate = DateTime.Parse("23.04.1995"),
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    UserName = "user3",
                    Email = "arianagrande@gmail.com",
                    FirstName = "Ariana",
                    LastName = "Grande",
                    PhoneNumber = "6041234567",
                    Eyes = Eyes.Brown,
                    Gender = Gender.Male,
                    Weight = 47,
                    Height = 155,
                    BirthDate = DateTime.Parse("26.06.1993"),
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    UserName = "user4",
                    Email = "emiliaclarke@gmail.com",
                    FirstName = "Emilia",
                    LastName = "Clarke",
                    PhoneNumber = "6041234167",
                    Eyes = Eyes.Brown,
                    Gender = Gender.Male,
                    Weight = 52,
                    Height = 160,
                    BirthDate = DateTime.Parse("23.10.1983"),
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    UserName = "user5",
                    Email = "jeniferlawerance@gmail.com",
                    FirstName = "Emilia",
                    LastName = "Clarke",
                    PhoneNumber = "6041234167",
                    Eyes = Eyes.Blue,
                    Gender = Gender.Male,
                    Weight = 52,
                    Height = 175,
                    BirthDate = DateTime.Parse("23.10.1983"),
                    EmailConfirmed = true
                }
            };

            var defaultPassword = "*Test_1";;

            // Adding roles
            if ( !await roleManager.Roles.AnyAsync() )
            {
                foreach (var r in defaultRoles)
                {
                    r.CreatedDate = DateTime.Now;
                    await roleManager.CreateAsync(r);
                }
            }

            // Adding users
            if (!await userManager.Users.AnyAsync())
            {
                foreach (var u in defaultUsers)
                {
                    var result = await userManager.CreateAsync(u);
                    if (result.Succeeded)
                    {
                        await userManager.AddPasswordAsync(u, defaultPassword);
                        await userManager.AddToRoleAsync(u, defaultRoles.ElementAtOrDefault(0).Name);
                        await userManager.AddToRoleAsync(u, defaultRoles.ElementAtOrDefault(1).Name);
                    }
                }
            }

            // Adding friendships
            if (!await context.Friendships.AnyAsync() && context.Users.Count() > 1)
            {
                var user1 = await context.Users.SingleOrDefaultAsync(_ => _.Id == defaultUsers.ElementAtOrDefault(0).Id);
                var user2 = await context.Users.SingleOrDefaultAsync(_ => _.Id == defaultUsers.ElementAtOrDefault(1).Id);

                var friendship = new Friendship()
                {
                    Sender = user1,
                    Friend = user2,
                    Status = Status.Accepted
                };
                await context.Friendships.AddAsync(friendship);

                var conversation = new Conversation()
                {
                    ConversationUsers = new List<ConversationUser>()
                    {
                        new ConversationUser(){ User = user1 },
                        new ConversationUser(){ User = user2 }
                    },

                };
                await context.Conversations.AddAsync(conversation);

                //var messages = new List<Message>()
                //{
                //    new Message(){ Sender = user1, Content = "Hi im Krystian, how are you?", Conversation = conversation },
                //    new Message(){ Sender = user2, Content = "Hi Krystian. Im fine, thanks", Conversation = conversation }
                //};
                //await context.Messages.AddRangeAsync(messages);
            }
            if (!await context.Interests.AnyAsync())
            {
                var defaultInterests = new List<Interest>()
                {
                    new Interest { Name = "Sport" },
                    new Interest { Name = "Motorization" },
                    new Interest { Name = "Video Games" },
                    new Interest { Name = "Photography" },
                    new Interest { Name = "Music" },
                    new Interest { Name = "Singing" },
                    new Interest { Name = "Cooking" },
                    new Interest { Name = "Movies" },
                    new Interest { Name = "Theater" },
                    new Interest { Name = "Art" },
                    new Interest { Name = "Astronmy" },
                    new Interest { Name = "Science" },
                };
                await context.Interests.AddRangeAsync(defaultInterests);
                await context.SaveChangesAsync();
            }
            if(contextOLD != context)
                await context.SaveChangesAsync();
        }
    }
}

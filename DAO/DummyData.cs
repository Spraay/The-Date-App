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
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    UserName = "user",
                    Email = "user@user.com",
                    FirstName = "Bob",
                    LastName = "Barker",
                    PhoneNumber = "7788951456",
                    EmailConfirmed = true,

                },
                new ApplicationUser
                {
                    UserName = "user2",
                    Email = "m@m.m",
                    FirstName = "Mike",
                    LastName = "Myers",
                    PhoneNumber = "6572136821",
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    UserName = "user3",
                    Email = "d@d.d",
                    FirstName = "Donald",
                    LastName = "Duck",
                    PhoneNumber = "6041234567",
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    UserName = "user4",
                    Email = "d@ddd.d",
                    FirstName = "Osama",
                    LastName = "Binladen",
                    PhoneNumber = "6041234167",
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    UserName = "user5",
                    Email = "d@dddddd.d",
                    FirstName = "Johny",
                    LastName = "Dep",
                    PhoneNumber = "6241234167",
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

            //// Adding users
            //if ( !await userManager.Users.AnyAsync() )
            //{
            //    foreach(var u in defaultUsers)
            //    {
            //        var result = await userManager.CreateAsync(u);
            //        if (result.Succeeded)
            //        {
            //            await userManager.AddPasswordAsync(u, defaultPassword);
            //            await userManager.AddToRoleAsync(u, defaultRoles.ElementAtOrDefault(0).Name );
            //            await userManager.AddToRoleAsync(u, defaultRoles.ElementAtOrDefault(1).Name );
            //        }
            //    }
            //}

            //// Adding friendships
            //if ( !await context.Friendships.AnyAsync() && context.Users.Count() > 1 )
            //{
            //    var user1 = await context.Users.SingleOrDefaultAsync(_ => _.Id == defaultUsers.ElementAtOrDefault(0).Id );
            //    var user2 = await context.Users.SingleOrDefaultAsync(_ => _.Id == defaultUsers.ElementAtOrDefault(1).Id );

            //    var friendship = new Friendship()
            //    {
            //        Sender = user1,
            //        Friend = user2,
            //        Status = Status.Accepted
            //    };
            //    await context.Friendships.AddAsync(friendship);

            //    var conversation = new Conversation()
            //    {
            //        ConversationUsers = new List<ConversationUser>()
            //        {
            //            new ConversationUser(){ User = user1 },
            //            new ConversationUser(){ User = user2 }
            //        },
                    
            //    };
            //    await context.Conversations.AddAsync(conversation);

                //var messages = new List<Message>()
                //{
                //    new Message(){ Sender = user1, Content = "Hi im Krystian, how are you?", Conversation = conversation },
                //    new Message(){ Sender = user2, Content = "Hi Krystian. Im fine, thanks", Conversation = conversation } 
                //};
                //await context.Messages.AddRangeAsync(messages);
            //}

            
            await context.SaveChangesAsync();
        }
    }
}

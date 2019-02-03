﻿using App.DAO.Data;
using App.Model.Entities;
using App.Model.Enumerations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.DAO
{
    public class DummyData
    {
      
        public static async Task Initialize(ApplicationDbContext context,
                              UserManager<User> userManager,
                              RoleManager<Role> roleManager)
        {
            context.Database.EnsureCreated();
            var contextOLD = context;
            var defaultRoles = new List<Role>()
            {
                new Role() { Name="Admin",   Description = "This is the administrator role" },
                new Role() { Name="User",    Description = "This is the user role" }
            };

            var defaultUsers = new List<User>()
            {
                new User
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
                    BirthDate = new DateTime(1996, 24, 7),
                    //BirthDate = DateTime.Parse("24.07.1996"),
                    EmailConfirmed = true,
                    Description = "Hello in my profile. I hope that you will like me. Im'a very honest and kind person with many interests :)"
                },
                new User
                {
                    UserName = "user1",
                    Email = "scarlettjohansson@gmail.com",
                    FirstName = "Scarlett",
                    LastName = "Johansson",
                    PhoneNumber = "6572132821",
                    Eyes = Eyes.Blue,
                    Gender = Gender.Female,
                    Weight = 54,
                    Height = 163,
                    BirthDate = new DateTime(1984, 11, 22),
                    EmailConfirmed = true,
                    ProfileImageSrc = "scarlett_johansson.jpg"
                },
                new User
                {
                    UserName = "user2",
                    Email = "gigihadid@gmail.com",
                    FirstName = "Gigi",
                    LastName = "Hadid",
                    PhoneNumber = "6572136821",
                    Eyes = Eyes.Blue,
                    Gender = Gender.Female,
                    Weight = 57,
                    Height = 179,
                    BirthDate = new DateTime(1995, 23, 4),
                    EmailConfirmed = true,
                    ProfileImageSrc = "gigi_hadid.jpg"
                },
                new User
                {
                    UserName = "user3",
                    Email = "arianagrande@gmail.com",
                    FirstName = "Ariana",
                    LastName = "Grande",
                    PhoneNumber = "6041234567",
                    Eyes = Eyes.Brown,
                    Gender = Gender.Female,
                    Weight = 47,
                    Height = 155,
                    BirthDate = new DateTime(1993, 6, 26),
                    EmailConfirmed = true,
                    ProfileImageSrc = "arrianna_grande.jpg"
        },
                new User
                {
                    UserName = "user4",
                    Email = "emiliaclarke@gmail.com",
                    FirstName = "Emilia",
                    LastName = "Clarke",
                    PhoneNumber = "6041234167",
                    Eyes = Eyes.Brown,
                    Gender = Gender.Female,
                    Weight = 52,
                    Height = 160,
                    BirthDate = new DateTime(1983, 10, 23),
                    EmailConfirmed = true,
                    ProfileImageSrc = "emilia_clarke.jpg"
                },
                new User
                {
                    UserName = "user5",
                    Email = "jeniferlawrance@gmail.com",
                    FirstName = "Jennifer",
                    LastName = "Lawerence",
                    PhoneNumber = "6041114167",
                    Eyes = Eyes.Blue,
                    Gender = Gender.Female,
                    Weight = 63,
                    Height = 175,
                    BirthDate = new DateTime(1990, 8, 15),
                    EmailConfirmed = true,
                    ProfileImageSrc = "jennifer_lawrence.jpg"
                },
                new User
                {
                    UserName = "user6",
                    Email = "jeniferlopez@xsd.com",
                    FirstName = "Jennifer",
                    LastName = "Lopez",
                    PhoneNumber = "1041114167",
                    Eyes = Eyes.Blue,
                    Gender = Gender.Female,
                    Weight = 55,
                    Height = 164,
                    BirthDate = new DateTime(1969, 8, 15),
                    EmailConfirmed = true,
                    ProfileImageSrc = "jennifer_lopez.jpg"
                },
                new User
                {
                    UserName = "user7",
                    Email = "jessicaalba@xsd.com",
                    FirstName = "Jessica",
                    LastName = "Alba",
                    PhoneNumber = "1021114167",
                    Eyes = Eyes.Blue,
                    Gender = Gender.Female,
                    Weight = 51,
                    Height = 164,
                    BirthDate = new DateTime(1969, 2, 11),
                    EmailConfirmed = true,
                    ProfileImageSrc = "jessica_alba.jpg"
                },
                new User
                {
                    UserName = "user8",
                    Email = "alejandrabuitrago@xsd.com",
                    FirstName = "Alejandra",
                    LastName = "Buitrago",
                    PhoneNumber = "1222114167",
                    Eyes = Eyes.Blue,
                    Gender = Gender.Female,
                    Weight = 51,
                    Height = 173,
                    //BirthDate = DateTime.Parse("09.10.1987"),
                    BirthDate = new DateTime(1987, 9, 10),
                    EmailConfirmed = true,
                    ProfileImageSrc = "alejandra_buitrago.jpg"
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
                        await userManager.AddToRoleAsync(u, defaultRoles.ElementAtOrDefault(1).Name);
                        
                    }
                }
                await userManager.AddToRoleAsync(defaultUsers[0], defaultRoles.ElementAtOrDefault(0).Name);
            }

            // Adding friendships
            if (!await context.Friendships.AnyAsync() && context.Users.Count() > 1)
            {
                var user1 = await context.Users.SingleOrDefaultAsync(_ => _.Id == defaultUsers.ElementAtOrDefault(0).Id);
                var friends = new List<User>
                {
                    await context.Users.SingleOrDefaultAsync(_ => _.Id == defaultUsers.ElementAtOrDefault(1).Id),
                    await context.Users.SingleOrDefaultAsync(_ => _.Id == defaultUsers.ElementAtOrDefault(2).Id),
                    await context.Users.SingleOrDefaultAsync(_ => _.Id == defaultUsers.ElementAtOrDefault(3).Id),
                    await context.Users.SingleOrDefaultAsync(_ => _.Id == defaultUsers.ElementAtOrDefault(4).Id)
                };

                var conversation = new Conversation();
                await context.Conversations.AddAsync(conversation);

                foreach (var f in friends)
                {
                    await context.Friendships.AddAsync(new Friendship() { Friend = user1, Sender = f, Status = Status.Accepted });
                }



                //var messages = new List<Message>()
                //{
                //    new Message(){ Sender = user1, Content = "Hi im Krystian, how are you?", Conversation = conversation },
                //    new Message(){ Sender = user2, Content = "Hi Krystian. Im fine, thanks", Conversation = conversation }
                //};
                //await context.Messages.AddRangeAsync(messages);

                if (!context.Meets.Any())
                {
                    var meets = new List<RealMeet>
                    {
                        new RealMeet() { Who = user1, With = friends[0] },
                        new RealMeet() { Who = user1, With = friends[1] },
                        new RealMeet() { Who = user1, With = friends[2] },
                        new RealMeet() { Who = user1, With = friends[3] }
                    };
                    if (!context.Votes.Any())
                    {
                        foreach (var m in meets)
                        {
                            await context.Meets.AddAsync(m);
                            await context.Votes.AddAsync(new Vote() { Meet = m, Value = 5 });
                        }
                    }
                }
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

using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using AutoMapper;
using App.DAO.Data;
using App.Repository.Abstract;
using App.Model.Entities;
using App.Repository;
using App.Model.Enumerations;

namespace DAO.Tests
{
    public class ConversationRepositoryTests
    {
        [Fact(DisplayName = "GetAll() with 1 record in table")]
        public void GetAll_Result_1RecordFromTable()
        {
            var context = GetContext();
            AddUsersToContext(context);
            AddConversationToContext(context);
            var _repository = GetRepository(context);
            var result = _repository.GetAll();
            Assert.True(context.Conversations.Any());
            Assert.True(context.Conversations.Count() == 1);
            Assert.True(result.Any());
            Assert.True(result.Count() == 1);
        }

        [Fact(DisplayName = "GetAll() with 100000 record in table (max time is 2 ms)")]
        public void GetAll_Result_100000RecordsFromTable()
        {
            var context = GetContext();
            AddUsersToContext(context);
            AddConversationsToContext(context, 100000);
            var _repository = GetRepository(context);
            var startTime = DateTime.Now;
            var result = _repository.GetAll();
            var endTime = DateTime.Now;
            var expectedTimeMs = 2.0000;
            var reachedTime = (endTime - startTime).TotalMilliseconds;
            Assert.True(reachedTime < expectedTimeMs, $"Expected time is {expectedTimeMs} ms, reached time is {reachedTime} ms");
            Assert.True(context.Conversations.Any());
            Assert.True(context.Conversations.Count() == 1);
            Assert.True(result.Any());
            Assert.True(result.Count() == 1);
        }

        private ApplicationDbContext GetContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                              .UseInMemoryDatabase(Guid.NewGuid().ToString())
                              .Options;
            var context = new ApplicationDbContext(options);
            return context;
        }

        private void AddUsersToContext(ApplicationDbContext context)
        {
            List<User> users = new List<User>
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
                    BirthDate = DateTime.Parse("24.07.1996"),
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
                    BirthDate = DateTime.Parse("22.11.1984"),
                    EmailConfirmed = true,
                    ProfileImageSrc = "scarlett_johansson.jpg"
                },
            };
            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();
        }

        private void AddConversationToContext(ApplicationDbContext context)
        {
            if (!context.Users.Any()) AddUsersToContext(context);
            var conversation = new Conversation() { Name = "X Unit Test", Users = new List<ConversationUser>() };
            var conversationUsers = new List<ConversationUser>();
            foreach (var user in context.Users)
            {
                conversationUsers.Add(new ConversationUser() { UserId = user.Id, ConversationId = conversation.Id });
            }
            conversation.Users = conversationUsers;
            context.Conversations.Add(conversation);
            context.SaveChanges();
        }

        private IConversationRepository GetRepository(ApplicationDbContext context)
        {
            ConversationRepository _conversationRepository = new ConversationRepository(context);
            return _conversationRepository;
        }

        private void AddConversationsToContext(ApplicationDbContext context, int quantity)
        {
            if (!context.Users.Any()) AddUsersToContext(context);
            var conversationUsers = new List<ConversationUser>();
            for (int i = 1; i <= quantity; i++)
            {
                var conversation = new Conversation() { Name = $"X Unit Test{i}", Users = new List<ConversationUser>() };
                foreach (var user in context.Users)
                {
                    conversationUsers.Add(new ConversationUser() { UserId = user.Id, ConversationId = conversation.Id });
                }
                context.Conversations.Add(conversation);
            }  
            context.SaveChanges();
        }
    }
}

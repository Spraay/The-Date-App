using System;
using System.Collections.Generic;
using System.Text;
using App;
using App.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.DAO
{
   
    public class ApplicationDbContext
    : IdentityDbContext<User, Role, Guid, IdentityUserClaim<Guid>, UserRole, IdentityUserLogin<Guid>,IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ImageLike> ImagesLikes { get; set; }
        public DbSet<ImageComment> ImagesComments { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Conversation> Conversations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UsersInRole)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.Roles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            modelBuilder.Entity<InterestUser>()
                .HasKey(_ => new { _.InterestId, _.UserId });

            modelBuilder.Entity<InterestUser>()
                .HasOne(_ => _.Interest)
                .WithMany(__ => __.UsersInteresting)
                .HasForeignKey(_ => _.InterestId);

            modelBuilder.Entity<InterestUser>()
                .HasOne(_ => _.User)
                .WithMany(__ => __.Interests)
                .HasForeignKey(_ => _.UserId);

            modelBuilder.Entity<Image>()
                .HasOne(_ => _.User)
                .WithMany(__ => __.Gallery)
                .HasForeignKey(_ => _.UserId);

            modelBuilder.Entity<Friendship>()
                .HasKey(_ => new { _.SenderId, _.FriendId });

            modelBuilder.Entity<Friendship>()
                .HasOne(p => p.Sender)
                .WithMany(h => h.InvitationsSent)
                .HasForeignKey(p => p.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Friendship>()
                .HasOne(p => p.Friend)
                .WithMany(h=>h.InvitationsReceived)
                .HasForeignKey(p => p.FriendId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Message>()
                .HasOne(_ => _.Sender)
                .WithMany(_ => _.SentMessages)
                .HasForeignKey(_ => _.SenderId);

            modelBuilder.Entity<ConversationUser>()
                .HasKey(_ => new { _.ConversationId, _.UserId });

            modelBuilder.Entity<ConversationUser>()
                .HasOne(_ => _.User)
                .WithMany(__ => __.Conversations)
                .HasForeignKey(_ => _.UserId);

            modelBuilder.Entity<ConversationUser>()
                .HasOne(_ => _.Conversation)
                .WithMany(__ => __.Users)
                .HasForeignKey(_ => _.ConversationId);

            modelBuilder.Entity<Message>()
                .HasOne(_ => _.Conversation)
                .WithMany(__ => __.Messages)
                .HasForeignKey(_ => _.ConversationId);

            modelBuilder.Entity<ImageLike>()
                .HasKey(_ => new { _.CreatorId, _.LikedItemId });

            modelBuilder.Entity<ImageLike>()
                .HasOne(_ => _.LikedItem)
                .WithMany(__ => __.Likes)
                .HasForeignKey(_ => _.LikedItemId);

            modelBuilder.Entity<ImageLike>()
                .HasOne(_ => _.Creator)
                .WithMany(__ => __.ImagesLikes)
                .HasForeignKey(_ => _.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ImageComment>()
                .HasKey(_ => new { _.CreatorId, _.CommentedItemId });

            modelBuilder.Entity<ImageComment>()
                .HasOne(_ => _.CommentedItem)
                .WithMany(__ => __.Comments)
                .HasForeignKey(_ => _.CommentedItemId);

            modelBuilder.Entity<ImageComment>()
                .HasOne(_ => _.Creator)
                .WithMany(__ => __.ImagesComments)
                .HasForeignKey(_ => _.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

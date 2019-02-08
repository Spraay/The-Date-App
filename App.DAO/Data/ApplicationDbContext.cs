using System;
using App.Model.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.DAO.Data
{
   
    public class ApplicationDbContext
    : IdentityDbContext<User, Role, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Interest> Interests { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ImageLike> ImagesLikes { get; set; }
        public DbSet<ImageComment> ImagesComments { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<RealMeet> Meets { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
                .HasOne(_ => _.Creator)
                .WithMany(_ => _.ImagesComments)
                .HasForeignKey(_ => _.CreatorId);

            modelBuilder.Entity<ImageComment>()
                .HasOne(_ => _.CommentedItem)
                .WithMany(_ => _.Comments)
                .HasForeignKey(_ => _.CommentedItemId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Image>()
                .HasMany(_ => _.Comments)
                .WithOne(_ => _.CommentedItem);



            modelBuilder.Entity<RealMeet>()
                .HasKey(_ => new { _.WhoId, _.WithId });

            modelBuilder.Entity<RealMeet>()
                .HasOne(_ => _.Who)
                .WithMany(_ => _.MeetsRequestsSent)
                .HasForeignKey(_ => _.WhoId);

            modelBuilder.Entity<RealMeet>()
                .HasOne(_ => _.With)
                .WithMany(_ => _.MeetsRequestsReceived)
                .HasForeignKey(_ => _.WithId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RealMeet>()
                .HasOne(_ => _.Vote)
                .WithOne(_ => _.Meet)
                .HasForeignKey<RealMeet>(_ => _.VoteId)
                .IsRequired(false);

            modelBuilder.Entity<Notification>()
                .HasOne(_ => _.User)
                .WithMany(__ => __.Notifications)
                .HasForeignKey(_ => _.UserId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(true);
            base.OnConfiguring(optionsBuilder);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAO.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
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

            modelBuilder.Entity<InterestUser>()
                .HasKey(_ => new { _.InterestId, _.ApplicationUserID });

            modelBuilder.Entity<InterestUser>()
                .HasOne(_ => _.Interest)
                .WithMany(__ => __.InterestApplicationUsers)
                .HasForeignKey(_ => _.InterestId);

            modelBuilder.Entity<InterestUser>()
                .HasOne(_ => _.ApplicationUser)
                .WithMany(__ => __.InterestsApplicationUser)
                .HasForeignKey(_ => _.ApplicationUserID);

            modelBuilder.Entity<Image>()
                .HasOne(_ => _.User)
                .WithMany(__ => __.Gallery)
                .HasForeignKey(_ => _.UserID);

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
                .HasKey(_ => new { _.ConversationID, _.UserID });

            modelBuilder.Entity<ConversationUser>()
                .HasOne(_ => _.User)
                .WithMany(__ => __.Conversations)
                .HasForeignKey(_ => _.UserID);

            modelBuilder.Entity<ConversationUser>()
                .HasOne(_ => _.Conversation)
                .WithMany(__ => __.ConversationUsers)
                .HasForeignKey(_ => _.ConversationID);

            modelBuilder.Entity<Message>()
                .HasOne(_ => _.Conversation)
                .WithMany(__ => __.Messages)
                .HasForeignKey(_ => _.ConversationID);

            modelBuilder.Entity<ImageLike>()
                .HasKey(_ => new { _.CreatorID, _.LikedItemID });

            modelBuilder.Entity<ImageLike>()
                .HasOne(_ => _.LikedItem)
                .WithMany(__ => __.Likes)
                .HasForeignKey(_ => _.LikedItemID);

            modelBuilder.Entity<ImageLike>()
                .HasOne(_ => _.Creator)
                .WithMany(__ => __.ImagesLikes)
                .HasForeignKey(_ => _.CreatorID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ImageComment>()
                .HasKey(_ => new { _.CreatorID, _.CommentedItemID });

            modelBuilder.Entity<ImageComment>()
                .HasOne(_ => _.CommentedItem)
                .WithMany(__ => __.Comments)
                .HasForeignKey(_ => _.CommentedItemID);

            modelBuilder.Entity<ImageComment>()
                .HasOne(_ => _.Creator)
                .WithMany(__ => __.ImagesComments)
                .HasForeignKey(_ => _.CreatorID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

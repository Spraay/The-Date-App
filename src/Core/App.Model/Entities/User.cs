﻿using Core.Models.Entities.Abstract;
using Core.Models.Enumerations;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
namespace Core.Models.Entities
{
    public class User : IdentityUser<Guid>, IEntityBase
    {
        public User() : base() { }

        public int Height { get; set; }
        public int Weight { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string ProfileImageSrc { get; set; } = "NoProfileImage.png";
        public string BackgroundImageSrc { get; set; } = "NoProfileBackground.png";
        public DateTime BirthDate { get; set; }
        public DateTime CreatedDate { get; } = DateTime.UtcNow;
        public Gender Gender { get; set; }
        public Eyes Eyes { get; set; }
        public Hair Hair { get; set; }
        public ICollection<InterestUser> Interests { get; set; }
        public IEnumerable<Image> Gallery { get; set; }
        public IEnumerable<Friendship> InvitationsSent { get; set; }
        public IEnumerable<Friendship> InvitationsReceived { get; set; }
        public IEnumerable<Message> SentMessages { get; set; }
        public IEnumerable<ConversationUser> Conversations { get; set; }
        public IEnumerable<ImageLike> ImagesLikes { get; set; }
        public IEnumerable<ImageComment> ImagesComments { get; set; }
        public IEnumerable<RealMeet> MeetsRequestsSent { get; set; }
        public IEnumerable<RealMeet> MeetsRequestsReceived { get; set; }
        public IEnumerable<Vote> CastVotes { get; set; }
        public IEnumerable<Vote> VotedsFrom { get; set; }
        public IEnumerable<Notification> Notifications { get; set; }
    }
}

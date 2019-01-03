﻿using App.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
namespace App.Model
{
    public class User : IdentityUser<Guid>, IEntityBase
    {
        public User() : base() { }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreatedDate { get; } = DateTime.UtcNow;
        public Gender Gender { get; set; }
        public Eyes Eyes { get; set; }
        public Hair Hair { get; set; }
        public string Description { get; set; }
        public ICollection<InterestUser> InterestsApplicationUser { get; set; }
        public IEnumerable<Image> Gallery { get; set; }
        public IEnumerable<Friendship> InvitationsSent { get; set; }
        public IEnumerable<Friendship> InvitationsReceived { get; set; }
        public IEnumerable<Message> SentMessages { get; set; }
        public IEnumerable<ConversationUser> Conversations { get; set; }
        public IEnumerable<ImageLike> ImagesLikes { get; set; }
        public IEnumerable<ImageComment> ImagesComments { get; set; }
        public string ProfileImageSrc { get; set; } = "NoProfileImage.png";
        public string BackgroundImageSrc { get; set; } = "NoProfileBackground.png";
    }
}
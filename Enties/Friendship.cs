using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Enties
{
    public class Friendship
    {
        public Guid SenderId { get; set; }

        public ApplicationUser Sender { get; set; }

        public Guid FriendId { get; set; }

        public ApplicationUser Friend { get; set; }

        public Status Status { get; set; }

        public DateTime Created { get; } = DateTime.Now;

    }
}

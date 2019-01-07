using System;
using System.Collections.Generic;
using System.Text;

namespace App.Model.Entities
{
    public class Vote
    {
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; }

        public User ThePersonWhoVote { get; set; }

        public User ThePersonHeVoted { get; set; }

        public Guid ThePersonWhoVoteId { get; set; }

        public Guid ThePersonHeVotedId { get; set; }

        public int Value { get; set; }
    }
}

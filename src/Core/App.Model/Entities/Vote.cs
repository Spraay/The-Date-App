using Core.Models.Entities.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Entities
{
    public class Vote : IEntityBase
    {
        public RealMeet Meet { get; set; }
        [Range(1, 5)]
        public int Value { get; set; }
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; }
    }
}

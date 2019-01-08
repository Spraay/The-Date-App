using App.Model.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Model.Entities
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

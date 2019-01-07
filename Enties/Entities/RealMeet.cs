using App.Model.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Model.Entities
{
    public class RealMeet : IEntityBase
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; }

        public User ThePersonWhoMet { get; set; }

        public User ThePersonHeMet { get; set; }

        public Guid ThePersonWhoMetId { get; set; }
        public Guid ThePersonHeMetId { get; set; }
    }
}

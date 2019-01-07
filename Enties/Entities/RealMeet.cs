using App.Model.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Model.Entities
{
    public class RealMeet
    {
        public User Who { get; set; }

        public User With { get; set; }

        public Guid WhoId { get; set; }

        public Guid WithId { get; set; }
    }
}

﻿using App.Abstract;
using System;
using System.Collections.Generic;
namespace App.Model
{
    public class Interest : IEntityBase
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; }
        public string Name { get; set; }
        public ICollection<InterestUser> Users { get; set; }
    }
}
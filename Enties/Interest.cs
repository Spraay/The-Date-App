﻿using System;
using System.Collections.Generic;
namespace Entity
{
    public class Interest
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public List<InterestUser> InterestApplicationUsers { get; set; }
    }
}
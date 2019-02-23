﻿using Core.Models.Entities;
using Core.Models.Enumerations;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.ViewModels
{
    public class ApplicationUserViewModel : IdentityUser<Guid>
    {
        [Required]
        [Display(Name = "User Name")]
        [StringLength(50)]
        public override string UserName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Range(100, 250)]
        public int Height { get; set; }

        [Range(40, 250)]
        public int Weight { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Register Date")]
        public DateTime CreatedDate { get; } = DateTime.UtcNow;


        public Gender Gender { get; set; }

        public Eyes Eyes { get; set; }
        public Hair Hair { get; set; }
        public string ProfileImageSrc { get; set; }
        public string BackgroundImageSrc { get; set; }

        [Display(Name = "Descryption")]
        [StringLength(250)]
        public string Description { get; set; }

        public virtual List<InterestUser> Interests { get; set; }
        public virtual List<Image> Gallery { get; set; }

    }
}

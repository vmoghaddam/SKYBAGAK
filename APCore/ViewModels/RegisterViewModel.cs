﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APCore.ViewModels
{
    public class RegisterViewModel
    {

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Password { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string ConfirmPassword { get; set; }

    }
    public class LoginViewModel
    {

        //[Required]
       // [StringLength(50)]
       // [EmailAddress]
        public string UserName { get; set; }

       // [Required]
       // [StringLength(50, MinimumLength = 5)]
        public string Password { get; set; }

    }
}

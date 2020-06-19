﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.ViewModels
{
    public class CreateAdminViewModel
    {
        [Required]
        [Display(Name ="User name")]
        [Remote(action: "IsCompanyInUse", controller: "Account")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailInUse", controller: "Account")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage ="Password doesn't match")]
        [DataType(DataType.Password)]
        [Required]
        public string ConfirmPassword { get; set; }

        [Phone]
        [Required]
        public string PhoneNumber { get; set; }

        public IFormFile ProfilePicture { get; set; }

        
    }
}

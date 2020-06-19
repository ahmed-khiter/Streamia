using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.ViewModels
{
    public class RegisterViewModel
    {
        [Required, DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
      
        [Remote(action: "IsEmailInUse", controller: "Account")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password)
         , Compare("Password", ErrorMessage = "your confirm password doesn't match with password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}

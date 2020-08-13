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
        [Required]
        public string Name { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [Remote(action: "IsEmailInUse", controller: "Account")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password)
         , Compare("Password", ErrorMessage = "Passwords don't match")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Generate MAG")]
        public bool GenerateMAG { get; set; }

        [Display(Name = "Generate Enigma")]
        public bool GenerateEnigma { get; set; }

        [Display(Name = "MAG Only")]
        public bool MAGOnly { get; set; }

        [Display(Name = "Enigma Only")]
        public bool EnigmaOnly { get; set; }

        [Display(Name = "Lock STB Device")]
        public bool LockSTB { get; set; }
        public bool Restream { get; set; }

        public IFormFile ProfilePicture { get; set; }
    }
}

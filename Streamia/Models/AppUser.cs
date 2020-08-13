using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string ProfilePicture { get; set; }
        public uint Credit { get; set; }

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
    }

}

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
        public uint Credit { get; set; }
        public bool GenerateMAG { get; set; }
        public bool GenerateEnigma { get; set; }
        public bool MAGOnly { get; set; }
        public bool EnigmaOnly { get; set; }
        public bool LockSTB { get; set; }
        public bool Restream { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class AdminUser : IdentityUser
    {
        public string Name { get; set; }

        public string ProfilePicture { get; set; }
    }

}

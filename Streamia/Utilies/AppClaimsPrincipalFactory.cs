using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Streamia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Streamia.Utilies
{
    public class AppClaimsPrincipalFactory : UserClaimsPrincipalFactory<AdminUser, IdentityRole>
    {

        public AppClaimsPrincipalFactory(
            UserManager<AdminUser> userManager
            , RoleManager<IdentityRole> roleManager
            , IOptions<IdentityOptions> optionsAccessor)
        : base(userManager, roleManager, optionsAccessor)
        { }
        public async override Task<ClaimsPrincipal> CreateAsync(AdminUser user)
        {
            var principal = await base.CreateAsync(user);

            if (!string.IsNullOrWhiteSpace(user.Name))
            {
                ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
                new Claim("Name", user.Name.ToString())
                });
            }

            if (!string.IsNullOrWhiteSpace(user.ProfilePicture))
            {
                ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
                new Claim("ProfilePicture", user.ProfilePicture.ToString())
                });
            }

            return principal;
        }
    }
}

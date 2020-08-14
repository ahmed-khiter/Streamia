using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Streamia.Security
{
    public static class IdentityExtensions
    {
        public static string Name(this IIdentity identity)
        {
            var claim = ( (ClaimsIdentity) identity).FindFirst("Name");
            return claim.Value ?? string.Empty;
        }
    }
}

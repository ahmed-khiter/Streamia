using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Streamia.Security
{
    public class CanCreateSubResellerHandler : AuthorizationHandler<BuildingEntryRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            BuildingEntryRequirement requirement)
        {
            var authFilterContext = context.Resource as AuthorizationFilterContext;

            if(authFilterContext == null)
            {
                return Task.CompletedTask;
            }

            string loggedInAdminOrReseller = context.User.Claims.
                    FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            string adminOrResellerId = authFilterContext.HttpContext.Request.Query["Id"];

            if (loggedInAdminOrReseller.ToLower() == loggedInAdminOrReseller.ToLower())
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}

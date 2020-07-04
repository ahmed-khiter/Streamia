using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Streamia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void ConfigRelationships(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SourceServers>().HasKey(m => new { m.SourceId, m.ServerId });
            modelBuilder.Entity<BouquetSources>().HasKey(m => new { m.SourceId, m.BouquetId });
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (roleManager.FindByNameAsync("Admin").Result == null
                || roleManager.FindByNameAsync("Reseller").Result == null)
            {
                IdentityRole identityRoleAdmin = new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                };
                roleManager.CreateAsync(identityRoleAdmin).Wait();
                IdentityRole identityRoleCompany = new IdentityRole
                {
                    Name = "Reseller",
                    NormalizedName = "RESELLER"
                };
                roleManager.CreateAsync(identityRoleCompany).Wait();
            }
        }

        public static void SeedUsers(UserManager<AdminUser> userManager)
        {
            if (userManager.FindByEmailAsync("dev@streamia.com").Result == null)
            {
                Guid g = Guid.NewGuid();
                string GuidString = Convert.ToBase64String(g.ToByteArray());
                GuidString = GuidString.Replace("=", "");
                GuidString = GuidString.Replace("+", "");

                var user = new AdminUser
                {
                    Id = GuidString,
                    UserName = "dev@streamia.com",
                    Email = "dev@streamia.com",

                    EmailConfirmed = true,
                  
                    NormalizedEmail = "DEV@STREAMIA.COM",
                    NormalizedUserName = "DEV@STREAMIA.COM",
                    PhoneNumberConfirmed = true,
                    PhoneNumber = "0123456789",

                };
                IdentityResult result = userManager.CreateAsync(user, "Streamia0123456789").Result;
                if (result.Succeeded)
                {
                     userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}

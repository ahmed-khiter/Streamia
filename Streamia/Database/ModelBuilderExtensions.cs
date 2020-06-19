using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Streamia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Database
{
    public static class ModelBuilderExtensions
    {
        public static void ConfigRelationships(this ModelBuilder modelBuilder)
        {

            //config manual M-T-M relationship between stream and bouquet
            modelBuilder.Entity<BouquetSource>()
                 .HasOne(bs => bs.Bouquet)
                 .WithMany(b => b.BouquetSources)
                 .HasForeignKey(bs => bs.BouquetId);

            modelBuilder.Entity<BouquetSource>()
                .HasOne(bs => bs.Stream)
                .WithMany(b => b.BouquetSources)
                .HasForeignKey(bs => bs.StreamId);


            //config manual M-T-M relationship between Channel and bouquet
            modelBuilder.Entity<BouquetSource>()
                .HasOne(bs => bs.Channel)
                .WithMany(b => b.BouquetSources)
                .HasForeignKey(bs => bs.ChannelId);

            //config manual M-T-M relationship between Movie and bouquet
            modelBuilder.Entity<BouquetSource>()
               .HasOne(bs => bs.Movie)
               .WithMany(b => b.BouquetSources)
               .HasForeignKey(bs => bs.MovieId);

            //config manual M-T-M relationship between Series and bouquet
            modelBuilder.Entity<BouquetSource>()
                .HasOne(bs => bs.Series)
                .WithMany(s => s.BouquetSources)
                .HasForeignKey(bs => bs.SeriesId);
        }

        public static async void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (await roleManager.FindByNameAsync("Admin") == null
                || await roleManager.FindByNameAsync("Company") == null)
            {
                IdentityRole identityRoleAdmin = new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                };
                await roleManager.CreateAsync(identityRoleAdmin);
                IdentityRole identityRoleCompany = new IdentityRole
                {
                    Name = "Company",
                    NormalizedName = "COMPANY"
                };
                await roleManager.CreateAsync(identityRoleCompany);
            }
        }

        public static async void SeedUsers(UserManager<IdentityUser> userManager)
        {

            if (await userManager.FindByEmailAsync("Ahmed@gmail.com") == null)
            {
                Guid g = Guid.NewGuid();
                string GuidString = Convert.ToBase64String(g.ToByteArray());
                GuidString = GuidString.Replace("=", "");
                GuidString = GuidString.Replace("+", "");

                var user = new IdentityUser
                {

                    Id = GuidString,
                    UserName = "Ahmed@gmail.com",
                    Email = "Ahmed@gmail.com",

                    EmailConfirmed = true,
                  
                    NormalizedEmail = "AHMED@GMAIL.COM",
                    NormalizedUserName = "AHMED@GMAIL.COM",
                    PhoneNumberConfirmed = true,
                    PhoneNumber = "01100811024",

                };
                IdentityResult result = await userManager.CreateAsync(user, "qaz2wsxedc");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}

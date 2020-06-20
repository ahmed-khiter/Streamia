﻿using Microsoft.AspNetCore.Identity;
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

            if (userManager.FindByEmailAsync("Ahmed@gmail.com").Result == null)
            {
                Guid g = Guid.NewGuid();
                string GuidString = Convert.ToBase64String(g.ToByteArray());
                GuidString = GuidString.Replace("=", "");
                GuidString = GuidString.Replace("+", "");

                var user = new AdminUser
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
                IdentityResult result = userManager.CreateAsync(user, "qaz2wsxedc").Result;
                if (result.Succeeded)
                {
                     userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}

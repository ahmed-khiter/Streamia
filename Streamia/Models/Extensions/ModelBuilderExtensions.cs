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
            // stream servers
            modelBuilder.Entity<StreamServer>().HasKey(m => new { m.StreamId, m.ServerId });
            modelBuilder.Entity<StreamServer>().Ignore(m => m.Id);

            modelBuilder.Entity<StreamServer>()
                .HasOne(ss => ss.Stream)
                .WithMany(ss => ss.StreamServers)
                .HasForeignKey(ss => ss.StreamId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StreamServer>()
                .HasOne(ss => ss.Server)
                .WithMany(ss => ss.StreamServers)
                .HasForeignKey(ss => ss.ServerId)
                .OnDelete(DeleteBehavior.NoAction);

            // bouquet streams
            modelBuilder.Entity<BouquetStream>().HasKey(m => new { m.BouquetId, m.StreamId });
            modelBuilder.Entity<BouquetStream>().Ignore(m => m.Id);

            modelBuilder.Entity<BouquetStream>()
                .HasOne(ss => ss.Bouquet)
                .WithMany(ss => ss.BouquetStreams)
                .HasForeignKey(ss => ss.BouquetId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BouquetStream>()
                .HasOne(ss => ss.Stream)
                .WithMany(ss => ss.BouquetStreams)
                .HasForeignKey(ss => ss.StreamId)
                .OnDelete(DeleteBehavior.NoAction);

            // stream server pids (process ids)
            modelBuilder.Entity<StreamServerPid>().HasKey(m => new { m.StreamId, m.ServerId });
            modelBuilder.Entity<StreamServerPid>().Ignore(m => m.Id);

            modelBuilder.Entity<StreamServerPid>()
                .HasOne(ssp => ssp.Stream)
                .WithMany(ssp => ssp.StreamServerPids)
                .HasForeignKey(ssp => ssp.StreamId);

            modelBuilder.Entity<StreamServerPid>()
                .HasOne(ssp => ssp.Server)
                .WithMany(ssp => ssp.StreamServerPids)
                .HasForeignKey(ssp => ssp.ServerId);
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (roleManager.FindByNameAsync("Admin").Result == null
                || roleManager.FindByNameAsync("Reseller").Result == null)
            {
                if (roleManager.FindByNameAsync("Admin").Result == null) 
                {
                    IdentityRole identityRoleAdmin = new IdentityRole
                    {
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    };
                    roleManager.CreateAsync(identityRoleAdmin).Wait();
                }
                else
                {
                    IdentityRole identityRoleCompany = new IdentityRole
                    {
                        Name = "Reseller",
                        NormalizedName = "RESELLER"
                    };
                    roleManager.CreateAsync(identityRoleCompany).Wait();
                }       
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

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Streamia.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Streamia.Models.Extensions
{
    public static class SeedDataExtensions
    {
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

        public static void SeedUsers(UserManager<AppUser> userManager)
        {
            if (userManager.FindByEmailAsync("dev@streamia.com").Result == null)
            {
                Guid guid = Guid.NewGuid();
                string guidString = Convert.ToBase64String(guid.ToByteArray());
                guidString = guidString.Replace("=", "");
                guidString = guidString.Replace("+", "");

                var user = new AppUser
                {
                    Id = guidString,
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

        public static void SeedTranscodes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transcode>().HasData(new Transcode { Id = 1, AspectRatio = "4:4:2" });
        }

        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            string[] liveCategories = new string[]
            {
                "Science",
                "Action",
                "News"
            };

            string[] moviesCategories = new string[]
            {
                "Action",
                "Adventure",
                "Comedy",
                "Crime",
                "Drama",
                "Fantasy",
                "Historical",
                "Horror",
                "Mystery",
                "Philosophical",
                "Political",
                "Saga",
                "Thriller",
                "Western",
                "Crime Thriller",
                "Disaster Thriller",
                "Psychological Thriller",
                "Techno Thriller",
                "Science Fiction",
                "Suspense",
                "Animation"
            };

            string[] seriesesCategories = new string[]
            {
                "Action",
                "Adventure",
                "Comedy",
                "Crime",
                "Drama",
                "Fantasy",
                "Historical",
                "Horror",
                "Mystery",
                "Philosophical",
                "Political",
                "Saga",
                "Thriller",
                "Western",
                "Crime Thriller",
                "Disaster Thriller",
                "Psychological Thriller",
                "Techno Thriller",
                "Science Fiction",
                "Suspense",
                "Animation",
                "Documentary",
                "Family",
                "Children",
                "Sport"
            };

            int idCounter = 1;
            List<Category> seedList = new List<Category>();

            foreach (string categoryName in liveCategories)
            {
                seedList.Add(new Category { Id = idCounter, CategoryType = CategoryType.LiveStreams, Name = categoryName });
                idCounter++;
            }

            foreach (string categoryName in moviesCategories)
            {
                seedList.Add(new Category { Id = idCounter, CategoryType = CategoryType.Movies, Name = categoryName });
                idCounter++;
            }

            foreach (string categoryName in seriesesCategories)
            {
                seedList.Add(new Category { Id = idCounter, CategoryType = CategoryType.Serieses, Name = categoryName });
                idCounter++;
            }

            modelBuilder.Entity<Category>().HasData(seedList);
        }

    }
}

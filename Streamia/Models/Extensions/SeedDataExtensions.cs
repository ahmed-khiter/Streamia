using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
                Guid g = Guid.NewGuid();
                string GuidString = Convert.ToBase64String(g.ToByteArray());
                GuidString = GuidString.Replace("=", "");
                GuidString = GuidString.Replace("+", "");

                var user = new AppUser
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

        public static void SeedTranscodes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transcode>().HasData(new Transcode { Id = 1, AspectRatio = "4:4:2" });
        }

        public static void SeedMovieCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category {Id=1, CategoryType = Enums.CategoryType.MOVIE,Name="Action"},
                new Category {Id=RandomNumberGenerator.GetInt32(2,100000), CategoryType = Enums.CategoryType.MOVIE,Name="Adventure"},
                new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.MOVIE,Name="Comedy"},
                new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.MOVIE,Name="Crime"},
                new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.MOVIE,Name="Drama"},
                new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.MOVIE,Name="Fantasy"},
                new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.MOVIE,Name="Historical"},
                new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.MOVIE,Name="Horror"},
                new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.MOVIE,Name= "Mystery" },
                new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.MOVIE,Name="philosophical"},
                new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.MOVIE,Name="political"},
                new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.MOVIE,Name="Romance"},
                new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.MOVIE,Name="saga"},
                new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.MOVIE,Name= "Thriller" },
                new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.MOVIE,Name= "Western" },
                new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.MOVIE,Name= "Crime Thriller" },
                new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.MOVIE,Name= "Disaster Thriller" },
                new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.MOVIE,Name= "Psychological Thriller" },
                new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.MOVIE,Name= "Techno Thriller" },
                new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.MOVIE, Name = "Science Fiction" },
                new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.MOVIE, Name = "Suspense" },
                new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.MOVIE, Name = "Animation" }


                );
        }

        public static void SeedSeriesCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
               new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.SERIES, Name = "Drama" },
               new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.SERIES, Name = "Action" },
               new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.SERIES, Name = "Comedy" },
               new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.SERIES, Name = "Adventure" },
               new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.SERIES, Name = "Crime" },
               new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.SERIES, Name = "Fantasy" },
               new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.SERIES, Name = "Science Fiction" },
               new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.SERIES, Name = "Suspense" },
               new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.SERIES, Name = "Thriller" },
               new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.SERIES, Name = "Horror" },
               new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.SERIES, Name = "Romance" },
               new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.SERIES, Name = "Animation" },
               new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.SERIES, Name = "Anime" },
               new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.SERIES, Name = "Mini-Series" },
               new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.SERIES, Name = "Family" },
               new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.SERIES, Name = "Historical" },
               new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.SERIES, Name = "Children" },
               new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.SERIES, Name = "Reality" },
                new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.SERIES,Name= "Mystery" },
               new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.SERIES, Name = "Documentary" },
               new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.SERIES, Name = "political" },
               new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.SERIES, Name = "Soap" },
               new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.SERIES, Name = "Sport" },
               new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.SERIES, Name = "Western" },
               new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.SERIES, Name = "saga" },
               new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.SERIES, Name = "Crime Thriller" },
               new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.SERIES, Name = "Disaster Thriller" },
               new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.SERIES, Name = "Psychological Thriller" },
               new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.SERIES, Name = "Techno Thriller" }

               );
        }

        public static void SeedLiveCategroies(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
              new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.LIVE, Name = "Science" },
              new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.LIVE, Name = "ACtion" },
              new Category {Id=RandomNumberGenerator.GetInt32(2,10000), CategoryType = Enums.CategoryType.LIVE, Name = "News" }
              );
        }
    }
}

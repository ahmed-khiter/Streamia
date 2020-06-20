using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Streamia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Database
{
    public class StreamiaContext : IdentityDbContext
    {
        public StreamiaContext (DbContextOptions<StreamiaContext> options) : base(options)
        {
        }

        public DbSet<Server> Servers { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<Stream> Streams { get; set; }
        public DbSet<Bouquet> Bouquets { get; set; }
        public DbSet<IptvUser> UsersIptv { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<BouquetSource> BouquetSources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ConfigRelationships();
           
        }

    }
}

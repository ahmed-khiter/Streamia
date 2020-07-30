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

            // movie servers
            modelBuilder.Entity<MovieServer>().HasKey(m => new { m.MovieId, m.ServerId });
            modelBuilder.Entity<MovieServer>().Ignore(m => m.Id);

            modelBuilder.Entity<MovieServer>()
                .HasOne(ss => ss.Movie)
                .WithMany(ss => ss.MovieServers)
                .HasForeignKey(ss => ss.MovieId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MovieServer>()
                .HasOne(ss => ss.Server)
                .WithMany(ss => ss.MovieServers)
                .HasForeignKey(ss => ss.ServerId)
                .OnDelete(DeleteBehavior.NoAction);

            // series servers
            modelBuilder.Entity<SeriesServer>().HasKey(m => new { m.SeriesId, m.ServerId });
            modelBuilder.Entity<SeriesServer>().Ignore(m => m.Id);

            modelBuilder.Entity<SeriesServer>()
                .HasOne(ss => ss.Series)
                .WithMany(ss => ss.SeriesServers)
                .HasForeignKey(ss => ss.SeriesId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SeriesServer>()
                .HasOne(ss => ss.Server)
                .WithMany(ss => ss.SeriesServers)
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

            // bouquet movies
            modelBuilder.Entity<BouquetMovie>().HasKey(m => new { m.BouquetId, m.MovieId });
            modelBuilder.Entity<BouquetMovie>().Ignore(m => m.Id);

            modelBuilder.Entity<BouquetMovie>()
                .HasOne(ss => ss.Bouquet)
                .WithMany(ss => ss.BouquetMovies)
                .HasForeignKey(ss => ss.BouquetId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BouquetMovie>()
                .HasOne(ss => ss.Movie)
                .WithMany(ss => ss.BouquetMovies)
                .HasForeignKey(ss => ss.MovieId)
                .OnDelete(DeleteBehavior.NoAction);

            // bouquet series
            modelBuilder.Entity<BouquetSeries>().HasKey(m => new { m.BouquetId, m.SeriesId });
            modelBuilder.Entity<BouquetSeries>().Ignore(m => m.Id);

            modelBuilder.Entity<BouquetSeries>()
                .HasOne(ss => ss.Bouquet)
                .WithMany(ss => ss.BouquetSeries)
                .HasForeignKey(ss => ss.BouquetId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BouquetSeries>()
                .HasOne(ss => ss.Movie)
                .WithMany(ss => ss.BouquetSeries)
                .HasForeignKey(ss => ss.SeriesId)
                .OnDelete(DeleteBehavior.NoAction);

            // admin setting
            modelBuilder.Entity<Setting>().HasKey(m => new { m.AdminUserId });
            modelBuilder.Entity<Setting>().Ignore(m => m.Id);

            modelBuilder.Entity<AppUser>()
                .HasOne(ss => ss.Setting)
                .WithOne(ss => ss.AdminUser)
                .HasForeignKey<Setting>(ss => ss.AdminUserId)
                .OnDelete(DeleteBehavior.NoAction);

        }  
    }
}

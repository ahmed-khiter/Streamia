using Microsoft.EntityFrameworkCore;
using Streamia.Database;
using Streamia.Models;
using Streamia.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Services
{
    public class MovieService : IGenericRepository<Movie>
    {
        private readonly StreamiaContext Context;

        public MovieService(StreamiaContext context)
        {
            Context = context;
        }
        public async Task<Movie> Add(Movie entity)
        {
            await Context.Movies.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var entity = await Context.Movies.FindAsync(id);
            if (entity != null)
            {
                Context.Movies.Remove(entity);
                await Context.SaveChangesAsync();
            }
        }

        public async Task<Movie> Edit(Movie entity)
        {
            var updateEntity = Context.Movies.Attach(entity);
            updateEntity.State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            return await Context.Movies.ToListAsync();
        }

        public async Task<Movie> GetById(int id)
        {
            var record = await Context.Movies.FirstOrDefaultAsync(s => s.Id == id);
            return record;
        }
    }
}

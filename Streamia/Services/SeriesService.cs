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
    public class SeriesService : IGenericRepository<Series>
    {
        private readonly StreamiaContext Context;

        public SeriesService(StreamiaContext context)
        {
            Context = context;
        }
        public async Task<Series> Add(Series entity)
        {
            await Context.Series.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var entity = await Context.Series.FindAsync(id);
            if (entity != null)
            {
                Context.Series.Remove(entity);
                await Context.SaveChangesAsync();
            }
        }

        public async Task<Series> Edit(Series entity)
        {
            var updateEntity = Context.Series.Attach(entity);
            updateEntity.State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Series>> GetAll()
        {
            return await Context.Series.ToListAsync();
        }

        public async Task<Series> GetById(int id)
        {
            var record = await Context.Series.FirstOrDefaultAsync(s => s.Id == id);
            return record;
        }
    }
}

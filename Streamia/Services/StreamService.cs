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
    public class StreamService : IGenericRepository<Stream>
    {
        private readonly StreamiaContext Context;

        public StreamService(StreamiaContext context)
        {
            Context = context;
        }

        public async Task<Stream> Add(Stream entity)
        {
            await Context.Streams.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var entity = await Context.Streams.FindAsync(id);
            if (entity != null)
            {
                Context.Streams.Remove(entity);
                await Context.SaveChangesAsync();
            }
        }

        public async Task<Stream> Edit(Stream entity)
        {
            var updateEntity = Context.Streams.Attach(entity);
            updateEntity.State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Stream>> GetAll()
        {
            return await Context.Streams.ToListAsync();
        }

        public async Task<Stream> GetById(int id)
        {
            var record = await Context.Streams.FirstOrDefaultAsync(s => s.Id == id);
            return record;
        }
    }
}

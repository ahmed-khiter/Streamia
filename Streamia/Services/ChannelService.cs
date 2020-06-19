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
    public class ChannelService : IGenericRepository<Channel>
    {
        private readonly StreamiaContext Context;

        public ChannelService(StreamiaContext context)
        {
            Context = context;
        }
        public async Task<Channel> Add(Channel entity)
        {
            await Context.Channels.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var entity = await Context.Bouquets.FindAsync(id);
            if (entity != null)
            {
                Context.Bouquets.Remove(entity);
                await Context.SaveChangesAsync();
            }
        }

        public async Task<Channel> Edit(Channel entity)
        {
            var updateEntity = Context.Channels.Attach(entity);
            updateEntity.State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Channel>> GetAll()
        {
            return await Context.Channels.ToListAsync();
        }

        public async Task<Channel> GetById(int id)
        {
            var record = await Context.Channels.FirstOrDefaultAsync(s => s.Id == id);
            return record;
        }
    }
}

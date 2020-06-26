using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Streamia.Repositories;
using Streamia.Models;
using Streamia.Database;
using Microsoft.EntityFrameworkCore;

namespace Streamia.Services
{
    public class ServerService : IServer<Server>
    {
        private readonly StreamiaContext Context;

        public ServerService(StreamiaContext context)
        {
            Context = context;
        }

        public async Task<Server> Add(Server entity)
        {
            await Context.Servers.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var entity = await Context.Servers.FindAsync(id);
            if (entity != null)
            {
                Context.Servers.Remove(entity);
                await Context.SaveChangesAsync();
            }
        }

        public async Task<Server> Edit(Server entity)
        {
            var updateEntity = Context.Servers.Attach(entity);
            updateEntity.State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Server>> GetAll()
        {
            return await Context.Servers.ToListAsync();
        }

        public async Task<IEnumerable<Server>> GetAllActive()
        {
            return await Context.Servers.Where(s => s.State == State.ONLINE).ToListAsync();
        }

        public async Task<Server> GetById(int id)
        {
            var record = await Context.Servers.FirstOrDefaultAsync(s => s.Id == id);
            return record;
        }

        public async Task<IEnumerable<Server>> Search(string keyword)
        {
            var record = await Context.Servers.Where(s => s.Name.Contains(keyword) || s.Ip.Contains(keyword)).ToListAsync();
            return record;
        }
    }
}

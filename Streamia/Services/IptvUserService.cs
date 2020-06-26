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
    public class IptvUserService : IIptvUser<IptvUser>
    {
        private readonly StreamiaContext Context;
        public IptvUserService(StreamiaContext Context)
        {
            this.Context = Context;
        }
        public async Task<IptvUser> Add(IptvUser entity)
        {
            await Context.IptvUsers.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            Context.IptvUsers.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task<IptvUser> Edit(IptvUser entity)
        {
            Context.IptvUsers.Update(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<IptvUser>> GetAll()
        {
            return await Context.IptvUsers.Include(u => u.Bouquet).ToListAsync();
        }

        public async Task<IptvUser> GetById(int id)
        {
            return await Context.IptvUsers.FirstOrDefaultAsync(item => item.Id == id);
        }

        public async Task<IEnumerable<IptvUser>> Search(string keyword)
        {
            var record = await Context.IptvUsers.Where(u => u.Username.Contains(keyword)).Include(u => u.Bouquet).ToListAsync();
            return record;
        }
    }
}

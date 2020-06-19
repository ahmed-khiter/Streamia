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
    public class IptvUserService : IGenericRepository<IptvUser>
    {
        private readonly StreamiaContext Context;
        public IptvUserService(StreamiaContext Context)
        {
            this.Context = Context;
        }
        public async Task<IptvUser> Add(IptvUser entity)
        {
            await Context.UsersIptv.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            Context.UsersIptv.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task<IptvUser> Edit(IptvUser entity)
        {
            Context.UsersIptv.Update(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<IptvUser>> GetAll()
        {
            return await Context.UsersIptv.ToListAsync();
        }

        public async Task<IptvUser> GetById(int id)
        {
            return await Context.UsersIptv.FirstOrDefaultAsync(item => item.Id == id);
        }
    }
}

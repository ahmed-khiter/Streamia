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
    public class BouquetSourceService : IGenericRepository<BouquetSource>
    {
        private readonly StreamiaContext Context;

        public BouquetSourceService(StreamiaContext context)
        {
            Context = context;
        }
        public async Task<BouquetSource> Add(BouquetSource entity)
        {
            await Context.BouquetSources.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var entity = await Context.BouquetSources.FindAsync(id);
            if (entity != null)
            {
                Context.BouquetSources.Remove(entity);
                await Context.SaveChangesAsync();
            }
        }

        public async Task<BouquetSource> Edit(BouquetSource entity)
        {
            var updateEntity = Context.BouquetSources.Attach(entity);
            updateEntity.State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<BouquetSource>> GetAll()
        {
            return await Context.BouquetSources.ToListAsync();
        }

        public async Task<BouquetSource> GetById(int id)
        {
            var record = await Context.BouquetSources.FirstOrDefaultAsync(s => s.Id == id);
            return record;
        }
    }
}

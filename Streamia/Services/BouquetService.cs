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
    public class BouquetService : IGenericRepository<Bouquet>
    {
        private readonly StreamiaContext Context;

        public BouquetService(StreamiaContext context)
        {
            Context = context;
        }

        public async Task<Bouquet> Add(Bouquet entity)
        {
            await Context.Bouquets.AddAsync(entity);
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

        public async Task<Bouquet> Edit(Bouquet entity)
        {
            var updateEntity = Context.Bouquets.Attach(entity);
            updateEntity.State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Bouquet>> GetAll()
        {
            return await Context.Bouquets.ToListAsync();
        }

        public async Task<Bouquet> GetById(int id)
        {
            var record = await Context.Bouquets.FirstOrDefaultAsync(s => s.Id == id);
            return record;
        }
    }
}

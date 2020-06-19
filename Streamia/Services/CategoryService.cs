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
    public class CategoryService : ICategoryRepository<Category>
    {
        private readonly StreamiaContext Context;

        public CategoryService(StreamiaContext context)
        {
            Context = context;
        }
        public async Task<Category> Add(Category entity)
        {
            await Context.Categories.AddAsync(entity);
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

        public async Task<Category> Edit(Category entity)
        {
            var updateEntity = Context.Categories.Attach(entity);
            updateEntity.State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await Context.Categories.ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            var record = await Context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            return record;
        }

        public async Task<IEnumerable<Category>> GetByType(CategoryType type)
        {
            var record = await Context.Categories.Where(c => c.CategoryType == type).ToListAsync();
            return record;
        }
    }
}

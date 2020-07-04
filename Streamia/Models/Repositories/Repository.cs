using Microsoft.EntityFrameworkCore;
using Streamia.Models.Contexts;
using Streamia.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Streamia.Models.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly StreamiaContext context;
        private DbSet<T> entitySet;

        public Repository(StreamiaContext context)
        {
            this.context = context;
            entitySet = context.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            entitySet.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var entity = await entitySet.FirstOrDefaultAsync(e => e.Id == id);
            if (entity != null)
            {
                entitySet.Remove(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<T> Edit(T entity)
        {
            entitySet.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await entitySet.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllIncluding(string model)
        {
            return await entitySet.Include(model).ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await entitySet.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<T>> Search(Expression<Func<T, bool>> expression)
        {
            return await entitySet.Where(expression).ToListAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Repositories
{
    public interface IGenericRepository<TEntity>
    {
        public Task<TEntity> GetById(int id);

        public Task<IEnumerable<TEntity>> GetAll();

        public Task<TEntity> Add(TEntity entity);

        public Task<TEntity> Edit(TEntity entity);

        public Task Delete(int id);
    }
}

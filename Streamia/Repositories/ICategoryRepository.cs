using Streamia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Repositories
{
    public interface ICategoryRepository<TEntity> : IGenericRepository<TEntity>, ISearch<TEntity>
    {
        Task<IEnumerable<Category>> GetByType(CategoryType type);
    }
}

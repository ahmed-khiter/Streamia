using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Repositories
{
    public interface IBouquet<TEntity> : IGenericRepository<TEntity>, ISearch<TEntity>
    {
    }
}

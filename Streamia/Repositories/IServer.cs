using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Repositories
{
    public interface IServer<TEntity> : IGenericRepository<TEntity>, ISearch<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllActive();
    }
}

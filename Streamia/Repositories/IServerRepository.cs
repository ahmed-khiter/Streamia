using Streamia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Repositories
{
    public interface IServerRepository<TEntity> : IGenericRepository<TEntity>
    {
        Task<IEnumerable<Server>> GetAllActive();
    }
}

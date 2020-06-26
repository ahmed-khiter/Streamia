using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Repositories
{
    public interface ISearch<TEntity>
    {
        public Task<IEnumerable<TEntity>> Search(string keyword);
    }
}

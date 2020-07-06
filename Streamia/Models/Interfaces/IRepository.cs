using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Streamia.Models.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAll(string[] models);
        Task<T> GetById(int id);
        Task<T> Add(T entity);
        Task<T> Edit(T entity);
        Task Delete(int id);
        Task<IEnumerable<T>> Search(Expression<Func<T, bool>> expression);
    }
}

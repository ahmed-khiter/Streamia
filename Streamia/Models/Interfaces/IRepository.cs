using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Streamia.Models.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> Add(T entity);
        Task<IEnumerable<T>> Add(IEnumerable<T> entities);
        Task<T> Edit(T entity);
        Task<IEnumerable<T>> Edit(IEnumerable<T> entities);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAll(string[] models);
        Task<T> GetById(uint id);
        Task<T> GetById(uint id, string[] models);
        Task Delete(uint id);
        Task Delete(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> Search(Expression<Func<T, bool>> expression);
        Task<bool> Exists(Expression<Func<T, bool>> expression);
    }
}

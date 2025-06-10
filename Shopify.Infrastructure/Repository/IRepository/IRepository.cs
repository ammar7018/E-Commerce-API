using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Supliex.Infrastructure.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProp = null, bool tracked = false);
        Task<T?> GetAsync(Expression<Func<T, bool>> filter, string? includeProp = null, bool tracked = false);

        Task AddAsync(T obj);
        Task RemoveAsync(T obj);
        Task RemoveRangeAsync(IEnumerable<T> obj);
    }
}

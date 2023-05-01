using MusicMarket.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicMarket.Core.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        //getallasync - Find - singleOrDefaultAsync -addasync -addrangeasync - remove -removeranga
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        Task<T> SingleOrDefaultAsync(Expression<Func<T,bool>> predicate);
        Task AddAsync(T Entity);
        Task AddRangeAsync(IEnumerable<T> Entity);
        void Remove(T Entity);
        void RemoveRange(T Entity);
        void Update(T Entity,int id);
    }
}

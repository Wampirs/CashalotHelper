using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CashalotHelper.Data.Interfaces
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        public IQueryable<T> Items { get; }

        public T Get(Guid id);
        public Task<T> GetAsync(Guid id, CancellationToken cancel = default);
        public T Add(T item);
        public Task<T> AddAsync(T item, CancellationToken cancel = default);
        public T Update(T item);
        public Task<T> UpdateAsync(T item, CancellationToken cancel = default);
        public bool Remove(Guid id);
        public Task<bool> RemoveAsync(Guid id, CancellationToken cancel = default);
    }

}

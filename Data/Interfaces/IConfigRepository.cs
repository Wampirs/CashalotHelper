using CashalotHelper.Data.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CashalotHelper.Data.Interfaces
{
    public interface IConfigRepository<T>
    {
        public IQueryable<T> Configs { get; }

        public T Get(string paramName);
        public Task<T> GetAsync(string paramName, CancellationToken cancel);

        public T UpdateOrCreate(Configuration conf);
        public Task<T> UpdateOrCreateAsync(Configuration conf, CancellationToken cancel);

    }
}

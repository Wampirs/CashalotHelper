using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CashalotHelper.Data.Entities.Base;
using CashalotHelper.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CashalotHelper.Data
{
    public class DbRepository<T> : IRepository<T> where T : Entity,new()
    {
        private readonly HelperDb _db;
        private readonly DbSet<T> _set;
        public IQueryable<T> Items => _set;
        public bool AutoSave { get; set; } = true;

        public DbRepository(HelperDb db)
        {
            _db = db;
            _set = _db.Set<T>();
        }
        public T Get(Guid id)
        {
            return Items.SingleOrDefault(x => x.Id == id);
        }

        public async Task<T> GetAsync(Guid id, CancellationToken cancel = default)
        {
            return await Items.SingleOrDefaultAsync(x => x.Id == id,cancel).ConfigureAwait(false);
        }

        public T Add(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Added;
            if (AutoSave)_db.SaveChanges();
            return item;
        }

        public async Task<T> AddAsync(T item, CancellationToken cancel = default)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Added;
            if (AutoSave) await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
            return item;
        }

        public T Update(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (item == null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Modified;
            if (AutoSave) _db.SaveChanges();
            return item;
        }

        public async Task<T> UpdateAsync(T item, CancellationToken cancel = default)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Added;
            if (AutoSave) await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
            return item;
        }

        public bool Remove(Guid id)
        {
            var item = Get(id);
            if (item == null) return false;
            _db.Remove(item);
            if (AutoSave) _db.SaveChanges();
            return true;
        }

        public async Task<bool> RemoveAsync(Guid id, CancellationToken cancel = default)
        {
            var item = await GetAsync(id, cancel).ConfigureAwait(false);
            if (item == null) return false;
            _db.Remove(item);
            if(AutoSave) await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
            return true;
        }
    }
}

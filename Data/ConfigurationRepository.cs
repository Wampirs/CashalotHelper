﻿using CashalotHelper.Data.Entities;
using CashalotHelper.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CashalotHelper.Data
{
    public class ConfigurationRepository<T> : IConfigRepository<Configuration>
    {
        private readonly HelperDb _db;
        private readonly DbSet<Configuration> _set;
        public IQueryable<Configuration> Configs => _set;

        public ConfigurationRepository(HelperDb db)
        {
            _db = db;
            _set = _db.Set<Configuration>();
        }



        public Configuration Get(string paramName)
        {
            return Configs.SingleOrDefault(x=>x.Property == paramName);
        }

        public async Task<Configuration> GetAsync(string paramName, CancellationToken cancel = default)
        {
            return await Configs.SingleOrDefaultAsync(x => x.Property == paramName).ConfigureAwait(false);
        }

        public Configuration UpdateOrCreate(string paramName)
        {
            Configuration config = Get(paramName);
            _db.Entry(config).State = EntityState.Modified;
            _db.SaveChanges();
            return config;
        }

        public async Task<Configuration> UpdateOrCreateAsync(string paramName, CancellationToken cancel = default)
        {
            Configuration config = await GetAsync(paramName);
            _db.Entry(config).State = EntityState.Modified;
            await _db.SaveChangesAsync().ConfigureAwait(false);
            return config;
        }
    }
}

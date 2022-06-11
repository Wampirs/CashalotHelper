using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashalotHelper.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CashalotHelper.Data
{
    internal class DbInitializer
    {
        private readonly HelperDb _db;
        private readonly ILogger<DbInitializer> _logger;

        public DbInitializer( HelperDb db,ILogger<DbInitializer> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task InitializeAsync()
        {
            await _db.Database.MigrateAsync().ConfigureAwait(false);

            await _db.Backups.AddAsync(new Backup()
            {
                Note = "Some Note",
                Name = "Some Name",
                CreateDate = DateTime.Now,
                FileCount = 12,
                Path = "Some Path",
                Version = "Some Version"
            });
            await _db.SaveChangesAsync();
        }
    }
}

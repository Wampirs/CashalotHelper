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

            await _db.CashalotBranches.AddAsync(new CashalotBranch()
            {
                Note = "Some Note",
                Name = "Some Name",
                LocalFolderPath = "SomeFolder",
                LocalBatFile = "SomeBat",
                LocalExeFile = "Some Exe",
                RemoteFolderPath = "SomeRemote",
                Version = "Some Version"
            });
            await _db.SaveChangesAsync();
        }
    }
}

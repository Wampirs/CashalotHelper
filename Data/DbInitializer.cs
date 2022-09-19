using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CashalotHelper.Data
{
    internal class DbInitializer
    {
        private readonly HelperDb _db;
        private readonly ILogger<DbInitializer> _logger;

        public DbInitializer(HelperDb db, ILogger<DbInitializer> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task InitializeAsync()
        {
            await _db.Database.MigrateAsync().ConfigureAwait(false);

        }
    }
}

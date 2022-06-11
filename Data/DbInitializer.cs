using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void Initialize()
        {
            _db.Database.Migrate();
        }
    }
}

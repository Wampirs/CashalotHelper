using CashalotHelper.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashalotHelper.Data
{
    internal class HelperDb : DbContext
    {
        public DbSet<Backup> Backups { get; set; }
        public HelperDb(DbContextOptions<HelperDb> options) : base(options) { }
    }
}

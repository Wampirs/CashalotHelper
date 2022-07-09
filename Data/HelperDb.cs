using CashalotHelper.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashalotHelper.Data
{
    public class HelperDb : DbContext
    {
        public DbSet<Backup> Backups { get; set; }

        public DbSet<Configuration> Configs { get; set; }
        public DbSet<CashalotBranch> CashalotBranches { get; set; }
        public HelperDb(DbContextOptions<HelperDb> options) : base(options) { }
    }
}

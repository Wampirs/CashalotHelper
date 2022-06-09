using System.Data.Entity;
using CashalotHelper.Models;

namespace CashalotHelper.Services;

public class DbService : DbContext
{
    public DbService() : base("DefaultConnection")
    {
    }

    public DbSet<Backup> Backups { get; set; }
}
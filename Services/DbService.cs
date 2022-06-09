using CashalotHelper.Models;
using Microsoft.EntityFrameworkCore;

namespace CashalotHelper.Services;

public class DbService : DbContext
{
    public DbService()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=CashalotHelper.db");
    }

    public DbSet<Backup> Backups { get; set; }
}
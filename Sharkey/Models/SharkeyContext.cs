using Microsoft.EntityFrameworkCore;


namespace Sharkey.Models;

public class SharkeyContext : DbContext
{
    public DbSet<Profile> Profiles { get; set; }
    // public DbSet<Profile> Profiles => Set<Profile>();
    // public SharkeyContext(): base("DefaultConnection") { }

    public SharkeyContext()
    {
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=SharkeyDB.db");
    }

    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Profile>().HasNoKey();
    }
}
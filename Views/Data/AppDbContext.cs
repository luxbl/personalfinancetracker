using Microsoft.EntityFrameworkCore;
using personalfinancetracker.Models;

namespace personalfinancetracker.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Income> Incomes { get; set; }
    public DbSet<Expense> Expenses { get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Optional: Configure table name, primary key, or other constraints
        modelBuilder.Entity<Income>().ToTable("Incomes");
    }
}

public class IdentityDbContext<T>
{
}
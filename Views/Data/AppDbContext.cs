using Microsoft.EntityFrameworkCore;
using personalfinancetracker.Models;

namespace personalfinancetracker.Data;


/*{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : base(options) // Corrected class declaration
    {

        // You can add DbSet properties here for your models
        public required DbSet<Income> Incomes { get; set; }
        public required DbSet<Expense> Expenses { get; set; }
    }
}*/
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

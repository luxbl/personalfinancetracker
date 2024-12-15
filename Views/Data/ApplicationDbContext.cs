using Microsoft.EntityFrameworkCore;
using personalfinancetracker.Models;

namespace personalfinancetracker.Data
{
    
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseSqlServer("Server=localhost:5003;Database=PersonalFinanceDB;User Id=sa;Password=YourStrongPassword123!;Trusted_Connection=True;MultipleActiveResultSets=true");
}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Expense>()
        .Property(e => e.Amount)
        .HasPrecision(18, 2); // Precision of 18, scale of 2

    modelBuilder.Entity<Income>()
        .Property(i => i.Amount)
        .HasPrecision(18, 2); // Same for Income if applicable

    base.OnModelCreating(modelBuilder);
}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
    }
    
}



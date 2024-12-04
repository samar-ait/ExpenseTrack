using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackAPI.Models
{
    public class ExpenseContext : DbContext
    {
        public ExpenseContext(DbContextOptions<ExpenseContext> options) : base(options) { }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure decimal precision and scale
            modelBuilder.Entity<Expense>()
                .Property(e => e.Amount)
                .HasColumnType("decimal(18,2)"); // 18 digits, 2 decimal places

            modelBuilder.Entity<Budget>()
                .Property(b => b.CurrentSpent)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Budget>()
                .Property(b => b.MonthlyLimit)
                .HasColumnType("decimal(18,2)");

            base.OnModelCreating(modelBuilder);
        }
    }
}

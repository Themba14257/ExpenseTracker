using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Data
{
    public class ExpenseTrackerDBContext : DbContext
    {

        public ExpenseTrackerDBContext()
        {

        }
        public ExpenseTrackerDBContext(DbContextOptions<ExpenseTrackerDBContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        internal void SavedChanges()
        {
            throw new NotImplementedException();
        }

        public virtual DbSet<ExpenseReport> ExpenseReport { get; set; }
    }
}

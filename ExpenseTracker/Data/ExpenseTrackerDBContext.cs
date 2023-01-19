using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Data
{
    public class ExpenseTrackerDBContext : DbContext
    {

     
        //public ExpenseTrackerDBContext(DbContextOptions<ExpenseTrackerDBContext> options) : base(options)
        //{

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=LAPTOP-HI46GTPB\\SQLEXPRESS;Initial Catalog=ExpenseDb;Integrated Security=true;Encrypt=false;MultipleActiveResultSets=true");
            }
        }

        internal void SavedChanges()
        {
            throw new NotImplementedException();
        }

        public virtual DbSet<ExpenseReport> ExpenseReport { get; set; }
    }
}

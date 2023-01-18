using ExpenseTracker.Data;

namespace ExpenseTracker.Models
{
    public class ExpenseDataAccessLayer
    {
        ExpenseTrackerDBContext dBContext = new ExpenseTrackerDBContext();

        public IEnumerable<ExpenseReport> GetAllExpense()
        {
            try
            {
                return dBContext.ExpenseReport.ToList();
            }
            catch
            {
                throw;
            }
        }
        public IEnumerable<ExpenseReport> GetResultBySearching(string searchString)
        {
            List<ExpenseReport> expense = new List<ExpenseReport>();
            try
            {
                expense = GetAllExpense().ToList(); 
                return expense.Where(e => e.itemName.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) != -1);
            }
            catch
            {
                throw;
            }
        }
        public void AddExpense(ExpenseReport ex)
        {
            try
            {
                dBContext.ExpenseReport.Add(ex);
                dBContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public int UpdateExpense(ExpenseReport ex)
        {
            try
            {
                dBContext.Entry(ex).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                dBContext.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }
        public ExpenseReport RetrieveExpenseById(int id)
        {
            try
            {
                ExpenseReport expense = dBContext.ExpenseReport.Find(id);
                return expense;
            }
            catch
            {
                throw;
            }
        }
        public void DeleteExpense(int id)
        {
            try
            {
                ExpenseReport emp = dBContext.ExpenseReport.Find(id);
                dBContext.ExpenseReport.Remove(emp);
                dBContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        // To calculate last six months expense  
        public Dictionary<string, decimal> CalculateMonthlyExpense()
        {
            ExpenseTrackerDBContext objexpense = new ExpenseTrackerDBContext();
            List<ExpenseReport> lstEmployee = new List<ExpenseReport>();

            Dictionary<string, decimal> dictMonthlySum = new Dictionary<string, decimal>();

            decimal foodSum = dBContext.ExpenseReport.Where
                (cat => cat.Category == "Food" && (cat.expenseDate > DateTime.Now.AddMonths(-7)))
                .Select(cat => cat.price)
                .Sum();

            decimal shoppingSum = dBContext.ExpenseReport.Where
               (cat => cat.Category == "Shopping" && (cat.expenseDate > DateTime.Now.AddMonths(-7)))
               .Select(cat => cat.price)
               .Sum();

            decimal travelSum = dBContext.ExpenseReport.Where
               (cat => cat.Category == "Travel" && (cat.expenseDate > DateTime.Now.AddMonths(-7)))
               .Select(cat => cat.price)
               .Sum();

            decimal healthSum = dBContext.ExpenseReport.Where
               (cat => cat.Category == "Health" && (cat.expenseDate > DateTime.Now.AddMonths(-7)))
               .Select(cat => cat.price)
               .Sum();

            dictMonthlySum.Add("Food", foodSum);
            dictMonthlySum.Add("Shopping", shoppingSum);
            dictMonthlySum.Add("Travel", travelSum);
            dictMonthlySum.Add("Health", healthSum);

            return dictMonthlySum;
        }

        // To calculate last four weeks expense  
        public Dictionary<string, decimal> CalculateWeeklyExpense()
        {
            ExpenseTrackerDBContext objexpense = new ExpenseTrackerDBContext();
            List<ExpenseReport> lstEmployee = new List<ExpenseReport>();

            Dictionary<string, decimal> dictWeeklySum = new Dictionary<string, decimal>();

            decimal foodSum = dBContext.ExpenseReport.Where
                (cat => cat.Category == "Food" && (cat.expenseDate > DateTime.Now.AddDays(-7)))
                .Select(cat => cat.price)
                .Sum();

            decimal shoppingSum = dBContext.ExpenseReport.Where
               (cat => cat.Category == "Shopping" && (cat.expenseDate > DateTime.Now.AddDays(-28)))
               .Select(cat => cat.price)
               .Sum();

            decimal travelSum = dBContext.ExpenseReport.Where
               (cat => cat.Category == "Travel" && (cat.expenseDate > DateTime.Now.AddDays(-28)))
               .Select(cat => cat.price)
               .Sum();

            decimal healthSum = dBContext.ExpenseReport.Where
               (cat => cat.Category == "Health" && (cat.expenseDate > DateTime.Now.AddDays(-28)))
               .Select(cat => cat.price)
               .Sum();

            dictWeeklySum.Add("Food", foodSum);
            dictWeeklySum.Add("Shopping", shoppingSum);
            dictWeeklySum.Add("Travel", travelSum);
            dictWeeklySum.Add("Health", healthSum);

            return dictWeeklySum;
        }

    }
}

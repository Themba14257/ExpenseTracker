using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    public class ExpenseController : Controller
    {
        ExpenseDataAccessLayer objEx = new ExpenseDataAccessLayer();

        public IActionResult Index(string SearchString)
        {
            List<ExpenseReport> lstEmployee = new List<ExpenseReport>();
            lstEmployee = objEx.GetAllExpense().ToList();

            if (!string.IsNullOrEmpty(SearchString))
            {
                lstEmployee = objEx.GetResultBySearching(SearchString).ToList();

            }
            return View(lstEmployee);
        }

        public ActionResult AddOrEditExpense(int itemId)
        {
            ExpenseReport model = new ExpenseReport();

            if(itemId > 0)
            {
                model = objEx.RetrieveExpenseById(itemId);  
            }
            return PartialView("_expenseForm", model);
        }
        [HttpPost]
        public ActionResult Create(ExpenseReport newExpense)
        {
            if(ModelState.IsValid)
            {
                if (newExpense.itemId > 0)
                    objEx.UpdateExpense(newExpense);
                objEx.AddExpense(newExpense);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            objEx.DeleteExpense(id);
            return RedirectToAction("Index");
        }
        public ActionResult ExpenseSummary()
        {
            return PartialView("_expenseReport");
        }

        public JsonResult GetMonthlyExpense()
        {
            Dictionary<string, decimal> monthlyExpense = objEx.CalculateMonthlyExpense();
            return new JsonResult(monthlyExpense);
        }

        public JsonResult GetWeeklyExpense()
        {
            Dictionary<string, decimal> weeklyExpense = objEx.CalculateWeeklyExpense();
            return new JsonResult(weeklyExpense);
        }
    }
}

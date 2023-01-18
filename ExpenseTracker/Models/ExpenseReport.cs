using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Models
{
    public class ExpenseReport
    {
        [Key]
        public int itemId { get; set; }
        [Required]
        public string itemName { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal price { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime expenseDate { get; set; } = DateTime.Now;

        [Required]
        public string Category { get; set; }

        
    }
}

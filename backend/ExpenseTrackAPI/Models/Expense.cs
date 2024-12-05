namespace ExpenseTrackAPI.Models
{
  public class Expense
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty; // Default value
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Category { get; set; } = "Uncategorized"; // Default value
        public int? BudgetId { get; set; } // Foreign Key (Optional)
    }

}
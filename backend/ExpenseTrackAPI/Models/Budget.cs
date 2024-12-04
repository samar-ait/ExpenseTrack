namespace ExpenseTrackAPI.Models
{
    public class Budget
    {
        public int Id { get; set; }           // Unique ID for the budget
        public decimal MonthlyLimit { get; set; }  // Set the monthly limit for expenses
        public decimal CurrentSpent { get; set; }  // The amount already spent in the current month
        public decimal RemainingBudget => MonthlyLimit - CurrentSpent; // Remaining budget
    }
}

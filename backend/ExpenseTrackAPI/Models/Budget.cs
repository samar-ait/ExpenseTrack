namespace ExpenseTrackAPI.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public decimal MonthlyLimit { get; set; }  // Set the monthly limit for expenses
        public decimal CurrentSpent { get; set; } = 0;  // The amount already spent in the current month
        public string Description { get; set; } = string.Empty;

        // Progress and Remaining Budget Calculations
        public decimal RemainingBudget => MonthlyLimit - CurrentSpent;
        public double Progress => MonthlyLimit == 0 ? 0 : (double)CurrentSpent / (double)MonthlyLimit * 100;
    }
}

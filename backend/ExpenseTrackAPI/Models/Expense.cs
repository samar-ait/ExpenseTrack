namespace ExpenseTrackAPI.Models
{
    public class Expense
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty; // Default value
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Category { get; set; } = "Uncategorized"; // Default value
}

}
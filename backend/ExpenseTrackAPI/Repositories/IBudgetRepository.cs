using ExpenseTrackAPI.Models;

public interface IBudgetRepository
{
    Task<Budget> UpdateRemainingAsync(int id, decimal expenseAmount);
    Task<IEnumerable<Budget>> GetBudgetsAsync();
    Task<Budget?> GetBudgetByIdAsync(int id);
    Task<Budget> CreateBudgetAsync(Budget budget);
    Task<Budget> UpdateBudgetAsync(Budget budget);
    Task<bool> DeleteBudgetAsync(int id);
}
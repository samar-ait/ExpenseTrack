using ExpenseTrackAPI.Models;

public interface IBudgetRepository
{
    Task<IEnumerable<Budget>> GetBudgetsAsync();
    Task<Budget?> GetBudgetByIdAsync(int id);
    Task<Budget> CreateBudgetAsync(Budget budget);
    Task<Budget> UpdateBudgetAsync(Budget budget);
    Task<bool> DeleteBudgetAsync(int id);
}
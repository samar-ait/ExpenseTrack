using ExpenseTrackAPI.Models;
public interface IExpenseRepository
{
    Task<IEnumerable<Expense>> GetExpensesAsync();
    Task<Expense?> GetExpenseByIdAsync(int id);
    Task<Expense> CreateExpenseAsync(Expense expense);
    Task<Expense> UpdateExpenseAsync(Expense expense);
    Task<bool> DeleteExpenseAsync(int id);
}
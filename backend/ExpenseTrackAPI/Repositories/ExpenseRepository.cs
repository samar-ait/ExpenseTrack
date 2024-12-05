using ExpenseTrackAPI.Models;
using Microsoft.EntityFrameworkCore;

public class ExpenseRepository : IExpenseRepository
{
    private readonly ExpenseContext _context;

    public ExpenseRepository(ExpenseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Expense>> GetExpensesAsync()
    {
        return await _context.Expenses.ToListAsync();
    }

    public async Task<Expense?> GetExpenseByIdAsync(int id)
    {
        return await _context.Expenses.FindAsync(id);
    }

    public async Task<Expense> CreateExpenseAsync(Expense expense)
    {
        _context.Expenses.Add(expense);
        await _context.SaveChangesAsync();
        return expense;
    }

    public async Task<Expense> UpdateExpenseAsync(Expense expense)
    {
        var existingExpense = await _context.Expenses.FindAsync(expense.Id);
         if (existingExpense == null)
    {
        return null; 
    }
    existingExpense.Description = expense.Description;
    existingExpense.Amount = expense.Amount;
    existingExpense.Date = expense.Date;
    existingExpense.Category = expense.Category;
        _context.Expenses.Update(existingExpense);
        await _context.SaveChangesAsync();
        return existingExpense;
    }

    public async Task<bool> DeleteExpenseAsync(int id)
    {
        var expense = await _context.Expenses.FindAsync(id);
        if (expense == null) return false;

        _context.Expenses.Remove(expense);
        await _context.SaveChangesAsync();
        return true;
    }
}
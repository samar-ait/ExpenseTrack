using ExpenseTrackAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class BudgetRepository : IBudgetRepository
{
    private readonly ExpenseContext _context;

    public BudgetRepository(ExpenseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Budget>> GetBudgetsAsync()
    {
        return await _context.Budgets.ToListAsync();
    }

    public async Task<Budget?> GetBudgetByIdAsync(int id)
    {
        return await _context.Budgets.FindAsync(id);
    }

    public async Task<Budget> CreateBudgetAsync(Budget budget)
    {
        _context.Budgets.Add(budget);
        await _context.SaveChangesAsync();
        return budget;
    }

    public async Task<Budget> UpdateBudgetAsync(Budget budget)
    {
        var existingBudget = await _context.Budgets.FindAsync(budget.Id);
         if (existingBudget == null)
    {
        return null; 
    }
    existingBudget.CurrentSpent= budget.CurrentSpent;
    existingBudget.MonthlyLimit = budget.MonthlyLimit;
        _context.Budgets.Update(existingBudget);
        await _context.SaveChangesAsync();
        return existingBudget;
    }
    public async Task<bool> DeleteBudgetAsync(int id)
    {
        var budget = await _context.Budgets.FindAsync(id);
        if (budget == null)
        {
            return false;
        }

        _context.Budgets.Remove(budget);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<Budget> UpdateRemainingAsync(int id, decimal expenseAmount)
{
    var budget = await _context.Budgets.FindAsync(id);
    if (budget == null)
    {
        return null;
    }
    // Update the CurrentSpent field of the budget
    budget.CurrentSpent += expenseAmount;

    _context.Budgets.Update(budget);
    await _context.SaveChangesAsync();

    return budget;
}



    
}

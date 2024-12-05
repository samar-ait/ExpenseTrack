using ExpenseTrackAPI.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/expense")]
[ApiController]
public class ExpensesController : ControllerBase
{
    private readonly IExpenseRepository _expenseRepository;

    public ExpensesController(IExpenseRepository expenseRepository)
    {
        _expenseRepository = expenseRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Expense>>> GetExpenses()
    {
        var expenses = await _expenseRepository.GetExpensesAsync();
        return Ok(expenses);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Expense>> GetExpense(int id)
    {
        var expense = await _expenseRepository.GetExpenseByIdAsync(id);
        if (expense == null)
        {
            return NotFound();
        }
        return Ok(expense);
    }

    [HttpPost]
    public async Task<ActionResult<Expense>> CreateExpense(Expense expense)
    {
        var createdExpense = await _expenseRepository.CreateExpenseAsync(expense);
        return CreatedAtAction(nameof(GetExpense), new { id = createdExpense.Id }, createdExpense);
    }

  [HttpPut("{id}")]
public async Task<IActionResult> UpdateExpense(int id, Expense expense)
{
    if (id != expense.Id)
    {
        return BadRequest("Expense ID mismatch.");
    }

    var existingExpense = await _expenseRepository.GetExpenseByIdAsync(id);  // Use the correct method name
    if (existingExpense == null)
    {
        return NotFound();
    }

    await _expenseRepository.UpdateExpenseAsync(expense);
    return NoContent();
}

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExpense(int id)
    {
        var success = await _expenseRepository.DeleteExpenseAsync(id);
        if (!success)
        {
            return NotFound();
        }
        return NoContent();
    }
}

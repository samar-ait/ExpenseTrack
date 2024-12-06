using ExpenseTrackAPI.Models;
using Microsoft.AspNetCore.Mvc;

public class UpdateBudgetRequest
{
    public decimal ExpenseAmount { get; set; }
}

[Route("api/budget")]
[ApiController]
public class BudgetController : ControllerBase
{
    private readonly IBudgetRepository _budgetRepository;

    public BudgetController(IBudgetRepository budgetRepository)
    {
        _budgetRepository = budgetRepository;
    }

    [HttpGet]
    public async Task<ActionResult<Budget>> GetBudget()
    {
        var budget = await _budgetRepository.GetBudgetsAsync();
        if (budget == null)
        {
            return NotFound();
        }
        return Ok(budget);
    }
      [HttpGet("{id}")]
    public async Task<ActionResult<Budget>> GetBudget(int id)
    {
        var budget = await _budgetRepository.GetBudgetByIdAsync(id);
        if (budget == null)
        {
            return NotFound();
        }
        return Ok(budget);
    }
    

    [HttpPost]
    public async Task<ActionResult<Budget>> CreateBudget(Budget budget)
    {
        var createdBudget = await _budgetRepository.CreateBudgetAsync(budget);
        return CreatedAtAction(nameof(GetBudget), createdBudget);
    }
    

   // PUT api/budget/2
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBudget(int id, [FromBody] Budget budget)
    {
        if (id != budget.Id)
        {
            return BadRequest("ID mismatch");
        }

        var updatedBudget = await _budgetRepository.UpdateBudgetAsync(budget);

        if (updatedBudget == null)
        {
            return NotFound();
        }

        return Ok(updatedBudget);
    }

      [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBudget(int id)
    {
        var deleted = await _budgetRepository.DeleteBudgetAsync(id);
        return deleted ? NoContent() : NotFound();
    }

    [HttpPut("{id}/updateRemaining")]
public async Task<IActionResult> UpdateRemaining(int id, [FromBody] decimal expenseAmount)
{
    var budget = await _budgetRepository.GetBudgetByIdAsync(id);
    if (budget == null)
    {
        return NotFound();
    }

    // Add the expense amount to the current spent amount
    budget.CurrentSpent += expenseAmount;

    // Check if the total spent exceeds the monthly budget limit
    if (budget.CurrentSpent > budget.MonthlyLimit)
    {
        return BadRequest("The total expenses have exceeded the monthly budget.");
    }

    // Save the updated budget
    var updatedBudget = await _budgetRepository.UpdateBudgetAsync(budget);
    if (updatedBudget == null)
    {
        return NotFound();
    }

    return Ok(updatedBudget);
}




    
}

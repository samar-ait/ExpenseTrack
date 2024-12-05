using ExpenseTrackAPI.Models;
using Microsoft.AspNetCore.Mvc;

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
    

    [HttpPut]
    public async Task<IActionResult> UpdateBudget(Budget budget)
    {
        await _budgetRepository.UpdateBudgetAsync(budget);
        return NoContent();
    }

      [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBudget(int id)
    {
        var deleted = await _budgetRepository.DeleteBudgetAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}

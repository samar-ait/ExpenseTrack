import { Component, OnInit } from '@angular/core';
import { ExpenseService } from '../../services/expense/expense.service';
import { Expense } from '../../models/expense.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { BudgetService } from '../../services/budget/budget.service';
import { Budget } from '../../models/budget.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-expense',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule, // Add the necessary imports here
  ],
  templateUrl: './expense.component.html',
  styleUrls: ['./expense.component.scss'], // Use correct spelling (styleUrls)
})
export class ExpenseComponent implements OnInit {
  expenses: Expense[] = [];
  budgets: Budget[] = [];
  newExpense: Expense = {
    id: 0,
    description: '',
    amount: 0,
    date: new Date(),
    category: '',
    budgetId: 0,
  };
  showAddExpenseForm: boolean = false;

  constructor(
    private expenseService: ExpenseService,
    private budgetService: BudgetService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.fetchBudgets();
    this.getExpenses();
  }

  fetchBudgets() {
    this.budgetService.getBudgets().subscribe({
      next: (data) => {
        this.budgets = data;
      },
      error: (err) => {
        console.error('Error fetching budgets:', err);
        this.toastr.error('Failed to load budgets', 'Error');
      },
    });
  }

  getExpenses(): void {
    this.expenseService.getExpenses().subscribe({
      next: (data: Expense[]) => {
        this.expenses = data;
      },
      error: (err) => {
        console.error('Error fetching expenses:', err);
        this.toastr.error('Failed to load expenses', 'Error');
      },
    });
  }

  addExpense(): void {
    this.expenseService.addExpense(this.newExpense).subscribe({
      next: (expense: Expense) => {
        this.expenses.push(expense);

        // Reset the form
        this.newExpense = {
          id: 0,
          description: '',
          amount: 0,
          date: new Date(),
          category: '',
          budgetId: 0,
        };

        if (expense.budgetId) {
          this.updateBudget(expense.budgetId, expense.amount);
        }

        this.toastr.success('Expense added successfully!', 'Success');
        this.showAddExpenseForm = false;
      },
      error: (err) => {
        console.error('Error adding expense:', err);
        this.toastr.error('Failed to add expense', 'Error');
      },
    });
  }

  updateBudget(budgetId: number, expenseAmount: number): void {
    this.budgetService
      .updateBudgetRemaining(budgetId, expenseAmount)
      .subscribe({
        next: (updatedBudget) => {
          const budget = updatedBudget as Budget;
          console.log('Budget updated successfully:', budget);

          if (budget.currentSpent > budget.monthlyLimit) {
            this.toastr.warning(
              'You have exceeded your monthly budget!',
              'Budget Alert'
            );
          } else {
            this.toastr.success('Budget updated successfully!', 'Success');
          }
        },
        error: (error) => {
          console.error('Error updating budget:', error);
          this.toastr.error('Failed to update budget', 'Error');
        },
      });
  }

  deleteExpense(id: number): void {
    this.expenseService.deleteExpense(id).subscribe({
      next: () => {
        this.expenses = this.expenses.filter((expense) => expense.id !== id);
        this.toastr.success('Expense deleted successfully!', 'Success');
      },
      error: (err) => {
        console.error('Error deleting expense:', err);
        this.toastr.error('Failed to delete expense', 'Error');
      },
    });
  }
}

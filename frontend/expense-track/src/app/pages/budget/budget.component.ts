import { Component, OnInit } from '@angular/core';
import { BudgetService } from '../../services/budget/budget.service';
import { Budget } from '../../models/budget.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-budget',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './budget.component.html',
  styleUrls: ['./budget.component.scss'],
})
export class BudgetComponent implements OnInit {
  budgets: Budget[] = [];
  showAddForm: boolean = false;
  editingBudget: boolean = false;

  newBudget: Budget = {
    id: 0,
    monthlyLimit: 0,
    currentSpent: 0,
    description: '',
    remainingBudget: 0,
    progress: 0,
  };

  constructor(private budgetService: BudgetService) {}

  ngOnInit(): void {
    this.getBudgets();
  }

  getBudgets(): void {
    this.budgetService.getBudgets().subscribe((data: Budget[]) => {
      this.budgets = data;
    });
  }

  addBudget(): void {
    // Calculate remaining budget and progress
    this.newBudget.remainingBudget =
      this.newBudget.monthlyLimit - this.newBudget.currentSpent;
    this.newBudget.progress =
      (this.newBudget.currentSpent / this.newBudget.monthlyLimit) * 100;

    this.budgetService.addBudget(this.newBudget).subscribe((budget: Budget) => {
      this.budgets.push(budget);
      this.resetNewBudget();
      this.showAddForm = false; // Hide form after adding
    });
  }

  deleteBudget(id: number): void {
    this.budgetService.deleteBudget(id).subscribe(() => {
      this.budgets = this.budgets.filter((budget) => budget.id !== id);
    });
  }
  editBudget(budget: Budget): void {
    this.newBudget = { ...budget }; // Pre-fill form with selected budget
    this.showAddForm = true;
    this.editingBudget = true; // Mark as editing
  }

  updateBudget(): void {
    // Calculate remaining budget and progress for the updated budget
    this.newBudget.remainingBudget =
      this.newBudget.monthlyLimit - this.newBudget.currentSpent;
    this.newBudget.progress =
      (this.newBudget.currentSpent / this.newBudget.monthlyLimit) * 100;

    // Call the service to update the budget
    this.budgetService
      .updateBudget(this.newBudget.id, this.newBudget)
      .subscribe(() => {
        // After update, reset form and fetch updated budgets
        this.getBudgets();
        this.resetNewBudget();
        this.showAddForm = false;
        this.editingBudget = false;
      });
  }

  resetNewBudget(): void {
    this.newBudget = {
      id: 0,
      monthlyLimit: 0,
      currentSpent: 0,
      description: '',
      remainingBudget: 0,
      progress: 0,
    };
  }
}

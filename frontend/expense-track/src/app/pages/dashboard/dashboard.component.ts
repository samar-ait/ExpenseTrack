import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Expense } from '../../models/expense.model';
import { Budget } from '../../models/budget.model';
import { ExpenseService } from '../../services/expense/expense.service';
import { BudgetService } from '../../services/budget/budget.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import Chart from 'chart.js/auto';
@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss',
})
export class DashboardComponent implements OnInit {
  expenses: Expense[] = [];
  budgets: Budget[] = [];

  @ViewChild('expenseChart', { static: true })
  expenseChart!: ElementRef<HTMLCanvasElement>;

  constructor(
    private expenseService: ExpenseService,
    private budgetService: BudgetService
  ) {}

  ngOnInit(): void {
    this.expenseService.getExpenses().subscribe(
      (expenses) => {
        console.log('Expenses in DashboardComponent:', expenses); // Log the data
        this.expenses = expenses;
        this.renderChart();
      },
      (error) => console.error('Error fetching expenses:', error)
    );
    this.budgetService
      .getBudgets()
      .subscribe((budgets) => (this.budgets = budgets));
  }
  renderChart(): void {
    const categoryTotals: { [key: string]: number } = {};

    // Calculate totals by category
    this.expenses.forEach((expense) => {
      categoryTotals[expense.category] =
        (categoryTotals[expense.category] || 0) + expense.amount;
    });

    const labels = Object.keys(categoryTotals);
    const data = Object.values(categoryTotals);

    // Create the pie chart
    new Chart(this.expenseChart.nativeElement, {
      type: 'pie',
      data: {
        labels,
        datasets: [
          {
            data,
            backgroundColor: ['#FF5733', '#33FF57', '#3357FF', '#FFFF33'],
          },
        ],
      },
      options: {
        responsive: true,
        plugins: {
          legend: {
            position: 'top',
          },
        },
      },
    });
  }
}

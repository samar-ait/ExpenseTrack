import { provideRouter, RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { ExpenseComponent } from './pages/expense/expense.component';
import { BudgetComponent } from './pages/budget/budget.component';

export const routes: Routes = [
  { path: 'dashboard', component: DashboardComponent }, // Default route
  { path: 'expenses', component: ExpenseComponent },
  { path: 'budgets', component: BudgetComponent },
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: '**', redirectTo: 'dashboard' },
];

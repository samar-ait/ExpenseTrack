import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Budget } from '../../models/budget.model';

@Injectable({
  providedIn: 'root',
})
export class BudgetService {
  private apiUrl = 'http://localhost:5195/api/budget'; // Replace with your backend URL

  constructor(private http: HttpClient) {}

  updateBudgetRemaining(budgetId: number, expenseAmount: number) {
    return this.http.put(
      `${this.apiUrl}/${budgetId}/updateRemaining`,
      expenseAmount
    );
  }

  getBudgets(): Observable<Budget[]> {
    return this.http.get<Budget[]>(this.apiUrl);
  }

  addBudget(budget: Budget): Observable<Budget> {
    return this.http.post<Budget>(this.apiUrl, budget);
  }

  updateBudget(id: number, budget: Budget): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, budget);
  }

  deleteBudget(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

export interface Budget {
  id: number;
  monthlyLimit: number;
  currentSpent: number;
  description: string;
  remainingBudget: number;
  progress: number;
}

# Expense Tracker with Budget Alerts , ANGULAR 18 - .NET 8

## Overview
This is a web application built to track user expenses and provide alerts when the total expenses exceed a predefined monthly budget. The application allows users to add, view, and delete expenses, categorize them, set a monthly budgets (you can modify or delete it), and view a progress bar that indicates the remaining budget. It also notifies users when they exceed their budget.

### Features
- **Add Expenses**: Users can input details such as the amount, category, and description of the expense.
- **View Expenses**: Users can view a list of their expenses, including categories and amounts.
- **Delete Expenses**: Users can remove an expense from the list.
- **Categorize Expenses**: Expenses can be categorized into types like Food, Transport, Entertainment, etc.
- **Monthly Budget**: Users can set a monthly budget, and the application will display a progress bar showing the remaining budget.
- **Notifications**: Users will be notified when their total expenses exceed the monthly budget.
- **Chart**: (Bonus) A pie chart that visually represents expenses by category.

### Technologies Used
- **Frontend**: Angular 18
- **Backend**: .NET 8
- **Database**: SQL Server (or other databases as per the setup)
- **Libraries**: Chart.js for the expense category pie chart

### Setup Instructions

#### Backend Setup (API with .NET)
1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/expense-tracker.git
   cd expense-tracker/backend

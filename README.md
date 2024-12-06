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

#### Backend Setup (API with .NET 8)
1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/expense-tracker.git
   cd expense-tracker/backend
2. Install the required dependencies:
   Make sure you have .NET 8 SDK installed. If not, you can download it from the official .NET website.
   Run the following command to restore the backend dependencies:
    ```bash
    dotnet restore
3.Configure the Database Connection:
   ```bash
   "ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=ExpenseTrackerDb;User Id=myusername;Password=mypassword;"
}
 ```
4.Run the API:
This will start the API locally at http://localhost:5000 (or another port, depending on your configuration).
```bash
dotnet run
5. Check API Endpoints: You can use Postman or another API testing tool to test the endpoints. Below are some of the main API routes:
- **GET /api/expenses**: Get all expenses
- **POST /api/expenses**: Add a new expense
- **DELETE /api/expenses/{id}**: – Delete an expense

#### Frontend Setup (Angular 18)
1.Clone the repository:
  ```bash
git clone https://github.com/yourusername/expense-tracker.git
cd expense-tracker/frontend
 ```
2.Install the required dependencies :
-Ensure you have Node.js and Angular CLI installed.
-Run the following command to install frontend dependencies:
  ```bash
npm install
 ```





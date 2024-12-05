using ExpenseTrackAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure SQL Server connection string
var connectionString = builder.Configuration.GetConnectionString("ExpenseTrackerDb");

// Add DbContext to the container
builder.Services.AddDbContext<ExpenseContext>(options =>
    options.UseSqlServer(connectionString));

// Register repositories to be injected in controllers
builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
builder.Services.AddScoped<IBudgetRepository, BudgetRepository>(); // Example for BudgetRepository

// Add controllers
builder.Services.AddControllers();

// Optional: Add Swagger for API documentation (for development)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

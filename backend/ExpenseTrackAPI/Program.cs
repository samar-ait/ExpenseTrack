using ExpenseTrackAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure SQL Server connection string
var connectionString = builder.Configuration.GetConnectionString("ExpenseTrackerDb");

// Add DbContext to the container
builder.Services.AddDbContext<ExpenseContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container (controllers, etc.)
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthorization();

app.MapControllers();

app.Run();

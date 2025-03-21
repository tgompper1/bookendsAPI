using BookEndsAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables(); // Load from environment variables

var connectionString = builder.Configuration["MY_CONNECTION_STRING"]; // Read environment variable

Console.WriteLine($"Loaded connection string: {connectionString}");

// Add Database Context
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Controllers
builder.Services.AddControllers();

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy => policy.WithOrigins("http://localhost:3000")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors("AllowReactApp"); // Apply CORS Policy
app.UseAuthorization();
app.MapControllers();

app.Run();
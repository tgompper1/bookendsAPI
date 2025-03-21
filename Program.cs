using BookEndsAPI.Data;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

Env.Load();
string connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

// Add Database Context
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(connectionString));


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
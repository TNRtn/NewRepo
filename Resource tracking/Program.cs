
using Microsoft.EntityFrameworkCore;
using Resource_tracking.Data;
using Resource_tracking.Models;
using Resource_tracking.Services;

var builder = WebApplication.CreateBuilder(args);

// Register Controllers
builder.Services.AddControllers();

// Get Connection String
string connstring = builder.Configuration
    .GetConnectionString("defaultconnection")
    ?? throw new InvalidOperationException("Database connection string not found.");

// Configure Database
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connstring);
});

// Register Services
builder.Services.AddScoped<Categories>();
builder.Services.AddScoped<ResourcesService>();
builder.Services.AddScoped<projectService>();
builder.Services.AddScoped<MenuService>();
builder.Services.AddScoped<TimeperiodService>();
builder.Services.AddScoped<DashBoardservice>();
builder.Services.AddScoped<HealthService>();
builder.Services.AddScoped<TargetService>();
// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();

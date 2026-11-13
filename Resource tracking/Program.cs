
using Microsoft.EntityFrameworkCore;
using Resource_tracking.Services;
using Resource_tracking.Data;

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

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors("AllowAngular");

app.UseAuthorization();

app.MapControllers();

app.Run();

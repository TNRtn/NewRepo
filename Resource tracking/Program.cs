using Microsoft.EntityFrameworkCore;
using Resource_tracking.Services;
using System;
using System.Text;
using Resource_tracking.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Register Controllers
builder.Services.AddControllers();

// 2. Get Connection String
string connstring = builder.Configuration
    .GetConnectionString("defaultconnection")
    ?? throw new InvalidOperationException("Database connection string not found.");
Console.WriteLine($"Database connection string: {connstring}");
Console.WriteLine("Database connection string loaded successfully.");

// 3. Configure Database
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connstring);
});

// 4. Register Services
builder.Services.AddScoped<Categories>();

// 5. Swagger Configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 6. CORS Configuration
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

// 7. Build Application
var app = builder.Build();

// 8. Configure HTTP Request Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAngular");

app.UseAuthorization();

app.MapControllers();

// 9. Run Application
app.Run();

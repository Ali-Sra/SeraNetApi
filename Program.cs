using Microsoft.EntityFrameworkCore;
using SeraNetApi.Data;
using SeraNetApi.Repositories;
using SeraNetApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Controller aktivieren
builder.Services.AddControllers();

// Swagger für API-Test im Browser
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// SQL Server Verbindung
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency Injection
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

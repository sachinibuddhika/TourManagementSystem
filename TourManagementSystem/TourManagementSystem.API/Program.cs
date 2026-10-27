using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TourManagementSystem.Application;
using TourManagementSystem.Application.Common;
using TourManagementSystem.Application.Common.Interfaces;
using TourManagementSystem.Domain;
using TourManagementSystem.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine(
    $"Connection string loaded: {!string.IsNullOrWhiteSpace(connectionString)}");
builder.Services.AddScoped<
    IPasswordHasher,
    PasswordHasher>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

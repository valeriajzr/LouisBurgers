using LouisBurgers.Data;
using LouisBurgers.Services.Implementations;
using LouisBurgers.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LouisBurgersContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LouisBurgersContext") ?? throw new InvalidOperationException("Connection string 'LouisBurgersContext' not found.")));

//Registro del servicio de BurgerService
// Registra el servicio
builder.Services.AddScoped<IBurgerService, BurgerService>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

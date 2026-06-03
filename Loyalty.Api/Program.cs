using Application.Interfaces;
using Application.Mappers;
using Application.Services;
using Application.Validators;
using Domain.Interfaces;
using Domain.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Loyalty.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

//mapper
builder.Services.AddSingleton<LoyaltyScoreMapper>();
builder.Services.AddSingleton<LoyaltyGrpcMapper>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Application DI
builder.Services.AddScoped<ILoyaltyScoreHistoryRepository, LoyaltyScoreHistoryRepository>();
builder.Services.AddScoped<ILoyaltyScoreService, LoyaltyScoreService>();
builder.Services.AddScoped<ILoyaltyScoreCalculator, LoyaltyScoreCalculator>();

// FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<CalculateScoreRequestValidator>();
builder.Services.AddFluentValidationAutoValidation();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapGrpcReflectionService();
}

app.UseRouting();

app.MapControllers();
app.MapGrpcService<LoyaltyGrpcService>();

app.Run();
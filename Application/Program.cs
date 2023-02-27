using Microsoft.EntityFrameworkCore;
using RecipeManager.Application.Data.Repository;
using RecipeManager.Application.Data.UnitOfWork;
using RecipeManager.Application.Models.Recipes;
using RecipeManager.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Hide sensitive info.
builder.Configuration.AddJsonFile("appsettings.json", false, true)
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json",
        true)
    .AddEnvironmentVariables().Build();

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ApiDbContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("RecipesDb")));

builder.Services.AddScoped<IRepository<Recipe>, DataRepository<Recipe>>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
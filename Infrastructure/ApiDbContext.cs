using System;
using Microsoft.EntityFrameworkCore;
using RecipeManager.Application.Models.Recipes;

namespace RecipeManager.Infrastructure
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions opts) : base(opts)
        { }

        public DbSet<Recipe> Recipes { get; set; }
    }
}


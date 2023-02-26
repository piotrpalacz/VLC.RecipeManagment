using System;
using Microsoft.EntityFrameworkCore;
using VLC.RecipeManagment.Application.Models.Recipes;

namespace VLC.RecipeManagment.Infrastructure
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions opts) : base(opts)
        { }

        public DbSet<Recipe> Recipes { get; set; }
    }
}


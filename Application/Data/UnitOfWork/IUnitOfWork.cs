using RecipeManager.Application.Data.Repository;
using RecipeManager.Application.Models.Recipes;
using System;
using System.Runtime.ConstrainedExecution;

namespace RecipeManager.Application.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Recipe> RecipesRepo { get; }
        Task<IEnumerable<Recipe>> Search(string label);
        Task SaveChangesAsync();
    }
}


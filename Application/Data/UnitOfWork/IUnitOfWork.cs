using System;
using System.Runtime.ConstrainedExecution;
using VLC.RecipeManagment.Application.Data.Repository;
using VLC.RecipeManagment.Application.Models.Recipes;

namespace VLC.RecipeManagment.Application.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Recipe> RecipesRepo { get; }
        Task SaveChangesAsync();
    }
}


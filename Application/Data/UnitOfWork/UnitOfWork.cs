using System;
using Microsoft.EntityFrameworkCore;
using VLC.RecipeManagment.Application.Data.Repository;
using VLC.RecipeManagment.Application.Models.Recipes;
using VLC.RecipeManagment.Infrastructure;

namespace VLC.RecipeManagment.Application.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApiDbContext _context;

        public IRepository<Recipe> RecipesRepo { get; }

        private bool _disposed = false;

        public UnitOfWork(ApiDbContext context, IRepository<Recipe> recipesRepo)
        {
            _context = context;
            RecipesRepo = recipesRepo;
        }

        //Search Recipe
        public async Task<IEnumerable<Recipe>> Search(string label)
        {
            IQueryable<Recipe> query = _context.Recipes;

            if (!string.IsNullOrEmpty(label))
            {
                query = query.Where(e => e.Label.Contains(label));
            }

            return query.ToList();
        }


        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }


        

        
    }
}


using System;
using Microsoft.EntityFrameworkCore;
using VLC.RecipeManagment.Application.Models.Recipes;
using VLC.RecipeManagment.Infrastructure;

namespace VLC.RecipeManagment.Application.Data.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly IRecipeRepository _recipeRepo;
        private readonly ApiDbContext _context;

        public RecipeRepository(IRecipeRepository recipeRepo, ApiDbContext context)
        {
            _recipeRepo = recipeRepo;
            _context = context;
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipes()
        {
            var recipes = await _recipeRepo.GetAllRecipes();
            if (recipes != null)
            {
                return recipes;
            }
            throw new Exception("Recipe does not exist!");

        }

        public async Task<Recipe> GetRecipeById(int recipeId)
        {
            return await _recipeRepo.GetRecipeById(recipeId);
        }

        public async Task AddRecipe(Recipe recipe)
        {
            await _recipeRepo.AddRecipe(recipe);
            await _context.SaveChangesAsync();
        }

        public void UpdateRecipeAsync(Recipe recipe)
        {
            _context.Entry(recipe).State = EntityState.Modified;
            _context.SaveChangesAsync();
        }

        public async Task DeleteRecipeAsync(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            _context.Remove(recipe);
            await _context.SaveChangesAsync();
        }

        
    }
}


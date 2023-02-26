using System;
using System.Runtime.ConstrainedExecution;
using VLC.RecipeManagment.Application.Models.Recipes;

namespace VLC.RecipeManagment.Application.Data.Repository
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Recipe>> GetAllRecipes();
        Task<Recipe> GetRecipeById(int id);
        Task AddRecipe(Recipe recipe);
        Task DeleteRecipeAsync(int id);
        void UpdateRecipeAsync(Recipe recipe);
    }
}


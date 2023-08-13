using RecipeManager.Application.Models.Recipes;

namespace RecipeManager.Application.Data.Repository;

public interface IRecipeRepository
{
    Task<IEnumerable<Recipe>> GetAllRecipes();
    Task<Recipe> GetRecipeById(int id);
    Task AddRecipe(Recipe recipe);
    Task DeleteRecipeAsync(int id);
    void UpdateRecipeAsync(Recipe recipe);
}
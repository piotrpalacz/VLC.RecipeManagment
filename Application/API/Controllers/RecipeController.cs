using Microsoft.AspNetCore.Mvc;
using RecipeManager.Application.Data.UnitOfWork;
using RecipeManager.Application.Models.Recipes;

namespace RecipeManager.Application.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecipeController : ControllerBase
{
    private readonly IUnitOfWork _uow;

    public RecipeController(IUnitOfWork uow)
    {
        _uow = uow;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Recipe>>> GetAllRecipesAsync()
    {
        var recipe = await _uow.RecipesRepo.GetAllAsync();
        return Ok(recipe);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Recipe>> GetRecipeByIdAsync(int id)
    {
        var recipe = await _uow.RecipesRepo.GetRecordByIdAsync(id);
        return Ok(recipe);
    }

    [HttpPost("add")]
    public async Task<ActionResult<Recipe>> AddRecipeAsync(Recipe recipe)
    {
        await _uow.RecipesRepo.InsertRecordAsync(recipe);
        return Ok(recipe);
    }

    [HttpPost("update")]
    public void UpdateRecipeAsync(Recipe recipe)
    {
        _uow.RecipesRepo.UpdateRecordAsync(recipe);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        await _uow.RecipesRepo.DeleteRecordAsync(id);
        return Ok(id);
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<Recipe>>> Search(string label)
    {
        try
        {
            var result = await _uow.Search(label);

            if (result.Any()) return Ok(result);

            return NotFound();
        }
        catch (Exception e)
        {
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                "Error retrieving data from the database"
            );
        }
    }
}
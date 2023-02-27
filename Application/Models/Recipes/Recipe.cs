using RecipeManager.Application.Entities;

namespace RecipeManager.Application.Models.Recipes;

public class Recipe : EntityBase
{
    public string? Label { get; set; }

    public string? Ingredients { get; set; }

    public string? Instructions { get; set; }

    public int Calories { get; set; }
}
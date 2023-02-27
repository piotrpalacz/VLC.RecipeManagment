using System;
using System.ComponentModel.DataAnnotations;
using VLC.RecipeManagment.Application.Entities;

namespace VLC.RecipeManagment.Application.Models.Recipes
{
    public class Recipe : EntityBase
    {
        [Required]
        public string? Label { get; set; }

        public List<RecipeCategory>? Categories { get; set; }

        public List<Ingredient>? IngredientLines { get; set; }

        public string? Instructions { get; set; }

        public int Calories { get; set; }

        public List<Nutrition> Nutritions { get; set; }

        
    }
}


using System;
using VLC.RecipeManagment.Application.Entities;

namespace VLC.RecipeManagment.Application.Models.Recipes
{
    public class Recipe : EntityBase
    {
        public string? Label { get; set; }

        public string? Ingredients { get; set; }

        public string? Instructions { get; set; }

        public int Calories { get; set; }

        
    }
}


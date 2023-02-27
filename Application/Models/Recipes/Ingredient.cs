using VLC.RecipeManagment.Application.Entities;

namespace VLC.RecipeManagment.Application.Models.Recipes
{
    public class Ingredient : EntityBase
    {
        private string _text { get; set; }

        public Ingredient(string text)
        {
            _text = text;
        }
    }
}
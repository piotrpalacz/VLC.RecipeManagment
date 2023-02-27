using System;
using VLC.RecipeManagment.Application.Entities;
using VLC.RecipeManagment.Application.Models.Recipes;

namespace VLC.RecipeManagment.Application.Models.Cookbook
{
	public class Cookbook : EntityBase
	{
		private int _userID { get; set; }

		private Recipe _recipeID { get; set; }

		public Cookbook(int userId, Recipe recipes)
		{
			_userID = userId;
            _recipeID = recipes;
		}
	}
}


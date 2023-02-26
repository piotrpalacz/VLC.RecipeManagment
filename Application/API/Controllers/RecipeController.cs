﻿using System;
using Microsoft.AspNetCore.Mvc;
using VLC.RecipeManagment.Application.Data.UnitOfWork;
using VLC.RecipeManagment.Application.Models.Recipes;

namespace VLC.RecipeManagment.Application.API.Controllers
{
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





        

    }
}

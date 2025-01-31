﻿using LezzetKitabi.Domain.Dtos.IngredientDtos;
using LezzetKitabi.Domain.Dtos.RecipeDtos;
using LezzetKitabi.Domain.Entities;
using LezzetKitabi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LezzetKitabi.Services.Abstract
{
    public interface IRecipeService
    {
        Guid AddRecipe(RecipeAddDto recipeAddDto);
        bool DeleteRecipe(Guid id);
        Task<List<RecipeViewGetDto>> GetAllRecipesByOrderAsync(RecipeSortingType _type, List<FilterCriteria> filterCriteriaList = null, int page = -1);
        Task<RecipeGetDto?> GetRecipeByNameAsync(string name);
        Task<bool> UpdateRecipeAsync(RecipeUpdateDto recipeUpdateDto);
    }
}

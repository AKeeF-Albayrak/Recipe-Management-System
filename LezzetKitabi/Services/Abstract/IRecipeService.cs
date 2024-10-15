using LezzetKitabi.Domain.Dtos.IngredientDtos;
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
        Task<List<Recipe>> GetAllRecipesAsync(RecipeSortingType _type, List<FilterCriteria> filterCriteriaList);
        bool DeleteRecipe(Guid id);
        Task<RecipeGetDto?> GetRecipeByNameAsync(string name);

        //Task<IEnumerable<RecipeDto>> GetAllRecipesAsync();
        //Task<RecipeDto> GetRecipeByIdAsync(int id);
        //Task UpdateRecipeAsync(int id, CreateRecipeDto recipeDto);
    }
}

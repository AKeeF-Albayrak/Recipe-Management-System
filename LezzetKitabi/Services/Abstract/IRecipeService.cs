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
        void AddRecipe(RecipeAddDto recipeAddDto);
        Task<List<Recipe>> GetAllRecipesAsync(RecipeSortingType _type);
        bool DeleteRecipe(Guid id);
        //Task<IEnumerable<RecipeDto>> GetAllRecipesAsync();
        //Task<RecipeDto> GetRecipeByIdAsync(int id);
        //Task UpdateRecipeAsync(int id, CreateRecipeDto recipeDto);
    }
}

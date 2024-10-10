using LezzetKitabi.Domain.Dtos.RecipeDtos;
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
        //Task<IEnumerable<RecipeDto>> GetAllRecipesAsync();
        //Task<RecipeDto> GetRecipeByIdAsync(int id);
        //Task UpdateRecipeAsync(int id, CreateRecipeDto recipeDto);
        //Task DeleteRecipeAsync(int id);
    }
}

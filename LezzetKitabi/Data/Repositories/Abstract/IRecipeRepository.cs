using LezzetKitabi.Domain.Dtos.RecipeDtos;
using LezzetKitabi.Domain.Entities;
using LezzetKitabi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LezzetKitabi.Data.Repositories.Abstract
{
    public interface IRecipeRepository : IBaseRepository<Recipe>
    {
        Task<Recipe> GetRecipeByNameAsync(string name);
        Task<bool> UpdateRecipeAsync(RecipeUpdateDto recipeUpdateDto);
        Task<List<RecipeViewGetDto>> GetAllRecipesByOrderAsync(RecipeSortingType type, List<FilterCriteria> filterCriteriaList, int page);

    }
}

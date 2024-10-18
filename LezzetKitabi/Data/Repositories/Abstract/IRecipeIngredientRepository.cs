using LezzetKitabi.Data.Repositories.Concrete;
using LezzetKitabi.Domain.Dtos.CrossTableDtos;
using LezzetKitabi.Domain.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LezzetKitabi.Data.Repositories.Abstract
{
    public interface IRecipeIngredientRepository : IBaseRepository<RecipeIngredient>
    {
        public Task AddRangeAsync(List<AddRecipeIngredientDto> recipeIngredients);
        public Task<List<Ingredient>> GetIngredientsByRecipeIdAsync(Guid recipeId);
    }
}

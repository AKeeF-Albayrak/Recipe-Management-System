using LezzetKitabi.Domain.Entities;
using LezzetKitabi.Domain.Dtos.CrossTableDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace LezzetKitabi.Services.Abstract
{
    public interface IRecipeIngredientService
    {
        Task AddRangeAsync(List<AddRecipeIngredientDto> recipeIngredients);

        public Task<List<Ingredient>> GetIngredientsByRecipeIdAsync(Guid recipeId);
    }
}

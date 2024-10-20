using LezzetKitabi.Domain.Entities;
using LezzetKitabi.Domain.Dtos.CrossTableDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using LezzetKitabi.Domain.Dtos.IngredientDtos;

namespace LezzetKitabi.Services.Abstract
{
    public interface IRecipeIngredientService
    {
        Task AddRangeAsync(List<AddRecipeIngredientDto> recipeIngredients);
        public Task<List<IngredientGetDto>> GetIngredientsByRecipeIdAsync(Guid recipeId);
    }
}

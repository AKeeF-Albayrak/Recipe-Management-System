using LezzetKitabi.Data.Repositories.Abstract;
using LezzetKitabi.Domain.Dtos.CrossTableDtos;
using LezzetKitabi.Domain.Entities;
using LezzetKitabi.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LezzetKitabi.Services.Concrete
{
    public class RecipeIngredientService : IRecipeIngredientService
    {
        private readonly IRecipeIngredientRepository _recipeIngredientRepository;
        public RecipeIngredientService(IRecipeIngredientRepository recipeIngredientRepository)
        {
            _recipeIngredientRepository = recipeIngredientRepository;
        }
        public async Task AddRangeAsync(List<AddRecipeIngredientDto> recipeIngredients)
        {
            await _recipeIngredientRepository.AddRangeAsync(recipeIngredients);
        }

        public async Task<List<Ingredient>> GetIngredientsByRecipeIdAsync(Guid recipeId)
        {
            return await _recipeIngredientRepository.GetIngredientsByRecipeIdAsync(recipeId);
        }
    }
}

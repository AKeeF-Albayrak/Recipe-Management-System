using LezzetKitabi.Data.Repositories.Abstract;
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
        public async Task AddRangeAsync(IEnumerable<RecipeIngredient> recipeIngredients)
        {
            await _recipeIngredientRepository.AddRangeAsync(recipeIngredients);
        }
    }
}

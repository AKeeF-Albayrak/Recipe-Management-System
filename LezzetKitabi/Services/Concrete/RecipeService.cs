using LezzetKitabi.Data.Repositories.Abstract;
using LezzetKitabi.Domain.Dtos.RecipeDtos;
using LezzetKitabi.Domain.Entities;
using LezzetKitabi.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LezzetKitabi.Services.Concrete
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        public RecipeService(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public void AddRecipe(RecipeAddDto recipeAddDto)
        {
            Recipe recipe = new Recipe()
            {
                RecipeName = recipeAddDto.RecipeName,
                Category = recipeAddDto.Category,
                PreparationTime = recipeAddDto.PreparationTime,
                Instructions = recipeAddDto.Instructions,
            };

            _recipeRepository.AddEntity(recipe);
        }
    }
}

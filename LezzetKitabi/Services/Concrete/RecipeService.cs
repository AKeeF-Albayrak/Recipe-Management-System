using LezzetKitabi.Data.Repositories.Abstract;
using LezzetKitabi.Data.Repositories.Concrete;
using LezzetKitabi.Domain.Dtos.IngredientDtos;
using LezzetKitabi.Domain.Dtos.RecipeDtos;
using LezzetKitabi.Domain.Entities;
using LezzetKitabi.Domain.Enums;
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
        public Guid AddRecipe(RecipeAddDto recipeAddDto)
        {
            Recipe recipe = new Recipe()
            {
                RecipeName = recipeAddDto.RecipeName,
                Category = recipeAddDto.Category,
                PreparationTime = recipeAddDto.PreparationTime,
                Instructions = recipeAddDto.Instructions,
            };

            _recipeRepository.AddEntity(recipe);
            return recipe.Id;
        }
        public async Task<List<RecipeViewGetDto>> GetAllRecipesByOrderAsync(RecipeSortingType _type, List<FilterCriteria> filterCriteriaList = null)
        {
            // Tüm tarifleri al
            var recipes = await _recipeRepository.GetAllRecipesByOrderAsync(_type, filterCriteriaList);

            // Yüzde değeri %100'den fazla olan tarifleri kontrol et ve eşitle
            foreach (var recipe in recipes)
            {
                if (recipe.AvailabilityPercentage > 100)
                {
                    recipe.AvailabilityPercentage = 100;  // %100'den fazla olanları %100'e eşitle
                }
            }

            return recipes;
        }
        public bool DeleteRecipe(Guid id)
        {
            bool isDeleted = _recipeRepository.DeleteAsync(id).Result;

            return isDeleted;
        }

        public async Task<RecipeGetDto?> GetRecipeByNameAsync(string name)
        {
            var recipe = await _recipeRepository.GetRecipeByNameAsync(name);

            if (recipe == null)
            {
                return null;
            }

            RecipeGetDto recipeGetDto = new RecipeGetDto()
            {
                Id = recipe.Id,
                RecipeName = recipe.RecipeName,
                Category = recipe.Category,
                Instructions = recipe.Instructions,
                PreparationTime = recipe.PreparationTime,
            };

            return recipeGetDto;
        }

        public async Task<bool> UpdateRecipe(RecipeUpdateDto recipeUpdateDto)
        {
            return await _recipeRepository.UpdateRecipeAsync(recipeUpdateDto);
        }
    }
}

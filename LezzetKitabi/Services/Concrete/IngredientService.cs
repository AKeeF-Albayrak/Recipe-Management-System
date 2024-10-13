using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LezzetKitabi.Data.Repositories.Abstract;
using LezzetKitabi.Domain.Dtos.IngredientDtos;
using LezzetKitabi.Domain.Entities;
using LezzetKitabi.Domain.Enums;
using LezzetKitabi.Services.Abstract;

namespace LezzetKitabi.Application.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;

        public IngredientService(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public void AddIngredient(IngredientAddDto ingredientAddDto)
        {
            Ingredient ingredient = new Ingredient()
            {
                IngredientName = ingredientAddDto.IngredientName,
                TotalQuantity = ingredientAddDto.TotalQuantity,
                Unit = ingredientAddDto.Unit,
                UnitPrice = ingredientAddDto.UnitPrice,
            };

            _ingredientRepository.AddEntity(ingredient);
        }

        public bool DeleteIngredient(Guid id)
        {
            bool isDeleted = _ingredientRepository.DeleteAsync(id).Result;

            return isDeleted;
        }

        public async Task<List<Ingredient>> GetAllIngredientsAsync(IngredientSortingType _type)
        {
            return await _ingredientRepository.GetAllIngredientsByOrderAsync(_type);
        }

        public async Task<IngredientGetDto?> GetIngredientByIdAsync(Guid id)
        {
            var ingredient = await _ingredientRepository.GetEntityById(id);

            if (ingredient == null)
            {
                return null;
            }

            IngredientGetDto ingredientGetDto = new IngredientGetDto()
            {
                Id = ingredient.Id,
                IngredientName = ingredient.IngredientName,
                TotalQuantity = ingredient.TotalQuantity,
                Unit = ingredient.Unit,
                UnitPrice = ingredient.UnitPrice
            };

            return ingredientGetDto;
        }
    }
}

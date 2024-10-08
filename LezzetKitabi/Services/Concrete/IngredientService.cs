using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LezzetKitabi.Data.Repositories.Abstract;
using LezzetKitabi.Domain.Dtos.IngredientDtos;
using LezzetKitabi.Domain.Entities;
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

        public async Task<IEnumerable<IngredientDto>> GetAllAsync()
        {
            var ingredients = await _ingredientRepository.GetAllAsync();
            var ingredientDtos = new List<IngredientDto>();

            foreach (var ingredient in ingredients)
            {
                ingredientDtos.Add(new IngredientDto
                {
                    Id = ingredient.Id, // Eğer Id'yi GUID olarak tutuyorsanız
                    IngredientName = ingredient.IngredientName,
                    TotalQuantity = ingredient.TotalQuantity,
                    Unit = ingredient.Unit,
                    UnitPrice = ingredient.UnitPrice
                });
            }

            return ingredientDtos; // Dönüşüm
        }

        public async Task<IngredientDto> GetByIdAsync(Guid id)
        {
            var ingredient = await _ingredientRepository.GetByIdAsync(id);
            if (ingredient == null) return null;

            return new IngredientDto
            {
                Id = ingredient.Id,
                IngredientName = ingredient.IngredientName,
                TotalQuantity = ingredient.TotalQuantity,
                Unit = ingredient.Unit,
                UnitPrice = ingredient.UnitPrice
            };
        }

        public async Task AddAsync(IngredientDto ingredientDto)
        {
            var ingredient = new Ingredient
            {
                Id = ingredientDto.Id, // DTO'dan Id'yi alıyoruz
                IngredientName = ingredientDto.IngredientName,
                TotalQuantity = ingredientDto.TotalQuantity,
                Unit = ingredientDto.Unit,
                UnitPrice = ingredientDto.UnitPrice
            };
            await _ingredientRepository.AddAsync(ingredient);
        }

        public async Task UpdateAsync(IngredientDto ingredientDto)
        {
            var ingredient = new Ingredient
            {
                Id = ingredientDto.Id,
                IngredientName = ingredientDto.IngredientName,
                TotalQuantity = ingredientDto.TotalQuantity,
                Unit = ingredientDto.Unit,
                UnitPrice = ingredientDto.UnitPrice
            };
            await _ingredientRepository.UpdateAsync(ingredient);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _ingredientRepository.DeleteAsync(id);
        }

        public void Test()
        {
            MessageBox.Show("Ya mia bu butona tiklamadedim sana hep yanlis seyler yapiyosun!(Service denendi onaylandi)", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }
    }
}

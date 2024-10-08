using LezzetKitabi.Domain.Dtos.IngredientDtos;
using LezzetKitabi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LezzetKitabi.Services.Abstract
{
    public interface IIngredientService
    {
        Task<IEnumerable<IngredientDto>> GetAllAsync();
        Task<IngredientDto> GetByIdAsync(Guid id);
        Task AddAsync(IngredientDto ingredientDto);
        Task UpdateAsync(IngredientDto ingredientDto);
        Task DeleteAsync(Guid id);
        void Test();
    }
}

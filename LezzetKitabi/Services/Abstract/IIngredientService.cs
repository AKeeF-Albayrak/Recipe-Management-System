using LezzetKitabi.Domain.Dtos.IngredientDtos;
using LezzetKitabi.Domain.Entities;
using LezzetKitabi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LezzetKitabi.Services.Abstract
{
    public interface IIngredientService
    {
        void AddIngredient(IngredientAddDto ingredientAddDto);
        Task<List<Ingredient>> GetAllIngredientsByOrderAndFilterAsync(IngredientSortingType sortingType, List<FilterCriteria> filterCriteriaList = null);
        bool DeleteIngredient(Guid id);
        Task<IngredientGetDto?> GetIngredientByIdAsync(Guid id);
    }
}

﻿using LezzetKitabi.Domain.Dtos.IngredientDtos;
using LezzetKitabi.Domain.Entities;
using LezzetKitabi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LezzetKitabi.Data.Repositories.Abstract
{
    public interface IIngredientRepository : IBaseRepository<Ingredient>
    {
        Task<bool> UpdateIngredientAsync(IngredientUpdateDto ingredient);
        Task<List<Ingredient>> GetAllIngredientsByOrderAndFilterAsync(IngredientSortingType sortingType, List<FilterCriteria> filterCriteriaList, int page);
    }
}

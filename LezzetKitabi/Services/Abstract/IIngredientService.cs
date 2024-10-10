using LezzetKitabi.Domain.Dtos.IngredientDtos;
using LezzetKitabi.Domain.Entities;
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
        public void AddIngredient(IngredientAddDto ingredientAddDto);
        public Task<List<Ingredient>> GetAllIngredientsAsync();
    }
}

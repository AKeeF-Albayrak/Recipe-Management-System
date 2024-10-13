using LezzetKitabi.Data.Repositories.Concrete;
using LezzetKitabi.Domain.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LezzetKitabi.Data.Repositories.Abstract
{
    public interface IRecipeIngredientRepository : IBaseRepository<RecipeIngredient>
    {
        public Task AddRangeAsync(IEnumerable<RecipeIngredient> recipeIngredients);
    }
}

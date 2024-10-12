using LezzetKitabi.Domain.Entities;
using LezzetKitabi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LezzetKitabi.Data.Repositories.Abstract
{
    public interface IRecipeRepository : IBaseRepository<Recipe>
    {
        //Task<List<Recipe>> GetAllEntitiesByOrderAsync(RecipeSortingType type);
    }
}

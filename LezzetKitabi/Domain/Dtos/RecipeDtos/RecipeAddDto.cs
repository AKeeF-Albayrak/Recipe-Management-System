using LezzetKitabi.Domain.Dtos.CrossTableDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LezzetKitabi.Domain.Dtos.RecipeDtos
{
    public class RecipeAddDto
    {
        public string RecipeName { get; set; }
        public string Category { get; set; }
        public int PreparationTime { get; set; }
        public string Instructions { get; set; }
        public List<AddRecipeIngredientDto> Ingredients { get; set; }
    }
}

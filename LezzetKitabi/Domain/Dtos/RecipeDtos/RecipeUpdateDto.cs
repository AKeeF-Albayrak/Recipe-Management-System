using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LezzetKitabi.Domain.Dtos.RecipeDtos
{
    public class RecipeUpdateDto // değişecek     public List<AddRecipeIngredientDto> Ingredients { get; set; } // Mevcut ve yeni malzemeleri alacak

    {
        public string RecipeName { get; set; }
        public string Category { get; set; }
        public int PreparationTime { get; set; }
        public string Instructions { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LezzetKitabi.Domain.Dtos.CrossTableDtos
{
    public class RecipeIngredientUpdateDto
    {
        public Guid IngredientID { get; set; } // Malzeme ID'si
        public float IngredientAmount { get; set; } // Malzeme miktarı
    }
}

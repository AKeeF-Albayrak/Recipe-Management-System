using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LezzetKitabi.Domain.Dtos.CrossTableDtos
{
    public class AddRecipeIngredientDto //değişebilir
    {
        public string IngredientName { get; set; }  // Yeni malzeme eklenirse burada olacak
        public float IngredientAmount { get; set; }
        public string Unit { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsExistingIngredient { get; set; }  // True: Kayıtlı malzeme seçilmişse
    }
}

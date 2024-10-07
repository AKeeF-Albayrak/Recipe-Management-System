using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LezzetKitabi.Domain.Entities
{
    public class Ingredient
    {
        public string IngredientName { get; set; } // MalzemeAdi
        public string TotalQuantity { get; set; } // ToplamMiktar
        public string Unit { get; set; } // MalzemeBirim
        public decimal UnitPrice { get; set; } // BirimFiyat
    }
}

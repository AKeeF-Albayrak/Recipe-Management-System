using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LezzetKitabi.Domain.Entities
{
    public class RecipeIngredient
    {
        public Guid RecipeID { get; set; }
        public Recipe Recipe { get; set; }

        public Guid IngredientID { get; set; }
        public Ingredient Ingredient { get; set; }

        public float IngredientAmount { get; set; }
    }
}

using LezzetKitabi.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LezzetKitabi.Domain.Entities
{
    public class Recipe : BaseEntity
    {
        public string RecipeName { get; set; }
        public string Category { get; set; }
        public int PreparationTime { get; set; }
        public string Instructions { get; set; }
        public byte[] Image { get; set; } = GlobalVariables.BaseRecipeImage;
    }
}

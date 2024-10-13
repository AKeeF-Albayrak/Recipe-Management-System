﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LezzetKitabi.Domain.Dtos.CrossTableDtos
{
    public class AddRecipeIngredientDto
    {
        public Guid IngredientID { get; set; }
        public Guid RecipeID { get; set; }
        public float IngredientAmount { get; set; }
    }
}

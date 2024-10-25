using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LezzetKitabi.Domain.Dtos.RecipeDtos
{
    public class RecipeViewGetDto
    {
        public Guid Id { get; set; }
        public string RecipeName { get; set; }
        public string Category { get; set; }
        public int PreparationTime { get; set; }
        public string Instructions { get; set; }
        public decimal MatchingPercentage { get; set; } = -1;
        public decimal TotalCost { get; set; }
        public decimal AvailabilityPercentage { get; set; }
        public decimal MissingCost { get; set; }
        public byte[] Image { get; set; }
    }
}

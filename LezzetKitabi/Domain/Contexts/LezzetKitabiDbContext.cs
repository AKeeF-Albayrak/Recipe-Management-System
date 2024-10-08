using LezzetKitabi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace LezzetKitabi.Domain.Contexts
{
    public class LezzetKitabiDbContext : DbContext
    {
        public LezzetKitabiDbContext(DbContextOptions<LezzetKitabiDbContext> options) : base(options) { }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
    }
}

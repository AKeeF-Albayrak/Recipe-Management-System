using LezzetKitabi.Domain.Dtos.RecipeDtos;
using LezzetKitabi.Services.Abstract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LezzetKitabi.Forms
{
    public partial class RecipeDetailsForm : Form
    {
        private readonly IIngredientService _ingredientService;
        private readonly IRecipeService _recipeService;
        private readonly IRecipeIngredientService _recipeIngredientService;
        private readonly IServiceProvider _serviceProvider;
        public RecipeDetailsForm()
        {
            InitializeComponent();
        }
        public void LoadRecipeDetails(RecipeViewGetDto recipe)
        {
            // Tarifin bilgilerini dinamik olarak doldur
            labelRecipeName.Text = recipe.RecipeName;

            // Diğer tarif detaylarını ekleyebilirsiniz
        }
    }
}

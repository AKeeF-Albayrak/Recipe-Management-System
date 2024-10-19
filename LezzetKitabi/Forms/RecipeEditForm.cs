using LezzetKitabi.Services.Abstract;
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
    public partial class RecipeEditForm : Form
    {
        private readonly IIngredientService _ingredientService;
        private readonly IRecipeService _recipeService;
        private readonly IRecipeIngredientService _recipeIngredientService;
        private readonly IServiceProvider _serviceProvider;
        public RecipeEditForm()
        {
            InitializeComponent();
        }
    }
}

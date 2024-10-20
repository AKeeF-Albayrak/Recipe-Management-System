using LezzetKitabi.Application.Services;
using LezzetKitabi.Data.Repositories.Abstract;
using LezzetKitabi.Domain.Dtos.RecipeDtos;
using LezzetKitabi.Domain.Entities;
using LezzetKitabi.Domain.Enums;
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
    public partial class RecipeEditForm : Form
    {
        private RecipeViewGetDto _recipe;
        private readonly IIngredientService _ingredientService;
        private List<Ingredient> _ingredients;
        public RecipeEditForm(RecipeViewGetDto recipe, IServiceProvider serviceProvider, List<Ingredient> ingredients)
        {
            _ingredients = ingredients;
            _recipe = recipe;
            _ingredientService = serviceProvider.GetRequiredService<IIngredientService>();
            InitializeComponent();
            LoadRecipe();
        }

        public async void LoadRecipe()
        {
            textBoxName.Text = _recipe.RecipeName;
            textBoxTime.Text = _recipe.PreparationTime.ToString();
            var ingredients = await _ingredientService.GetAllIngredientsByOrderAndFilterAsync(IngredientSortingType.A_from_Z);
            comboBoxIngredients.DataSource = ingredients;
            comboBoxIngredients.DisplayMember = "IngredientName";
            comboBoxIngredients.ValueMember = "Id";
            comboBoxCatagory.Items.AddRange(Enum.GetNames(typeof(Category)));
            comboBoxCatagory.SelectedIndex = comboBoxCatagory.Items.IndexOf(_recipe.Category);

            int startx = 10;
            int starty = 10;
            int gap = 20;

            if (comboBoxCatagory.Items.Count > 0)
            {
                for (int i = 0; i < _ingredients.Count; i++)
                {
                    string ingredientText = $"{_ingredients[i].IngredientName} {_ingredients[i].TotalQuantity} {_ingredients[i].Unit}";

                    Label label = new Label
                    {
                        Text = ingredientText,
                        AutoSize = true,
                        Location = new Point(startx, starty + (gap * i))
                    };

                    // Çarpı butonunu oluştur
                    Button button = new Button
                    {
                        Text = "X",
                        Size = new Size(20, 20),
                        Location = new Point(label.Right + 10, label.Top) // Label'in sağına yerleştir
                    };

                    panelIngredients.Controls.Add(label);
                    panelIngredients.Controls.Add(button);
                }
            }
            LoadInstructionsAsync(_recipe.Instructions);
        }

        public async void LoadInstructionsAsync(string instructions)
        {
            var instructionSteps = instructions.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            int startx = 10;
            int starty = 10;
            int gap = 30;

            panelInstructions.Controls.Clear();

            for (int i = 0; i < instructionSteps.Length; i++)
            {
                string instructionText = $"{instructionSteps[i].Trim()}";

                Label label = new Label
                {
                    Text = instructionText,
                    AutoSize = true,
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    Location = new Point(startx, starty + (gap * i))
                };

                panelInstructions.Controls.Add(label);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

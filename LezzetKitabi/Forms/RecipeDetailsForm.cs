using LezzetKitabi.Domain.Dtos.RecipeDtos;
using LezzetKitabi.Domain.Entities;
using LezzetKitabi.Services.Abstract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LezzetKitabi.Forms
{
    public partial class RecipeDetailsForm : Form
    {
        public RecipeDetailsForm()
        {
            InitializeComponent();
        }
        public async void LoadRecipeDetailsAsync(RecipeViewGetDto recipe, List<Ingredient> ingredients)
        {
            labelRecipeName.Text = recipe.RecipeName;
            labelCategory.Text = recipe.Category;
            labelPreparationTime.Text = $"{recipe.PreparationTime} dakika";
            pictureBox1.Image = Properties.Resources.Screenshot_2024_10_09_121511;
            int startx = 10;
            int starty = 10;
            int gap = 20;

            for (int i = 0; i < ingredients.Count; i++)
            {
                string ingredientText = $"{ingredients[i].IngredientName} {ingredients[i].TotalQuantity} {ingredients[i].Unit}";

                Label label = new Label
                {
                    Text = ingredientText,
                    AutoSize = true,
                    Location = new Point(startx, starty + (gap * i))
                };

                panelIngredients.Controls.Add(label);
            }
            LoadInstructionsAsync(recipe.Instructions);
        }
        public async void LoadInstructionsAsync(string instructions)
        {
            // Null veya boş talimat kontrolü
            if (!string.IsNullOrEmpty(instructions))
            {
                // Talimatları satırlara ayır
                var instructionSteps = instructions.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

                // Talimatlar panelini temizle
                panelInstructions.Controls.Clear();

                // Talimatları göstermek için başlangıç noktaları
                int startx = 10;
                int starty = 10;
                int gap = 30;

                // Her talimat adımını bir label olarak ekle
                for (int i = 0; i < instructionSteps.Length; i++)
                {
                    string instructionText = instructionSteps[i].Trim();

                    Label label = new Label
                    {
                        Text = instructionText,
                        AutoSize = true,
                        Font = new Font("Arial", 12, FontStyle.Bold),
                        Location = new Point(startx, starty + (gap * i))
                    };

                    panelInstructions.Controls.Add(label); // Label'i panel'e ekle
                }
            }
            else
            {
                // Eğer talimatlar boşsa bir uyarı göster
                MessageBox.Show("Tarif talimatları boş.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

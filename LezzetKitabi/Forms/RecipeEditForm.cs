using LezzetKitabi.Application.Services;
using LezzetKitabi.Data.Repositories.Abstract;
using LezzetKitabi.Domain.Dtos.CrossTableDtos;
using LezzetKitabi.Domain.Dtos.RecipeDtos;
using LezzetKitabi.Domain.Entities;
using LezzetKitabi.Domain.Enums;
using LezzetKitabi.Services.Abstract;
using LezzetKitabi.Services.Concrete;
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
        private readonly IRecipeService _recipeService;
        private List<Ingredient> _ingredients;
        public RecipeEditForm(RecipeViewGetDto recipe, IServiceProvider serviceProvider, List<Ingredient> ingredients)
        {
            _ingredients = ingredients;
            _recipe = recipe;
            _ingredientService = serviceProvider.GetRequiredService<IIngredientService>();
            _recipeService = serviceProvider.GetRequiredService<IRecipeService>();
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

        private async void button3_Click(object sender, EventArgs e)
        {
            // Create the RecipeUpdateDto object with the updated values from the form
            var recipeUpdateDto = new RecipeUpdateDto
            {
                Id = _recipe.Id,
                RecipeName = textBoxName.Text,
                PreparationTime = int.Parse(textBoxTime.Text),
                Category = comboBoxCatagory.SelectedItem.ToString(),
                //Instructions = GetInstructionsFromPanel(),
                //Ingredients = GetUpdatedIngredients() ?? new List<RecipeIngredientUpdateDto>() // Initialize list if null
            };


            // Call the service to update the recipe
            try
            {
                var result = await _recipeService.UpdateRecipe(recipeUpdateDto);

                if (result)
                {
                    MessageBox.Show("Tarif başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tarif güncellenemedi. Lütfen tekrar deneyiniz.", "Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private List<RecipeIngredientUpdateDto> GetUpdatedIngredients()
        {
            var updatedIngredients = new List<RecipeIngredientUpdateDto>();

            // Assuming panelIngredients contains labels and buttons for ingredients
            foreach (Control control in panelIngredients.Controls)
            {
                if (control is Label label)
                {
                    var ingredientData = label.Text.Split(' ');
                    string ingredientName = ingredientData[0];
                    decimal ingredientAmount = decimal.Parse(ingredientData[1]);
                    // Assuming you have a method to get IngredientID by name
                    var ingredientId = _ingredients.FirstOrDefault(i => i.IngredientName == ingredientName)?.Id;

                    if (ingredientId.HasValue)
                    {
                        updatedIngredients.Add(new RecipeIngredientUpdateDto
                        {
                            IngredientID = ingredientId.Value,
                            IngredientAmount = (float)ingredientAmount
                        });
                    }
                }
            }

            return updatedIngredients;
        }
        private string GetInstructionsFromPanel()
        {
            StringBuilder instructions = new StringBuilder();
            foreach (Control control in panelInstructions.Controls)
            {
                if (control is Label label)
                {
                    instructions.AppendLine(label.Text);
                }
            }
            return instructions.ToString();
        }
    }
}

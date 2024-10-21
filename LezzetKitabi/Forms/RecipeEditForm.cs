using LezzetKitabi.Application.Services;
using LezzetKitabi.Data.Repositories.Abstract;
using LezzetKitabi.Domain.Dtos.CrossTableDtos;
using LezzetKitabi.Domain.Dtos.IngredientDtos;
using LezzetKitabi.Domain.Dtos.RecipeDtos;
using LezzetKitabi.Domain.Entities;
using LezzetKitabi.Domain.Enums;
using LezzetKitabi.Services.Abstract;
using LezzetKitabi.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LezzetKitabi.Forms.Controls.RecipeAddControl;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LezzetKitabi.Forms
{
    public partial class RecipeEditForm : Form
    {
        private RecipeUpdateDto _recipe;
        private readonly IIngredientService _ingredientService;
        private readonly IRecipeService _recipeService;
        public RecipeEditForm(RecipeUpdateDto recipe, IServiceProvider serviceProvider)
        {
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

            
            using (MemoryStream ms = new MemoryStream(_recipe.Image))
            {
                Image img = Image.FromStream(ms);
                pictureBox1.Image = img;
            }
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            string[] instructions = _recipe.Instructions.Split(new[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            listBoxInstructions.Items.Clear();
            listBoxInstructions.Items.AddRange(instructions);

            listBoxIngredients.Items.Clear();
            foreach (var ingredient in _recipe.Ingredients)
            {
                string displayText = $"{ingredient.IngredientName} - {ingredient.TotalQuantity} - {ingredient.Unit}";
                listBoxIngredients.Items.Add(displayText);
            }
        }




        public async void LoadInstructionsAsync(string instructions)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            // Güncelleme için gerekli olan verileri al
            var recipeUpdateDto = new RecipeUpdateDto
            {
                Id = _recipe.Id, // Mevcut tarifin ID'si
                RecipeName = textBoxName.Text,
                Category = comboBoxCatagory.SelectedItem.ToString(), // Kategoriyi al
                PreparationTime = int.Parse(textBoxTime.Text), // Hazırlama süresini al
                Instructions = string.Join("\n", listBoxInstructions.Items.Cast<string>()), // Talimatları al
                                                                                            // Eğer resim eklemek istiyorsanız, aşağıdaki satırı kullanabilirsiniz
                                                                                            // Image = ConvertImageToByteArray(pictureBox1.Image), // Resmi byte dizisine çevir

                Ingredients = listBoxIngredients.Items.Cast<string>().Select(item =>
                {
                    var parts = item.Split(" - ");
                    return new IngredientGetDto
                    {
                        IngredientName = parts[0], // Malzeme adını al
                        TotalQuantity = parts[1], // Miktarı al
                        Unit = parts[2], // Birimi al
                                         // UnitPrice, kullanıcıdan alınmadığı için burada atanmadı, gerekirse eklenebilir
                                         // UnitPrice = GetUnitPrice(parts[0]) // Örneğin, malzeme adından birim fiyatı alabilirsiniz
                    };
                }).ToList()
            };

            // Tarifi güncelle
            bool result = await _recipeService.UpdateRecipe(recipeUpdateDto);

            if (result)
            {
                MessageBox.Show("Tarif başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Tarif güncellenirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonAddIngredient_Click(object sender, EventArgs e)
        {
            // ComboBox'tan seçilen malzeme bilgisini al
            var selectedIngredient = comboBoxIngredients.SelectedItem;

            if (selectedIngredient != null)
            {
                string ingredientName = ((Ingredient)selectedIngredient).IngredientName;
                Guid ingredientId = ((Ingredient)selectedIngredient).Id;

                if (int.TryParse(textBoxAmount.Text, out int amount))
                {
                    string displayText = $"{ingredientName} - {amount} - {((Ingredient)selectedIngredient).Unit}";

                    listBoxIngredients.Items.Add(displayText);

                }
                else
                {
                    MessageBox.Show("Lütfen geçerli bir miktar girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir malzeme seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void button4_Click(object sender, EventArgs e)
        {
            // TextBox'tan talimatı al
            string instruction = textBoxInstructions.Text.Trim();

            // Eğer talimat boş değilse
            if (!string.IsNullOrEmpty(instruction))
            {
                // ListBox'a ekle
                listBoxInstructions.Items.Add(instruction);

                // TextBox'ı temizle (isteğe bağlı)
                textBoxInstructions.Clear();
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir talimat girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void buttonIngredientDelete_Click(object sender, EventArgs e)
        {
        }

        private void buttonInstructuionDelete_Click(object sender, EventArgs e)
        {

        }
    }
}

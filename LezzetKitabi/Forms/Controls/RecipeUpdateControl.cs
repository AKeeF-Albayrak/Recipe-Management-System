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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using LezzetKitabi.Domain.Dtos.RecipeDtos;


namespace LezzetKitabi.Forms.Controls
{
    public partial class RecipeUpdateControl : UserControl
    {
        private readonly IIngredientService _ingredientService;
        private readonly IRecipeService _recipeService;
        public RecipeUpdateControl(IServiceProvider serviceProvider)
        {
            _ingredientService = serviceProvider.GetRequiredService<IIngredientService>();
            _recipeService = serviceProvider.GetRequiredService<IRecipeService>();
            SetUpCombobox();
            InitializeComponent();
            numericUpDownHours.Minimum = 0;
            numericUpDownHours.Maximum = 23;

            numericUpDownMinutes.Minimum = 0;
            numericUpDownMinutes.Maximum = 59;
        }

        private void buttonAddIngredient_Click(object sender, EventArgs e)
        {
            var selectedItem = comboBoxIngredients.SelectedItem as ComboBoxItem;

            if (selectedItem != null)
            {
                // Seçilen öğenin adı ve birimi
                string ingredientName = selectedItem.Text;
                string unit = selectedItem.Unit;
                string amount = textBoxAmount.Text;

                // Malzeme adı ve birimi birleştir
                string displayText = $"*{ingredientName} {amount} {unit}"; // "Malzeme Adı (Birim)" şeklinde

                // ListBox'a ekle
                listBoxIngredients.Items.Add(displayText); // Sadece metin olarak ekliyoruz
            }
            else
            {
                MessageBox.Show("Lütfen bir malzeme seçin.");
            }
        }

        private async void SetUpCombobox()
        {
            List<Ingredient> ingredients = await _ingredientService.GetAllIngredientsAsync(IngredientSortingType.A_from_Z);

            comboBoxIngredients.Items.Clear();

            foreach (var ingredient in ingredients)
            {
                // Yeni ComboBoxItem oluştur
                var item = new ComboBoxItem
                {
                    Text = ingredient.IngredientName,
                    Value = ingredient.Id,
                    Unit = ingredient.Unit,
                };

                comboBoxIngredients.Items.Add(item);
            }

            // ComboBox ayarları
            comboBoxIngredients.DisplayMember = "Text"; // Gösterilecek alan
            comboBoxIngredients.ValueMember = "Value"; // Seçilen öğenin değeri
        }
        public class ComboBoxItem
        {
            public string Text { get; set; }
            public Guid Value { get; set; }
            public string Unit { get; set; }
        }

        private void metroSetButton1_Click(object sender, EventArgs e)
        {
            var instructions = string.Join(Environment.NewLine, listBox1.Items.Cast<string>());

            var recipeAddDto = new RecipeAddDto
            {
                RecipeName = textBoxTitle.Text,
                Category = textBoxCategory.Text,
                PreparationTime = (int)(numericUpDownHours.Value * 60) + (int)numericUpDownMinutes.Value,
                Instructions = instructions
            };

            _recipeService.AddRecipe(recipeAddDto);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add((listBox1.Items.Count + 1) + " - " + textBox3.Text); // Sadece metin olarak ekliyoruz
            textBox3.Clear();
            MessageBox.Show("Yönerge Eklendi");
        }
    }
}

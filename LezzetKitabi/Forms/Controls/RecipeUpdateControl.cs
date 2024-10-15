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
using LezzetKitabi.Domain.Dtos.CrossTableDtos;


namespace LezzetKitabi.Forms.Controls
{
    public partial class RecipeUpdateControl : UserControl
    {
        private readonly IIngredientService _ingredientService;
        private readonly IRecipeService _recipeService;
        private readonly IRecipeIngredientService _recipeIngredientService;
        public RecipeUpdateControl(IServiceProvider serviceProvider)
        {
            _ingredientService = serviceProvider.GetRequiredService<IIngredientService>();
            _recipeService = serviceProvider.GetRequiredService<IRecipeService>();
            _recipeIngredientService = serviceProvider.GetRequiredService<IRecipeIngredientService>();
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
                string amountText = textBoxAmount.Text;

                // Miktarı float'a çevir
                if (float.TryParse(amountText, out float ingredientAmount))
                {
                    // Malzeme adı ve birimi birleştir
                    string displayText = $"- {ingredientName} {ingredientAmount} {unit}"; // "Malzeme Adı (Miktar Birimi)" şeklinde

                    // ListBox'a ekle
                    var listBoxItem = new ListBoxIngredient
                    {
                        DisplayText = displayText,
                        IngredientId = selectedItem.Value, // Burada ID'yi atıyoruz
                        Amount = ingredientAmount // Miktarı atıyoruz
                    };

                    listBoxIngredients.Items.Add(listBoxItem); // ListBox'a öğeyi ekle

                    // Başarılı ekleme sonrası kutuları temizle
                    textBoxAmount.Clear(); // Miktar kutusunu temizle
                    comboBoxIngredients.SelectedItem = null; // ComboBox'taki seçimi sıfırla
                }
                else
                {
                    MessageBox.Show("Lütfen geçerli bir miktar girin.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir malzeme seçin.");
            }
        }


        private async void SetUpCombobox()
        {
            List<Ingredient> ingredients = await _ingredientService.GetAllIngredientsByOrderAndFilterAsync(IngredientSortingType.A_from_Z);

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

        public class ListBoxIngredient
        {
            public string DisplayText { get; set; } // ListBox'ta gösterilecek metin
            public Guid IngredientId { get; set; } // Malzeme ID'si
            public float Amount { get; set; } // Malzeme miktarı

            public override string ToString() // ListBox'ta gösterilecek metni döndür
            {
                return DisplayText;
            }
        }

        private async void metroSetButton1_Click(object sender, EventArgs e)
        {
            var instructions = string.Join(Environment.NewLine, listBox1.Items.Cast<string>());

            var recipeName = textBoxTitle.Text;

            var existingRecipe = await _recipeService.GetRecipeByNameAsync(recipeName);

            if (existingRecipe != null)
            {
                MessageBox.Show("Bu isimde bir tarif zaten mevcut. Lütfen farklı bir isim deneyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var recipeAddDto = new RecipeAddDto
            {
                RecipeName = textBoxTitle.Text,
                Category = textBoxCategory.Text,
                PreparationTime = (int)(numericUpDownHours.Value * 60) + (int)numericUpDownMinutes.Value,
                Instructions = instructions
            };

            Guid id = _recipeService.AddRecipe(recipeAddDto);

            List<AddRecipeIngredientDto> recipeIngredients = new List<AddRecipeIngredientDto>();

            // ComboBox'taki her bir öğeyi dolaş
            foreach (ListBoxIngredient listBoxItem in listBoxIngredients.Items)
            {
                // ID'yi al
                Guid ingredientId = listBoxItem.IngredientId;

                // Miktarı al
                float ingredientAmount = listBoxItem.Amount;

                // RecipeIngredient DTO'su oluştur
                var recipeIngredient = new AddRecipeIngredientDto
                {
                    RecipeID = id,
                    IngredientID = ingredientId,
                    IngredientAmount = ingredientAmount // Burada miktarı al
                };

                // Listeye ekle
                recipeIngredients.Add(recipeIngredient);
            }
            await _recipeIngredientService.AddRangeAsync(recipeIngredients);

            MessageBox.Show("Tarif başarıyla eklendi!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Formdaki kutuları temizle
            comboBoxIngredients.SelectedItem = null;
            textBoxAmount.Clear();
            textBoxTitle.Clear();
            textBoxCategory.Clear();
            textBox3.Clear();
            listBox1.Items.Clear();
            listBoxIngredients.Items.Clear();
            numericUpDownHours.Value = 0;
            numericUpDownMinutes.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add((listBox1.Items.Count + 1) + " - " + textBox3.Text); // Sadece metin olarak ekliyoruz
            textBox3.Clear();
            //MessageBox.Show("Yönerge Eklendi");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*if (listBoxIngredients.SelectedItem != null)
            {
                listBoxIngredients.Items.Remove(listBoxIngredients.SelectedItem);
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz malzemeyi seçin.");
            }*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*if (listBox1.SelectedItem != null)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz yönergeyi seçin.");
            }*/
        }
    }
}

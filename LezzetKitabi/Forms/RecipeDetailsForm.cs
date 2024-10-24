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
        private readonly RecipeUpdateDto _recipe;
        public RecipeDetailsForm(RecipeUpdateDto recipeUpdateDto)
        {
            _recipe = recipeUpdateDto;
            InitializeComponent();
            LoadRecipeDetailsAsync();
        }
        public async void LoadRecipeDetailsAsync()
        {
            // Tarif bilgileri
            labelRecipeName.Text = _recipe.RecipeName;
            labelCategory.Text = _recipe.Category;
            labelPreparationTime.Text = $"{_recipe.PreparationTime} dakika";

            // Resmi yükleme
            using (MemoryStream ms = new MemoryStream(_recipe.Image))
            {
                Image img = Image.FromStream(ms);
                pictureBox1.Image = img;
            }
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            // Malzemeler kısmı
            panelIngredients.Controls.Clear(); // Paneli temizle
            panelIngredients.AutoScroll = true; // Kaydırma çubuğunu aktif et

            int startx = 10;
            int starty = 10;
            int gap = 10; // Sabit boşluk

            for (int i = 0; i < _recipe.Ingredients.Count; i++)
            {
                string ingredientText = $"•  {_recipe.Ingredients[i].TotalQuantity} {_recipe.Ingredients[i].Unit} {_recipe.Ingredients[i].IngredientName}";

                Label label = new Label
                {
                    Text = ingredientText, // Malzemeyi numaralandır
                    AutoSize = false,
                    MaximumSize = new Size(672, 0), // Genişlik sabit, yükseklik dinamik
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    Location = new Point(startx, starty),
                    TextAlign = ContentAlignment.TopLeft
                };

                label.Size = new Size(672, label.PreferredHeight); // Yüksekliği metne göre ayarla

                panelIngredients.Controls.Add(label);

                // Bir sonraki etiketin konumu
                starty += label.Height + gap; // Yükseklik + sabit boşluk
            }

            // Yönergeleri yükle
            LoadInstructionsAsync(_recipe.Instructions);
        }
        public async void LoadInstructionsAsync(string instructions)
        {
            if (!string.IsNullOrEmpty(instructions))
            {
                var instructionSteps = instructions.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

                panelInstructions.Controls.Clear();
                panelInstructions.AutoScroll = true; // Kaydırma çubuğunu etkinleştir

                int startx = 10;
                int starty = 10;
                int gap = 10; // Sabit boşluk (gap)

                for (int i = 0; i < instructionSteps.Length; i++)
                {
                    string instructionText = instructionSteps[i].Trim();

                    Label label = new Label
                    {
                        Text = $"{i + 1}. {instructionText}", // Madde numarası ekleniyor
                        AutoSize = false,
                        MaximumSize = new Size(672, 0), // Genişliği sabit tut, yükseklik ayarlanacak
                        Font = new Font("Arial", 12, FontStyle.Bold),
                        Location = new Point(startx, starty),
                        TextAlign = ContentAlignment.TopLeft
                    };

                    label.Size = new Size(672, label.PreferredHeight); // Metne göre yükseklik ayarlanıyor

                    panelInstructions.Controls.Add(label);

                    // Bir sonraki etiket için starty'yi güncelle
                    starty += label.Height + gap; // Etiketin yüksekliği kadar ilerlet ve sabit boşluk ekle
                }
            }
            else
            {
                MessageBox.Show("Tarif talimatları boş.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

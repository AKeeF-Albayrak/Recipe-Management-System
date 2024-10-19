using LezzetKitabi.Domain.Dtos.RecipeDtos;
using LezzetKitabi.Domain.Entities;
using LezzetKitabi.Domain.Enums;
using LezzetKitabi.Services.Abstract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LezzetKitabi.Domain.Dtos.CrossTableDtos;

namespace LezzetKitabi.Forms.Controls
{
    public partial class RecipeAddControl : UserControl
    {
        private readonly IIngredientService _ingredientService;
        private readonly IRecipeService _recipeService;
        private readonly IRecipeIngredientService _recipeIngredientService;
        private readonly IServiceProvider _serviceProvider;
        private bool isChanging = false;
        public RecipeAddControl(IServiceProvider serviceProvider)
        {
            _ingredientService = serviceProvider.GetRequiredService<IIngredientService>();
            _recipeService = serviceProvider.GetRequiredService<IRecipeService>();
            _recipeIngredientService = serviceProvider.GetRequiredService<IRecipeIngredientService>();
            _serviceProvider = serviceProvider;
            InitializeComponent();
            SetUpCombobox();
            SetUpCategoryComboBox();
            numericUpDownHours.Minimum = 0;
            numericUpDownHours.Maximum = 23;
            numericUpDownMinutes.Minimum = 0;
            numericUpDownMinutes.Maximum = 59;
        }
        private void SetUpCategoryComboBox()
        {
            comboBoxCategory.Items.Clear();

            foreach (var category in Enum.GetValues(typeof(Category)))
            {
                comboBoxCategory.Items.Add(category);
            }

            comboBoxCategory.SelectedIndex = -1;
        }
        private void buttonAddIngredient_Click(object sender, EventArgs e)
        {
            var selectedItem = comboBoxIngredients.SelectedItem as ComboBoxItem;

            if (selectedItem != null)
            {
                string ingredientName = selectedItem.Text;
                string unit = selectedItem.Unit;
                string amountText = textBoxAmount.Text;

                if (float.TryParse(amountText, out float ingredientAmount))
                {
                    string displayText = $"- {ingredientName} {ingredientAmount} {unit}";

                    var listBoxItem = new ListBoxIngredient
                    {
                        DisplayText = displayText,
                        IngredientId = selectedItem.Value,
                        Amount = ingredientAmount
                    };

                    listBoxIngredients.Items.Add(listBoxItem);

                    comboBoxIngredients.Items.Remove(selectedItem);

                    textBoxAmount.Clear();
                    comboBoxIngredients.SelectedItem = null;
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
        public async Task SetUpCombobox()
        {
            List<Ingredient> ingredients = await _ingredientService.GetAllIngredientsByOrderAndFilterAsync(IngredientSortingType.A_from_Z);

            comboBoxIngredients.Items.Clear();

            if (ingredients == null || !ingredients.Any())
            {
                MessageBox.Show("Malzeme bulunamadı! Lütfen önce bir malzeme ekleyin.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var ingredientControl = _serviceProvider.GetRequiredService<IngredientAddControl>();

                var parentForm = this.FindForm();

                if (parentForm != null)
                {
                    ingredientControl.Dock = DockStyle.Fill;
                    parentForm.Controls.Add(ingredientControl);
                    ingredientControl.BringToFront();
                }

                return;
            }

            foreach (var ingredient in ingredients)
            {
                var item = new ComboBoxItem
                {
                    Text = ingredient.IngredientName,
                    Value = ingredient.Id,
                    Unit = ingredient.Unit,
                };

                comboBoxIngredients.Items.Add(item);
            }

            comboBoxIngredients.DisplayMember = "Text";
            comboBoxIngredients.ValueMember = "Value";
        }
        public class ListBoxIngredient
        {
            public string DisplayText { get; set; }
            public Guid IngredientId { get; set; }
            public float Amount { get; set; }

            public override string ToString()
            {
                return DisplayText;
            }
        }
        private async void metroSetButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxTitle.Text))
            {
                MessageBox.Show("Lütfen tarif ismini girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxTitle.Focus();
                return;
            }

            if (comboBoxCategory.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir kategori seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numericUpDownHours.Value == 0 && numericUpDownMinutes.Value == 0)
            {
                MessageBox.Show("Lütfen hazırlama süresini girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (listBoxIngredients.Items.Count == 0)
            {
                MessageBox.Show("Lütfen en az bir malzeme ekleyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("Lütfen talimatları girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
                Category = comboBoxCategory.SelectedItem.ToString(),
                PreparationTime = (int)(numericUpDownHours.Value * 60) + (int)numericUpDownMinutes.Value,
                Instructions = instructions
            };

            Guid id = _recipeService.AddRecipe(recipeAddDto);

            List<AddRecipeIngredientDto> recipeIngredients = new List<AddRecipeIngredientDto>();

            foreach (ListBoxIngredient listBoxItem in listBoxIngredients.Items)
            {
                Guid ingredientId = listBoxItem.IngredientId;

                float ingredientAmount = listBoxItem.Amount;

                var recipeIngredient = new AddRecipeIngredientDto
                {
                    RecipeID = id,
                    IngredientID = ingredientId,
                    IngredientAmount = ingredientAmount
                };

                recipeIngredients.Add(recipeIngredient);
            }
            await _recipeIngredientService.AddRangeAsync(recipeIngredients);

            MessageBox.Show("Tarif başarıyla eklendi!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

            comboBoxIngredients.SelectedItem = null;
            textBoxAmount.Clear();
            textBoxTitle.Clear();
            comboBoxCategory.SelectedItem = null;
            textBox3.Clear();
            listBox1.Items.Clear();
            listBoxIngredients.Items.Clear();
            numericUpDownHours.Value = 0;
            numericUpDownMinutes.Value = 0;

            await SetUpCombobox();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("Lutfen Gecerli Bir Yonerge Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                listBox1.Items.Add((listBox1.Items.Count + 1) + " - " + textBox3.Text);
                textBox3.Clear();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBoxIngredients.SelectedItem != null)
            {
                var selectedItem = (ListBoxIngredient)listBoxIngredients.SelectedItem;

                if (selectedItem != null)
                {
                    listBoxIngredients.Items.Remove(selectedItem);

                    comboBoxIngredients.Items.Add(new ComboBoxItem
                    {
                        Text = selectedItem.DisplayText.Split(' ')[1],
                        Value = selectedItem.IngredientId,
                        Unit = selectedItem.DisplayText.Split(' ').Last()
                    });
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz malzemeyi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz talimatı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void listBoxIngredients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isChanging) return;

            if (listBoxIngredients.SelectedIndex != -1)
            {
                isChanging = true;

                listBox1.ClearSelected();

                isChanging = false;
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isChanging) return;

            if (listBox1.SelectedIndex != -1)
            {
                isChanging = true;

                listBoxIngredients.ClearSelected();

                isChanging = false;
            }
        }
        private void textBoxAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }
    }
}

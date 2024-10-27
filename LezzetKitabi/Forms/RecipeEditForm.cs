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
        private bool isChanging = false;
        public event EventHandler RecipeUpdated;
        public RecipeEditForm(RecipeUpdateDto recipe, IServiceProvider serviceProvider)
        {
            _recipe = recipe;
            _ingredientService = serviceProvider.GetRequiredService<IIngredientService>();
            _recipeService = serviceProvider.GetRequiredService<IRecipeService>();
            InitializeComponent();
            LoadRecipe();
        }

        public class ListBoxIngredient
        {
            public Guid IngredientId { get; set; }
            public string IngredientName { get; set; }
            public string Amount { get; set; }
            public string Unit { get; set; }

            public string UnitPrice { get; set; }

            public override string ToString()
            {
                return $"{IngredientName} - {Amount} {Unit}";
            }
        }
        public async void LoadRecipe()
        {
            textBoxName.Text = _recipe.RecipeName;
            textBoxTime.Text = _recipe.PreparationTime.ToString();

            var ingredients = await _ingredientService.GetAllIngredientsByOrderAndFilterAsync(IngredientSortingType.A_from_Z);

            var availableIngredients = ingredients
                .Where(i => !_recipe.Ingredients.Any(recipeIngredient => recipeIngredient.Id == i.Id))
                .ToList();

            comboBoxIngredients.DataSource = availableIngredients;
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
                var listBoxItem = new ListBoxIngredient
                {
                    IngredientId = ingredient.Id,
                    IngredientName = ingredient.IngredientName,
                    Amount = ingredient.TotalQuantity,
                    Unit = ingredient.Unit,
                    UnitPrice = ingredient.UnitPrice.ToString()
                };

                listBoxIngredients.Items.Add(listBoxItem);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            RecipeUpdated?.Invoke(this, EventArgs.Empty);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "" || textBoxTime.Text == "" || listBoxIngredients.Items.Count == 0 || listBoxInstructions.Items.Count == 0)
            {
                MessageBox.Show("Tarif güncellenirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var recipeUpdateDto = new RecipeUpdateDto
            {
                Id = _recipe.Id,
                RecipeName = textBoxName.Text,
                Category = comboBoxCatagory.SelectedItem.ToString(),
                PreparationTime = int.Parse(textBoxTime.Text),
                Image = _recipe.Image,
                Instructions = string.Join("\n", listBoxInstructions.Items.Cast<string>()),

                Ingredients = listBoxIngredients.Items.Cast<ListBoxIngredient>().Select(item =>
                {
                    return new IngredientGetDto
                    {
                        Id = item.IngredientId,
                        IngredientName = item.IngredientName,
                        TotalQuantity = item.Amount,
                        Unit = item.Unit.ToString(),
                        UnitPrice = decimal.Parse(item.UnitPrice)
                    };
                }).ToList()
            };

            bool result = await _recipeService.UpdateRecipeAsync(recipeUpdateDto);

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
            var selectedIngredient = comboBoxIngredients.SelectedItem as Ingredient;

            if (selectedIngredient != null)
            {
                string ingredientName = selectedIngredient.IngredientName;
                Guid ingredientId = selectedIngredient.Id;

                string amount = textBoxAmount.Text;

                if (!string.IsNullOrWhiteSpace(amount))
                {
                    var listBoxItem = new ListBoxIngredient
                    {
                        IngredientId = ingredientId,
                        IngredientName = ingredientName,
                        Amount = amount,
                        Unit = selectedIngredient.Unit,
                        UnitPrice = selectedIngredient.UnitPrice.ToString()
                    };

                    listBoxIngredients.Items.Add(listBoxItem);

                    var ingredientList = comboBoxIngredients.DataSource as List<Ingredient>;
                    if (ingredientList != null)
                    {
                        ingredientList.Remove(selectedIngredient);

                        comboBoxIngredients.DataSource = null;
                        comboBoxIngredients.DataSource = ingredientList;
                        comboBoxIngredients.DisplayMember = "IngredientName";
                    }
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



        private void buttonIngredientDelete_Click(object sender, EventArgs e)
        {
            if (listBoxIngredients.SelectedItem is ListBoxIngredient selectedItem)
            {
                var ingredientToRestore = new Ingredient
                {
                    Id = selectedItem.IngredientId,
                    IngredientName = selectedItem.IngredientName,
                    Unit = selectedItem.Unit,
                    UnitPrice = decimal.Parse(selectedItem.UnitPrice)
                };

                var ingredientList = comboBoxIngredients.DataSource as List<Ingredient>;
                if (ingredientList != null)
                {
                    ingredientList.Add(ingredientToRestore);

                    comboBoxIngredients.DataSource = null;
                    comboBoxIngredients.DataSource = ingredientList;
                    comboBoxIngredients.DisplayMember = "IngredientName";
                }

                listBoxIngredients.Items.Remove(selectedItem);
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz malzemeyi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }




        private void button4_Click(object sender, EventArgs e)
        {
            string instruction = textBoxInstructions.Text.Trim();

            if (!string.IsNullOrEmpty(instruction))
            {
                listBoxInstructions.Items.Add(instruction);

                textBoxInstructions.Clear();
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir talimat girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        

        private void buttonInstructuionDelete_Click(object sender, EventArgs e)
        {
            if (listBoxInstructions.SelectedItem != null)
            {
                listBoxInstructions.Items.Remove(listBoxInstructions.SelectedItem);
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz talimatı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void listBoxInstructions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isChanging) return;

            if (listBoxInstructions.SelectedIndex != -1)
            {
                isChanging = true;

                listBoxIngredients.ClearSelected();

                isChanging = false;
            }
        }

        private void listBoxIngredients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isChanging) return;

            if (listBoxIngredients.SelectedIndex != -1)
            {
                isChanging = true;

                listBoxInstructions.ClearSelected();

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

using LezzetKitabi.Domain.Entities;
using LezzetKitabi.Domain.Enums;
using LezzetKitabi.Forms.Controls;
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
    public partial class IngredientEditForm : Form
    {
        private readonly IIngredientService _ingredientService;
        private Ingredient ingredient1;
        public event EventHandler IngredientUpdated;
        public IngredientEditForm(IIngredientService ingredientService)
        {
            InitializeComponent();
            _ingredientService = ingredientService;
            comboBoxUnit.DataSource = Enum.GetValues(typeof(UnitType));
        }
        public async void LoadIngredientDetails(Ingredient ingredient)
        {
            ingredient1 = ingredient;
            textBoxIngredientName.Text = ingredient.IngredientName;
            textBoxAmount.Text = ingredient.TotalQuantity;
            textBoxUnitPrice.Text = ingredient.UnitPrice.ToString();
            comboBoxUnit.SelectedItem = ingredient.Unit;

            if (ingredient.Image != null)
            {
                using (MemoryStream ms = new MemoryStream(ingredient.Image))
                {
                    Image img = Image.FromStream(ms);
                    pictureBoxIngredient.Image = img;
                }
            }

            pictureBoxIngredient.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            IngredientUpdated?.Invoke(this, EventArgs.Empty);
        }
        private async void buttonEdit_Click(object sender, EventArgs e)
        {
            Ingredient updatedIngredient = new Ingredient
            {
                Id = ingredient1.Id,
                IngredientName = textBoxIngredientName.Text,
                TotalQuantity = textBoxAmount.Text,
                UnitPrice = decimal.TryParse(textBoxUnitPrice.Text, out var unitPrice) ? unitPrice : 0,
                Unit = comboBoxUnit.SelectedItem.ToString()
            };
            bool isUpdated = await _ingredientService.UpdateIngredientAsync(updatedIngredient);
            if (isUpdated)
            {
                MessageBox.Show("Malzeme Basariyla Duzenlendi!", "Basarili", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                LoadIngredientDetails(updatedIngredient);
            }
        }
    }
}

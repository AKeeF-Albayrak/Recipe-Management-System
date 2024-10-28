using LezzetKitabi.Domain.Dtos.IngredientDtos;
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
        private IngredientUpdateDto ingredient1;
        public event EventHandler IngredientUpdated;
        private string _selectedImagePath;
        public IngredientEditForm(IIngredientService ingredientService)
        {
            InitializeComponent();
            _ingredientService = ingredientService;
            comboBoxUnit.DataSource = Enum.GetValues(typeof(UnitType));
        }
        public async void LoadIngredientDetails(IngredientUpdateDto ingredient)
        {
            ingredient1 = ingredient;
            textBoxIngredientName.Text = ingredient.IngredientName;
            textBoxAmount.Text = ingredient.TotalQuantity;
            textBoxUnitPrice.Text = ingredient.UnitPrice.ToString();
            comboBoxUnit.SelectedItem = (UnitType)Enum.Parse(typeof(UnitType), ingredient.Unit);

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
            IngredientUpdateDto updatedIngredient = new IngredientUpdateDto
            {
                Id = ingredient1.Id,
                IngredientName = textBoxIngredientName.Text,
                TotalQuantity = textBoxAmount.Text,
                UnitPrice = decimal.TryParse(textBoxUnitPrice.Text, out var unitPrice) ? unitPrice : 0,
                Unit = comboBoxUnit.SelectedItem.ToString(),
                Image = _selectedImagePath != null ? ConvertImageToBytes(_selectedImagePath) : ingredient1.Image,
            };
            bool isUpdated = await _ingredientService.UpdateIngredientAsync(updatedIngredient);
            if (isUpdated)
            {
                MessageBox.Show("Malzeme Basariyla Duzenlendi!", "Basarili", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Basarisiz");
                LoadIngredientDetails(updatedIngredient);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _selectedImagePath = openFileDialog.FileName;
                pictureBoxIngredient.Image = Image.FromFile(_selectedImagePath);
            }
        }

        private byte[] ConvertImageToBytes(string filePath)
        {
            return File.ReadAllBytes(filePath);
        }
    }
}

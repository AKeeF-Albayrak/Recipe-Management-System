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
using MetroSet_UI.Controls;
using LezzetKitabi.Domain.Dtos.IngredientDtos;
using LezzetKitabi.Domain.Enums;
using LezzetKitabi.Domain.Contracts;

namespace LezzetKitabi.Forms.Controls
{
    public partial class IngredientAddControl : UserControl
    {
        public event EventHandler IngredientChanged;
        private readonly IIngredientService _ingredientService;
        private string _selectedImagePath;

        public IngredientAddControl(IServiceProvider serviceProvider)
        {
            _ingredientService = serviceProvider.GetRequiredService<IIngredientService>();
            InitializeComponent();
            cmbUnit.DataSource = Enum.GetValues(typeof(UnitType));
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void OnIngredientsChanged()
        {
            IngredientChanged?.Invoke(this, EventArgs.Empty);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIngredientName.Text) ||
                string.IsNullOrWhiteSpace(txtTotalQuantity.Text) ||
                string.IsNullOrWhiteSpace(txtUnitPrice.Text) ||
                cmbUnit.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                return;
            }

            IngredientAddDto ingredient = new IngredientAddDto()
            {
                IngredientName = txtIngredientName.Text,
                TotalQuantity = txtTotalQuantity.Text,
                Unit = cmbUnit.SelectedItem.ToString(),
                Image = _selectedImagePath != null ? ConvertImageToBytes(_selectedImagePath) : GlobalVariables.BaseIngredientImage,
            };

            if (int.TryParse(txtTotalQuantity.Text, out int totalQuantity))
            {
                ingredient.TotalQuantity = totalQuantity.ToString();

                if (decimal.TryParse(txtUnitPrice.Text, out decimal unitPrice))
                {
                    ingredient.UnitPrice = unitPrice;

                    bool isAdded = _ingredientService.AddIngredient(ingredient);
                    if (isAdded)
                    {
                        MessageBox.Show("Malzeme Başarıyla Kaydedildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OnIngredientsChanged();
                    }
                    else
                    {
                        MessageBox.Show("Böyle Bir Malzeme Zaten Kayıtlı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    txtIngredientName.Clear();
                    txtTotalQuantity.Clear();
                    txtUnitPrice.Clear();
                    cmbUnit.SelectedIndex = -1;
                    pictureBox1.Image = null;
                    _selectedImagePath = null;
                }
                else
                {
                    MessageBox.Show("Lütfen geçerli bir fiyat giriniz.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir miktar giriniz.");
            }
        }

        private byte[] ConvertImageToBytes(string filePath)
        {
            return File.ReadAllBytes(filePath);
        }

        private void txtTotalQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _selectedImagePath = openFileDialog.FileName;
                pictureBox1.Image = Image.FromFile(_selectedImagePath);
            }
        }
    }
}

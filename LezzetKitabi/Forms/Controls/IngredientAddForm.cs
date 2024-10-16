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

namespace LezzetKitabi.Forms.Controls
{
    public partial class IngredientAddForm : UserControl
    {
        private readonly IIngredientService _ingredientService;
        public IngredientAddForm(IServiceProvider serviceProvider)
        {
            _ingredientService = serviceProvider.GetRequiredService<IIngredientService>();
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            IngredientAddDto ingredient = new IngredientAddDto()
            {
                IngredientName = txtIngredientName.Text,
                TotalQuantity = txtTotalQuantity.Text,
                Unit = txtUnit.Text,
            };

            // UnitPrice'ı decimal'e çevirme
            if (decimal.TryParse(txtUnitPrice.Text, out decimal unitPrice))
            {
                ingredient.UnitPrice = unitPrice;
                _ingredientService.AddIngredient(ingredient);
                txtIngredientName.Clear();
                txtTotalQuantity.Clear();
                txtUnit.Clear();
            }
            else
            {
                // Dönüşüm başarısız olursa, hata mesajı gösterilebilir
                MessageBox.Show("Lütfen geçerli bir fiyat giriniz.");
            }

            // TextBox'ları temizle
            txtUnitPrice.Clear();
        }

    }
}

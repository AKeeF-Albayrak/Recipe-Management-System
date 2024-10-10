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
    public partial class IngredientControl : UserControl
    {
        private readonly IIngredientService _ingredientService;
        public IngredientControl(IServiceProvider serviceProvider)
        {
            _ingredientService = serviceProvider.GetRequiredService<IIngredientService>();
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            // Sütunları tanımla
            dataGridView.ColumnCount = 4;
            dataGridView.Columns[0].Name = "Malzeme Adı";
            dataGridView.Columns[1].Name = "Toplam Miktar";
            dataGridView.Columns[2].Name = "Birim";
            dataGridView.Columns[3].Name = "Birim Fiyatı";

            // Düzenleme ve Silme Butonlarını ekle
            DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
            editButton.Name = "Düzenle";
            editButton.Text = "Düzenle";
            editButton.UseColumnTextForButtonValue = true;
            dataGridView.Columns.Add(editButton);

            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "Sil";
            deleteButton.Text = "Sil";
            deleteButton.UseColumnTextForButtonValue = true;
            dataGridView.Columns.Add(deleteButton);

            // Hücre çizgilerini göster
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridView.GridColor = Color.Black;

            // CellClick olayını yakala
            dataGridView.CellClick += dataGridView_CellClick;
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
            }
            else
            {
                // Dönüşüm başarısız olursa, hata mesajı gösterilebilir
                MessageBox.Show("Lütfen geçerli bir fiyat giriniz.");
            }

            _ingredientService.AddIngredient(ingredient);

            // TextBox'ları temizle
            txtIngredientName.Clear();
            txtTotalQuantity.Clear();
            txtUnit.Clear();
            txtUnitPrice.Clear();
        }

        // CellClick olayında silme işlemi
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Sil sütununa tıklandıysa
            if (e.ColumnIndex == dataGridView.Columns["Sil"].Index && e.RowIndex >= 0)
            {
                // İlgili satırı sil
                dataGridView.Rows.RemoveAt(e.RowIndex);
            }
        }
    }
}

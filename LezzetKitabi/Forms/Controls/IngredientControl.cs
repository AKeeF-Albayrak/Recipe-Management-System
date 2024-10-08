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

namespace LezzetKitabi.Forms.Controls
{
    public partial class IngredientControl : UserControl
    {
        private readonly IServiceProvider _serviceProvider;
        public IngredientControl(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
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
            // Yeni veri ekle
            string[] row = new string[]
            {
                txtIngredientName.Text,
                txtTotalQuantity.Text,
                txtUnit.Text,
                txtUnitPrice.Text
            };
            dataGridView.Rows.Add(row);

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

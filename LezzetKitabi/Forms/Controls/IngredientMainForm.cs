using LezzetKitabi.Application.Services;
using LezzetKitabi.Domain.Contracts;
using LezzetKitabi.Domain.Entities;
using LezzetKitabi.Domain.Enums;
using LezzetKitabi.Services.Abstract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LezzetKitabi.Forms.Controls
{
    public partial class IngredientMainForm : UserControl
    {
        private readonly IIngredientService _ingredientService;
        IngredientSortingType _sortingType = IngredientSortingType.A_from_Z;
        private List<FilterCriteria> filterCriteriaList;

        public IngredientMainForm(IServiceProvider serviceProvider)
        {
            filterCriteriaList = new List<FilterCriteria>();
            _ingredientService = serviceProvider.GetRequiredService<IIngredientService>();
            InitializeComponent();
            InitializeGradientPanel(panelElements);
            InitializeCustomPanelsAsync();
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            Color panelBackground = Color.FromArgb(50, Color.DarkRed);
            panelItems.BackColor = panelBackground;
            panelFilter.BackColor = Color.White;
            // Arka plan rengini transparent yapın
            panelElements.BackColor = Color.Transparent;
            panelDown.BackColor = Color.Transparent;
            comboBoxUnit.Items.AddRange(Enum.GetNames(typeof(UnitType)));
        }

        private async Task InitializeCustomPanelsAsync()
        {
            int rows = 3;  // 3 rows
            int cols = 6;  // 6 columns
            int panelWidth = 160;  // Panel width
            int panelHeight = 190; // Panel height
            int xPadding = 12;  // Horizontal padding between panels
            int yPadding = 12;  // Vertical padding between panels
            int startX = 10; // Starting X position
            int startY = 10; // Starting Y position
            int cornerRadius = 20;  // Yuvarlak köşe yarıçapı

            // Filtreleme işlemi için servisi çağır
            List<Ingredient> ingredients = await _ingredientService.GetAllIngredientsByOrderAndFilterAsync(_sortingType, filterCriteriaList);

            if (ingredients == null || ingredients.Count == 0)
            {
                MessageBox.Show("No ingredients found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (int i = 0; i < Math.Min(ingredients.Count, rows * cols); i++)
            {
                int row = i / cols;
                int col = i % cols;

                // Ana panel oluştur
                Panel mainPanel = new Panel();
                mainPanel.Tag = ingredients[i];
                mainPanel.BackColor = Color.Transparent;  // Şeffaf arka plan
                mainPanel.Size = new Size(panelWidth, panelHeight);
                int x = startX + col * (panelWidth + xPadding);
                int y = startY + row * (panelHeight + yPadding);
                mainPanel.Location = new Point(x, y);

                // Panelin arkaplanını Paint ile yuvarlatılmış olarak çizin
                mainPanel.Paint += (s, e) =>
                {
                    Graphics g = e.Graphics;
                    Rectangle rect = mainPanel.ClientRectangle;
                    g.SmoothingMode = SmoothingMode.AntiAlias;

                    // Yuvarlatılmış dikdörtgen oluştur
                    using (GraphicsPath path = CreateRoundedRectanglePath(rect, cornerRadius))
                    {
                        using (Brush brush = new SolidBrush(SystemColors.ActiveCaption))
                        {
                            g.FillPath(brush, path);  // Arka planı doldur
                        }
                    }
                };

                // Fare olaylarını ayarla
                mainPanel.MouseEnter += (s, e) => BringToFront(mainPanel);
                mainPanel.MouseLeave += (s, e) => CheckMouseLeave(mainPanel);

                // PictureBox ve diğer öğeleri ekle
                PictureBox pictureBox = new PictureBox();
                if(i == 1)
                {
                    pictureBox.Image = Properties.Resources.domates;
                }
                else
                {
                    pictureBox.Image = Properties.Resources.Screenshot_2024_10_09_121511; // Resmi dinamik hale getirin
                }
                pictureBox.Size = new Size(115, 94);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Location = new Point((panelWidth - pictureBox.Width) / 2, 35);  // Ortalayın

                Label label = new Label();
                label.AutoSize = true;
                label.Text = ingredients[i].IngredientName; // Dinamik malzeme adı
                label.Location = new Point((panelWidth - label.Width) / 2, 12);  // Ortalayın

                Label labelMiktar = new Label();
                labelMiktar.AutoSize = true;
                labelMiktar.Text = $"{ingredients[i].TotalQuantity} {ingredients[i].Unit}"; // Dinamik miktar
                labelMiktar.Location = new Point((panelWidth - labelMiktar.Width) / 2, pictureBox.Bottom + 5);

                Label labelBirimFiyati = new Label();
                labelBirimFiyati.AutoSize = true;
                labelBirimFiyati.Text = $"{ingredients[i].UnitPrice:C}"; // Dinamik birim fiyatı
                labelBirimFiyati.Location = new Point((panelWidth - labelBirimFiyati.Width) / 2, labelMiktar.Bottom + 5);

                // Overlay paneli oluşturun
                Panel overlayPanel = new Panel();
                overlayPanel.BackColor = Color.Purple;  // Overlay panel rengi
                overlayPanel.Size = new Size(panelWidth, panelHeight);
                overlayPanel.Location = new Point(0, 0);
                overlayPanel.Visible = false;

                // Yuvarlatılmış köşe overlay panel için de Paint olayında çizim
                overlayPanel.Paint += (s, e) =>
                {
                    Graphics g = e.Graphics;
                    Rectangle rect = overlayPanel.ClientRectangle;
                    g.SmoothingMode = SmoothingMode.AntiAlias;

                    // Yuvarlatılmış dikdörtgen oluştur
                    using (GraphicsPath path = CreateRoundedRectanglePath(rect, cornerRadius))
                    {
                        using (Brush brush = new SolidBrush(Color.Purple))
                        {
                            g.FillPath(brush, path);  // Paneli doldurun
                        }

                        // Panelin görünümünü yuvarlak yap
                        overlayPanel.Region = new Region(path);
                    }
                };

                // Butonlar ve diğer elemanlar overlay paneline eklenebilir
                Button button1 = new Button();
                button1.Text = "Button 1";
                button1.Size = new Size(80, 30);
                button1.Location = new Point(10, 10);

                Button buttonDelete = new Button();
                buttonDelete.Text = "Delete";
                buttonDelete.Size = new Size(80, 30);
                buttonDelete.Location = new Point(100, 10);
                buttonDelete.Tag = ingredients[i];
                buttonDelete.Click += DeleteButton_Click;

                overlayPanel.Controls.Add(button1);
                overlayPanel.Controls.Add(buttonDelete);

                // Ana paneli içerikleriyle birlikte ekleyin
                mainPanel.Controls.Add(label);
                mainPanel.Controls.Add(pictureBox);
                mainPanel.Controls.Add(labelMiktar);
                mainPanel.Controls.Add(labelBirimFiyati);
                mainPanel.Controls.Add(overlayPanel);

                // Ana paneli panelItems'a ekleyin
                panelItems.Controls.Add(mainPanel);
            }
        }

        private async void ComboBoxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Seçilen index'e göre sortingType'ı ayarlama
            switch (comboBoxSort.SelectedIndex)
            {
                case 0:
                    _sortingType = IngredientSortingType.A_from_Z;
                    break;
                case 1:
                    _sortingType = IngredientSortingType.Z_from_A;
                    break;
                case 2:
                    _sortingType = IngredientSortingType.Cheapest_to_Expensive;
                    break;
                case 3:
                    _sortingType = IngredientSortingType.Expensive_to_Cheapest;
                    break;
                /*case 4:
                    _sortingType = IngredientSortingType.DescendingStock;
                    break;
                case 5:
                    _sortingType = IngredientSortingType.AscendingStock;
                    break;*/
                default:
                    _sortingType = IngredientSortingType.A_from_Z;
                    break;
            }
            RefreshPanelsAsync();
        }
        private GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int cornerRadius)
        {
            GraphicsPath path = new GraphicsPath();
            int arcDiameter = cornerRadius * 2;

            path.AddArc(rect.X, rect.Y, arcDiameter, arcDiameter, 180, 90); // Sol üst köşe
            path.AddArc(rect.Right - arcDiameter, rect.Y, arcDiameter, arcDiameter, 270, 90); // Sağ üst köşe
            path.AddArc(rect.Right - arcDiameter, rect.Bottom - arcDiameter, arcDiameter, arcDiameter, 0, 90); // Sağ alt köşe
            path.AddArc(rect.X, rect.Bottom - arcDiameter, arcDiameter, arcDiameter, 90, 90); // Sol alt köşe

            path.CloseFigure();
            return path;
        }

        // Fare panelin içine girdiğinde üstteki paneli göster
        private void BringToFront(Panel panel)
        {
            Panel overlayPanel = panel.Controls.OfType<Panel>().FirstOrDefault(p => p.BackColor == Color.Purple);
            if (overlayPanel != null)
            {
                overlayPanel.Visible = true; // Üstteki paneli göster
                overlayPanel.BringToFront(); // Üstteki paneli öne getir
                overlayPanel.MouseEnter += (s, e) => overlayPanel.Visible = true; // Üstteki panelin fare üzerinde kalmasını sağla
                overlayPanel.MouseLeave += (s, e) => overlayPanel.Visible = false; // Fare üstteyken gizleme
            }
        }

        // Fare panelden çıktığında, mor panel görünüyorsa geri gelmesini kontrol et
        private void CheckMouseLeave(Panel panel)
        {
            Panel overlayPanel = panel.Controls.OfType<Panel>().FirstOrDefault(p => p.BackColor == Color.Purple);
            if (overlayPanel != null && overlayPanel.Visible)
            {
                // Mor panel gizli ise ana paneli göster
                if (!overlayPanel.ClientRectangle.Contains(overlayPanel.PointToClient(MousePosition)))
                {
                    overlayPanel.Visible = false; // Üstteki paneli gizle
                }
            }
        }

        private void InitializeGradientPanel(Panel panel)
        {
            panel.Paint += (s, e) =>
            {
                // Gradient için başlangıç ve bitiş renkleri
                Color startColor = Color.FromArgb(200, 255, 165, 0); // Mat turuncu
                Color endColor = Color.FromArgb(255, 255, 99, 71); // Açık kırmızı (tomato rengi)

                // Degrade oluştur
                using (LinearGradientBrush brush = new LinearGradientBrush(panel.ClientRectangle, startColor, endColor, 45f))
                {
                    e.Graphics.FillRectangle(brush, panel.ClientRectangle);
                }
            };
        }

        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            Button deleteButton = sender as Button;

            if (deleteButton != null)
            {
                // Delete butonunun Tag'inde hangi ingredient olduğunu al
                Ingredient ingredientToDelete = deleteButton.Tag as Ingredient;

                if (ingredientToDelete != null)
                {
                    bool isDeleted = await Task.Run(() => _ingredientService.DeleteIngredient(ingredientToDelete.Id)); // Silme işlemini async hale getir

                    if (isDeleted)
                    {
                        MessageBox.Show("Ingredient deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await RefreshPanelsAsync();  // Panel yenileme işlemini async yap
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the ingredient.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public async Task RefreshPanelsAsync()
        {
            panelItems.Controls.Clear();

            await InitializeCustomPanelsAsync();  // Bu işlemi de async yaparak UI'nin kilitlenmesini önleyin
        }

        

        // Formda filtre kriterlerini tutan liste


        private void buttonPriceRangeAdd_Click(object sender, EventArgs e)
        {
            // Fiyat aralığı değerlerini al
            decimal? minPrice = null;
            decimal? maxPrice = null;

            // Minimum fiyatı kontrol et
            if (decimal.TryParse(textBoxMinPrice.Text, out decimal minPriceValue))
            {
                minPrice = minPriceValue;
            }

            // Maksimum fiyatı kontrol et (boşsa null bırak)
            if (decimal.TryParse(textBoxMaxPrice.Text, out decimal maxPriceValue))
            {
                maxPrice = maxPriceValue;
            }

            // Eğer minimum fiyat var ise ve maksimum fiyat varsa, kontrol et
            if (minPrice.HasValue && maxPrice.HasValue && minPrice.Value > maxPrice.Value)
            {
                MessageBox.Show("Minimum fiyat maksimum fiyatı geçemez.");
                return;
            }

            // Fiyat filtresini kontrol et ve gerekirse sil
            RemoveExistingFilter("Fiyat");

            // Yeni filtreyi listeye ekle
            if (minPrice.HasValue || maxPrice.HasValue)
            {
                filterCriteriaList.Add(new FilterCriteria { FilterType = "Fiyat", Value = $"{minPrice} - {maxPrice}" });
                // Yeni filtreyi panelCurrentFilter'a ekle
                AddFilterToPanel($"Fiyat: {minPrice} - {maxPrice}", RemoveFilter);
            }
        }

        private void buttonStockRangeAdd_Click(object sender, EventArgs e)
        {
            // Stok aralığı değerlerini al
            int? minStock = null;
            int? maxStock = null;

            // Minimum stok değerini kontrol et
            if (int.TryParse(textBoxMinStock.Text, out int minStockValue))
            {
                minStock = minStockValue;
            }

            // Maksimum stok değerini kontrol et (boşsa null bırak)
            if (int.TryParse(textBoxMaxStock.Text, out int maxStockValue))
            {
                maxStock = maxStockValue;
            }

            // Eğer minimum stok var ise ve maksimum stok varsa, kontrol et
            if (minStock.HasValue && maxStock.HasValue && minStock.Value > maxStock.Value)
            {
                MessageBox.Show("Minimum stok maksimum stok değerini geçemez.");
                return;
            }

            // Stok filtresini kontrol et ve gerekirse sil
            RemoveExistingFilter("Stok");

            // Yeni filtreyi listeye ekle
            // Eğer sadece minStock veya maxStock varsa, filtreyi uygun bir şekilde ekleyin
            if (minStock.HasValue || maxStock.HasValue)
            {
                filterCriteriaList.Add(new FilterCriteria { FilterType = "Stok", Value = $"{minStock} - {maxStock}" });
                // Yeni filtreyi panelCurrentFilter'a ekle
                AddFilterToPanel($"Stok: {minStock} - {maxStock}", RemoveFilter);
            }
        }

        private void buttonUnitAdd_Click(object sender, EventArgs e)
        {
            // ComboBox'dan birim değerini al
            string unit = comboBoxUnit.SelectedItem?.ToString(); // Seçili öğe null olabileceği için güvenli erişim

            // Eğer birim seçiliyse, filtreyi ekle
            if (!string.IsNullOrEmpty(unit))
            {
                // Birim filtresini kontrol et ve gerekirse sil
                RemoveExistingFilter("Birim");

                // Yeni filtreyi listeye ekle
                filterCriteriaList.Add(new FilterCriteria { FilterType = "Birim", Value = unit });
                // Yeni filtreyi panelCurrentFilter'a ekle
                AddFilterToPanel($"Birim: {unit}", RemoveFilter);
            }
            else
            {
                MessageBox.Show("Lütfen birim seçin.");
            }
        }

        // Filtreyi panel'e ekleyen metot
        private void AddFilterToPanel(string filterText, Action<Control> removeAction)
        {
            // Yeni bir filtre için panel oluştur
            Panel filterPanel = new Panel
            {
                AutoSize = false, // Otomatik boyutlamayı kapat
                Width = 50, // Panelin genişliğini ayarla
                Height = 30, // Panelin yüksekliğini ayarla
                Margin = new Padding(10),
                Dock = DockStyle.Top, // Panelin üstte yer almasını sağla
                BackColor = Color.Gray
            };

            // Yeni label oluştur
            Label label = new Label
            {
                Text = filterText,
                AutoSize = true,
                Margin = new Padding(5)
            };

            // Silme butonu oluştur
            Button removeButton = new Button
            {
                Text = "X",
                Width = 25, // Butonun genişliğini ayarla
                Height = 25, // Butonun yüksekliğini ayarla
                Margin = new Padding(5),
                Dock = DockStyle.Right
            };

            // Silme butonuna tıklandığında filtreyi kaldır
            removeButton.Click += (sender, e) =>
            {
                // Silme işlemi
                removeAction(filterPanel);
                RemoveFilter(filterPanel); // Panelden ve listeden sil
            };

            // Panel'e label ve butonu ekle
            filterPanel.Controls.Add(label);
            filterPanel.Controls.Add(removeButton);

            // PanelCurrentFilter'a ekle
            panelCurrentFilters.Controls.Add(filterPanel);
        }

        private void RemoveFilter(Control filterPanel)
        {
            panelCurrentFilters.Controls.Remove(filterPanel);

            // Silinen filtreyi filterCriteriaList'ten kaldırma işlemini burada gerçekleştirin
            var filterType = filterPanel.Controls[0].Text.Split(':')[0].Trim(); // Label'dan filtre türünü al
            var existingFilter = filterCriteriaList.FirstOrDefault(f => f.FilterType == filterType);
            if (existingFilter != null)
            {
                filterCriteriaList.Remove(existingFilter);
            }
            if (filterCriteriaList.Count == 0)
            {
                RefreshPanelsAsync();
            }
        }

        // Mevcut filtreyi silme işlemi
        private void RemoveExistingFilter(string filterType)
        {
            // Mevcut filtreyi bul
            var existingFilter = filterCriteriaList.FirstOrDefault(f => f.FilterType == filterType);
            if (existingFilter != null)
            {
                // Filtreyi listeden çıkar
                filterCriteriaList.Remove(existingFilter);

                // Panel'den sil
                foreach (Control control in panelCurrentFilters.Controls)
                {
                    if (control is Panel filterPanel && filterPanel.Controls[0].Text.StartsWith(filterType))
                    {
                        panelCurrentFilters.Controls.Remove(filterPanel);
                        break; // Silindikten sonra döngüyü sonlandır
                    }
                }
            }
        }

        private void buttonFilters_Click(object sender, EventArgs e)
        {
            RefreshPanelsAsync();
            InitializeCustomPanelsAsync();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            // Malzeme adını al
            string name = textBoxSearch.Text.Trim();

            // "Malzeme Adı" filtresini kontrol et ve güncelle
            var existingFilter = filterCriteriaList.FirstOrDefault(f => f.FilterType == "Malzeme Adi");
            if (existingFilter != null)
            {
                // Eğer mevcut filtre varsa, değeri güncelle
                existingFilter.Value = name;
            }
            else
            {
                // Eğer mevcut filtre yoksa, yeni filtre ekle
                filterCriteriaList.Add(new FilterCriteria { FilterType = "Malzeme Adi", Value = name });
            }

            // Paneli yenile
            RefreshPanelsAsync();
            InitializeCustomPanelsAsync();
        }
    }
}

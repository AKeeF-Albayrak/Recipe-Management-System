using LezzetKitabi.Application.Services;
using LezzetKitabi.Domain.Dtos.RecipeDtos;
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
using static LezzetKitabi.Forms.Controls.RecipeAddControl;

namespace LezzetKitabi.Forms.Controls
{
    public partial class RecipeMainControl : UserControl
    {
        private readonly IRecipeService _recipeService;
        private readonly IIngredientService _ingredientService;
        RecipeSortingType _sortingType = RecipeSortingType.Descending_Percentage;
        private List<FilterCriteria> filterCriteriaList;
        public RecipeMainControl(IServiceProvider serviceProvider)
        {
            filterCriteriaList = new List<FilterCriteria>();
            _recipeService = serviceProvider.GetRequiredService<IRecipeService>();
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
            comboBoxCategory.Items.AddRange(Enum.GetNames(typeof(Category)));
            SetUpCombobox();
            InitializeSearchBar();
        }
        public async void  InitializeSearchBar()
        {
            List<RecipeViewGetDto> recipes = await _recipeService.GetAllRecipesByOrderAsync(_sortingType);
            textBoxSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection suggestions = new AutoCompleteStringCollection();

            foreach (var recipe in recipes)
            {
                suggestions.Add(recipe.RecipeName);
            }

            // Suggestions'u textbox'a ata
            textBoxSearch.AutoCompleteCustomSource = suggestions;
        }
        public async void SetUpCombobox()
        {
            var ingredients = await _ingredientService.GetAllIngredientsByOrderAndFilterAsync(IngredientSortingType.A_from_Z);
            comboBoxIngredients.DataSource = ingredients;
            comboBoxIngredients.DisplayMember = "IngredientName"; // Görüntülenecek isim
            comboBoxIngredients.ValueMember = "Id";
        }
        private async Task InitializeCustomPanelsAsync()
        {
            int rows = 2;  // 3 rows
            int cols = 4;  // 6 columns
            int panelWidth = 240;  // Panel width
            int panelHeight = 285; // Panel height
            int xPadding = 12;  // Horizontal padding between panels
            int yPadding = 12;  // Vertical padding between panels
            int startX = 10; // Starting X position
            int startY = 10; // Starting Y position
            int cornerRadius = 20;  // Yuvarlak köşe yarıçapı

            // Tüm tarifleri al
            List<RecipeViewGetDto> recipes = await _recipeService.GetAllRecipesByOrderAsync(_sortingType, filterCriteriaList);

            if (recipes == null || recipes.Count == 0)
            {
                MessageBox.Show("No recipes found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (int i = 0; i < Math.Min(recipes.Count, rows * cols); i++)
            {
                int row = i / cols;
                int col = i % cols;

                // Ana panel oluştur
                Panel mainPanel = new Panel();
                mainPanel.Tag = recipes[i];
                mainPanel.BackColor = recipes[i].AvailabilityPercentage == 100 ? Color.Green : Color.DarkRed;
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
                        using (Brush brush = new SolidBrush(mainPanel.BackColor))  // Ana panelin arka plan rengi
                        {
                            g.FillPath(brush, path);  // Arka planı doldur
                        }

                        // Panelin görünümünü yuvarlak yap
                        mainPanel.Region = new Region(path);
                    }
                };

                // Fare olaylarını ayarla
                mainPanel.MouseEnter += (s, e) => BringToFront(mainPanel);
                mainPanel.MouseLeave += (s, e) => CheckMouseLeave(mainPanel);

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

                // Details butonu
                PictureBox pictureBoxDetail = new PictureBox();
                pictureBoxDetail.Size = new Size(50, 50);  // PictureBox boyutu
                pictureBoxDetail.Location = new Point((panelWidth - pictureBoxDetail.Width) / 2, 20);  // İlk PictureBox için pozisyon
                pictureBoxDetail.Image = Properties.Resources.DetailsIcon;  // Detail ikonu
                pictureBoxDetail.SizeMode = PictureBoxSizeMode.StretchImage;  // Resmi stretch yap
                                                                              //pictureBoxDetail.Click += (s, e) => DeRecipe(recipes[i]);  // Tıklama olayını tanımla

                // Güncelleme butonu
                PictureBox pictureBoxUpdate = new PictureBox();
                pictureBoxUpdate.Size = new Size(50, 50);  // PictureBox boyutu
                pictureBoxUpdate.Location = new Point((panelWidth - pictureBoxUpdate.Width) / 2, 70);  // İkinci PictureBox için pozisyon
                pictureBoxUpdate.Image = Properties.Resources.EditIcon;  // Güncelleme ikonu
                pictureBoxUpdate.SizeMode = PictureBoxSizeMode.StretchImage;  // Resmi stretch yap
                pictureBoxUpdate.Cursor = Cursors.Hand;  // Fare üzerine geldiğinde el ikonu göster
                                                         //pictureBoxUpdate.Click += (s, e) => UpdateRecipe(recipes[i]);  // Tıklama olayını tanımla

                // Silme butonu
                PictureBox pictureBoxDelete = new PictureBox();
                pictureBoxDelete.Size = new Size(50, 50);
                pictureBoxDelete.Location = new Point((panelWidth - pictureBoxDelete.Width) / 2, 130);
                pictureBoxDelete.Image = Properties.Resources.DeleteIcon;
                pictureBoxDelete.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxDelete.Cursor = Cursors.Hand;
                pictureBoxDelete.Click += DeleteIcon_Click;
                pictureBoxDelete.Tag = recipes[i];                                        

                // Overlay paneline butonları ekleyin
                overlayPanel.Controls.Add(pictureBoxDetail);
                overlayPanel.Controls.Add(pictureBoxUpdate);
                overlayPanel.Controls.Add(pictureBoxDelete);

                // Ana paneli içerikleriyle birlikte ekleyin
                Label label = new Label();
                label.AutoSize = true;
                label.Text = recipes[i].RecipeName; // Dinamik malzeme adı
                label.Location = new Point((panelWidth - label.Width) / 2, 12);  // Ortalayın

                // Yeni Label'lar için oluşturma
                Label percentageLabel = new Label();
                percentageLabel.AutoSize = true;
                percentageLabel.Text = "Yüzde: " + (recipes[i].AvailabilityPercentage).ToString("0.##") + "%"; // Yüzde değeri
                percentageLabel.Location = new Point((panelWidth - percentageLabel.Width) / 2, 40); // Ortalayın

                Label costLabel = new Label();
                costLabel.AutoSize = true;
                costLabel.Text = "Maliyet: " + recipes[i].TotalCost.ToString("C"); // Maliyet bilgisi
                costLabel.Location = new Point((panelWidth - costLabel.Width) / 2, 60); // Ortalayın

                mainPanel.Controls.Add(label);
                mainPanel.Controls.Add(percentageLabel); 
                mainPanel.Controls.Add(costLabel);
                mainPanel.Controls.Add(overlayPanel);

                // Ana paneli panelItems'a ekleyin
                panelItems.Controls.Add(mainPanel);
            }
        }


        // Düzenleme ikonu tıklama olayı
        /*private void EditIcon_Click(object sender, EventArgs e)
        {
            PictureBox picBox = sender as PictureBox;
            Recipe recipe = picBox?.Tag as Recipe;
            if (recipe != null)
            {
                // Düzenleme işlemini gerçekleştirin
            }
        }

        // Güncelleme ikonu tıklama olayı
        private void UpdateIcon_Click(object sender, EventArgs e)
        {
            PictureBox picBox = sender as PictureBox;
            Recipe recipe = picBox?.Tag as Recipe;
            if (recipe != null)
            {
                // Güncelleme işlemini gerçekleştirin
            }
        }*/
        private async void DeleteIcon_Click(object sender, EventArgs e)
        {
            PictureBox deleteIcon = sender as PictureBox;
            if (deleteIcon != null)
            {
                RecipeViewGetDto recipeToDelete = deleteIcon.Tag as RecipeViewGetDto;
                if (recipeToDelete != null)
                {
                    DialogResult dialogResult = MessageBox.Show(
                        $"'{recipeToDelete.RecipeName}' Adli Tarifi Silmek Istediginize Emin Misiniz?",
                        "Emin Misiniz",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        bool isDeleted = await Task.Run(() => _recipeService.DeleteRecipe(recipeToDelete.Id));
                        if (isDeleted)
                        {
                            MessageBox.Show("Tarif Basariyla Silindi!", "Basarili", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await RefreshPanelsAsync();
                        }
                        else
                        {
                            MessageBox.Show("Tarifi Silerken Bir Hata Olustu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
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


        private async void ComboBoxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Seçilen index'e göre sortingType'ı ayarlama
            switch (comboBoxSort.SelectedIndex)
            {
                case 0:
                    _sortingType = RecipeSortingType.Ascending_Percentage;
                    break;
                case 1:
                    _sortingType = RecipeSortingType.Descending_Percentage;
                    break;
                case 2:
                    _sortingType = RecipeSortingType.A_from_Z;
                    break;
                case 3:
                    _sortingType = RecipeSortingType.Z_from_A;
                    break;
                case 4:
                    _sortingType = RecipeSortingType.Cheapest_to_Expensive;
                    break;
                case 5:
                    _sortingType = RecipeSortingType.Expensive_to_Cheapest;
                    break;
                case 6:
                    _sortingType = RecipeSortingType.Fastest_to_Slowest;
                    break;
                case 7:
                    _sortingType = RecipeSortingType.Slowest_to_Fastest;
                    break;
                case 8:
                    _sortingType = RecipeSortingType.Increasing_Ingredients;
                    break;
                case 9:
                    _sortingType = RecipeSortingType.Decrising_Ingredients;
                    break;
                default:
                    _sortingType = RecipeSortingType.A_from_Z;
                    break;
            }
            RefreshPanelsAsync();
        }

        public async Task RefreshPanelsAsync()
        {
            panelItems.Controls.Clear();

            await InitializeCustomPanelsAsync();  // Bu işlemi de async yaparak UI'nin kilitlenmesini önleyin
        }

        private void buttonPriceTagAdd_Click(object sender, EventArgs e)
        {
            // Fiyat aralığı değerlerini al
            decimal? minPrice = null;
            decimal? maxPrice = null;

            // Minimum fiyatı kontrol et
            if (decimal.TryParse(textBoxMinPrice.Text, out decimal minPriceValue))
            {
                minPrice = minPriceValue;
            }

            // Maksimum fiyatı kontrol et
            if (decimal.TryParse(textBoxMaxPrice.Text, out decimal maxPriceValue))
            {
                maxPrice = maxPriceValue;
            }

            // Fiyat filtresi ekle
            if (minPrice.HasValue || maxPrice.HasValue)
            {
                // Mevcut filtreleri kontrol et ve sil
                RemoveExistingFilter("Fiyat"); // Önceki fiyat filtresini sil

                // Yeni filtreyi ekle ve panele yansıt
                AddFilterToPanel($"Fiyat: {minPrice} - {maxPrice}", RemoveFilter);
                filterCriteriaList.Add(new FilterCriteria { FilterType = "Fiyat", Value = $"{minPrice} - {maxPrice}" });
            }
            else
            {
                MessageBox.Show("Geçerli bir fiyat aralığı girin.");
            }
        }

        private void buttonTimeAdd_Click(object sender, EventArgs e)
        {
            // Minimum ve maksimum hazırlama süresi değerlerini al
            int? minTime = null;
            int? maxTime = null;

            // Minimum hazırlama süresini kontrol et
            if (int.TryParse(textBoxMinPrepTime.Text, out int minTimeValue))
            {
                minTime = minTimeValue;
            }

            // Maksimum hazırlama süresini kontrol et
            if (int.TryParse(textBoxMaxPrepTime.Text, out int maxTimeValue))
            {
                maxTime = maxTimeValue;
            }

            // Hazırlama süresi aralığı varsa filtreyi ekle
            if (minTime.HasValue || maxTime.HasValue)
            {
                RemoveExistingFilter("Hazırlama Süresi"); // Önceki hazırlama süresi filtresini sil

                // Filtreyi ekle ve panele yansıt
                AddFilterToPanel($"Hazırlama Süresi: {minTime} - {maxTime} dakika", RemoveFilter);
                filterCriteriaList.Add(new FilterCriteria { FilterType = "Hazırlama Süresi", Value = $"{minTime} - {maxTime}" });
            }
            else
            {
                MessageBox.Show("Geçerli bir hazırlama süresi aralığı girin.");
            }
        }

        private void buttonCatagory_Click(object sender, EventArgs e)
        {
            // Kategori ComboBox'tan seçilen değeri al
            string selectedCategory = comboBoxCategory.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedCategory))
            {
                RemoveExistingFilter("Kategori"); // Önceki kategori filtresini sil

                // Filtreyi ekle ve panele yansıt
                AddFilterToPanel($"Kategori: {selectedCategory}", RemoveFilter);
                filterCriteriaList.Add(new FilterCriteria { FilterType = "Kategori", Value = selectedCategory });
            }
            else
            {
                MessageBox.Show("Bir kategori seçin.");
            }
        }

        private void buttonAddIngredient_Click(object sender, EventArgs e)
        {
            // ComboBox'dan seçili malzemeyi al
            var selectedIngredient = comboBoxIngredients.SelectedItem as Ingredient;

            if (selectedIngredient != null)
            {
                // Mevcut filtreleri kontrol et
                var existingFilter = filterCriteriaList.FirstOrDefault(f => f.FilterType == "Malzeme" && f.Value == selectedIngredient.IngredientName);

                if (existingFilter == null)
                {
                    // Filtreyi ekle ve panele yansıt
                    AddFilterToPanel($"Malzeme: {selectedIngredient.IngredientName}", RemoveFilter);
                    filterCriteriaList.Add(new FilterCriteria { FilterType = "Malzeme", Value = selectedIngredient.IngredientName });
                }
                else
                {
                    MessageBox.Show("Bu malzeme zaten eklenmiş.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir malzeme seçin.");
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            // Malzeme adını al
            string name = textBoxSearch.Text.Trim();

            // "Malzeme Adı" filtresini kontrol et ve güncelle
            var existingFilter = filterCriteriaList.FirstOrDefault(f => f.FilterType == "Tarif Adi");
            if (existingFilter != null)
            {
                // Eğer mevcut filtre varsa, değeri güncelle
                existingFilter.Value = name;
            }
            else
            {
                // Eğer mevcut filtre yoksa, yeni filtre ekle
                filterCriteriaList.Add(new FilterCriteria { FilterType = "Tarif Adi", Value = name });
            }

            // Paneli yenile
            RefreshPanelsAsync();
            InitializeCustomPanelsAsync();
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            RefreshPanelsAsync();
        }

        private void AddFilterToPanel(string filterText, Action<Control> removeAction)
        {
            // Yeni bir filtre için panel oluştur
            Panel filterPanel = new Panel
            {
                AutoSize = false, // Otomatik boyutlamayı kapat
                Width = 70, // Panelin genişliğini ayarla
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
            if(filterCriteriaList.Count == 0)
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
    }
}

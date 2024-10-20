using LezzetKitabi.Application.Services;
using LezzetKitabi.Domain.Contracts;
using LezzetKitabi.Domain.Dtos.RecipeDtos;
using LezzetKitabi.Domain.Entities;
using LezzetKitabi.Domain.Enums;
using LezzetKitabi.Services.Abstract;
using LezzetKitabi.Services.Concrete;
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
    public partial class IngredientMainControl : UserControl
    {
        private readonly IIngredientService _ingredientService;
        IngredientSortingType _sortingType = IngredientSortingType.A_from_Z;
        private List<FilterCriteria> filterCriteriaList;
        private int currentPage = 1;
        private int totalPages;

        public IngredientMainControl(IServiceProvider serviceProvider)
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
            panelElements.BackColor = Color.Transparent;
            panelDown.BackColor = Color.Transparent;
            comboBoxUnit.Items.AddRange(Enum.GetNames(typeof(UnitType)));
            InitializeSearchTextBox();
        }
        private async Task InitializeSearchTextBox()
        {
            List<Ingredient> ingredients = await _ingredientService.GetAllIngredientsByOrderAndFilterAsync(_sortingType);

            textBoxSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection suggestions = new AutoCompleteStringCollection();

            foreach (var ingredient in ingredients)
            {
                suggestions.Add(ingredient.IngredientName);
            }

            textBoxSearch.AutoCompleteCustomSource = suggestions;
        }
        public async Task InitializeCustomPanelsAsync()
        {
            int rows = 3;
            int cols = 6;
            int panelWidth = 160;
            int panelHeight = 190;
            int xPadding = 12;
            int yPadding = 12;
            int startX = 10;
            int startY = 10;
            int cornerRadius = 20;

            List<Ingredient> ingredients = await _ingredientService.GetAllIngredientsByOrderAndFilterAsync(_sortingType, filterCriteriaList);
            totalPages = ingredients.Count / 18;

            if (ingredients == null || ingredients.Count == 0)
            {
                MessageBox.Show("No ingredients found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int startIndex = (currentPage - 1) * 18;
            int endIndex = Math.Min(startIndex + 18, ingredients.Count);

            for (int i = startIndex; i < endIndex; i++)
            {
                int row = (i - startIndex) / cols;
                int col = (i - startIndex) % cols;

                Panel mainPanel = new Panel();
                mainPanel.Tag = ingredients[i];
                mainPanel.BackColor = Color.Transparent;
                mainPanel.Size = new Size(panelWidth, panelHeight);
                int x = startX + col * (panelWidth + xPadding);
                int y = startY + row * (panelHeight + yPadding);
                mainPanel.Location = new Point(x, y);

                mainPanel.Paint += (s, e) =>
                {
                    Graphics g = e.Graphics;
                    Rectangle rect = mainPanel.ClientRectangle;
                    g.SmoothingMode = SmoothingMode.AntiAlias;

                    using (GraphicsPath path = CreateRoundedRectanglePath(rect, cornerRadius))
                    {
                        using (Brush brush = new SolidBrush(SystemColors.ActiveCaption))
                        {
                            g.FillPath(brush, path);
                        }
                    }
                };

                mainPanel.MouseEnter += (s, e) => BringToFront(mainPanel);
                mainPanel.MouseLeave += (s, e) => CheckMouseLeave(mainPanel);

                PictureBox pictureBox = new PictureBox();
                if (i == 1)
                {
                    pictureBox.Image = Properties.Resources.domates;
                }
                else
                {
                    pictureBox.Image = Properties.Resources.Screenshot_2024_10_09_121511;
                }
                pictureBox.Size = new Size(115, 94);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Location = new Point((panelWidth - pictureBox.Width) / 2, 35);

                Label label = new Label();
                label.AutoSize = true;
                label.Text = ingredients[i].IngredientName;
                label.Location = new Point((panelWidth - label.Width) / 2, 12);

                Label labelMiktar = new Label();
                labelMiktar.AutoSize = true;
                labelMiktar.Text = $"{ingredients[i].TotalQuantity} {ingredients[i].Unit}";
                labelMiktar.Location = new Point((panelWidth - labelMiktar.Width) / 2, pictureBox.Bottom + 5);

                Label labelBirimFiyati = new Label();
                labelBirimFiyati.AutoSize = true;
                labelBirimFiyati.Text = $"₺{ingredients[i].UnitPrice:0.00}";
                labelBirimFiyati.Location = new Point((panelWidth - labelBirimFiyati.Width) / 2, labelMiktar.Bottom + 5);

                Panel overlayPanel = new Panel();
                overlayPanel.BackColor = Color.Gray;
                overlayPanel.Size = new Size(panelWidth, panelHeight);
                overlayPanel.Location = new Point(0, 0);
                overlayPanel.Visible = false;

                overlayPanel.Paint += (s, e) =>
                {
                    Graphics g = e.Graphics;
                    Rectangle rect = overlayPanel.ClientRectangle;
                    g.SmoothingMode = SmoothingMode.AntiAlias;

                    using (GraphicsPath path = CreateRoundedRectanglePath(rect, cornerRadius))
                    {
                        using (Brush brush = new SolidBrush(Color.SandyBrown))
                        {
                            g.FillPath(brush, path);
                        }

                        overlayPanel.Region = new Region(path);
                    }
                };

                Button buttonEdit = new Button();
                buttonEdit.Text = "Button 1";
                buttonEdit.Size = new Size(80, 30);
                buttonEdit.Location = new Point(10, 10);
                buttonEdit.Tag = ingredients[i];
                buttonEdit.Click += ButtonEdit_Click;

                Button buttonDelete = new Button();
                buttonDelete.Text = "Delete";
                buttonDelete.Size = new Size(80, 30);
                buttonDelete.Location = new Point(100, 10);
                buttonDelete.Tag = ingredients[i];
                buttonDelete.Click += DeleteButton_Click;

                overlayPanel.Controls.Add(buttonEdit);
                overlayPanel.Controls.Add(buttonDelete);

                mainPanel.Controls.Add(label);
                mainPanel.Controls.Add(pictureBox);
                mainPanel.Controls.Add(labelMiktar);
                mainPanel.Controls.Add(labelBirimFiyati);
                mainPanel.Controls.Add(overlayPanel);

                panelItems.Controls.Add(mainPanel);
            }
            InitializeSearchTextBox();
        }
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            Button editButton = sender as Button;

            if (editButton != null)
            {
                Ingredient ingredient = editButton.Tag as Ingredient;

                IngredientEditForm form = new IngredientEditForm(_ingredientService);
                form.LoadIngredientDetails(ingredient);

                form.IngredientUpdated += Form_IngredientUpdated;

                form.ShowDialog();
            }
        }
        private async void Form_IngredientUpdated(object sender, EventArgs e)
        {
            await RefreshPanelsAsync();
        }
        private async void ComboBoxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                default:
                    _sortingType = IngredientSortingType.A_from_Z;
                    break;
            }
            await RefreshPanelsAsync();
        }
        private GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int cornerRadius)
        {
            GraphicsPath path = new GraphicsPath();
            int arcDiameter = cornerRadius * 2;

            path.AddArc(rect.X, rect.Y, arcDiameter, arcDiameter, 180, 90);
            path.AddArc(rect.Right - arcDiameter, rect.Y, arcDiameter, arcDiameter, 270, 90);
            path.AddArc(rect.Right - arcDiameter, rect.Bottom - arcDiameter, arcDiameter, arcDiameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - arcDiameter, arcDiameter, arcDiameter, 90, 90);

            path.CloseFigure();
            return path;
        }
        private void BringToFront(Panel panel)
        {
            Panel overlayPanel = panel.Controls.OfType<Panel>().FirstOrDefault(p => p.BackColor == Color.Gray);
            if (overlayPanel != null)
            {
                overlayPanel.Visible = true;
                overlayPanel.BringToFront();
                overlayPanel.MouseEnter += (s, e) => overlayPanel.Visible = true;
                overlayPanel.MouseLeave += (s, e) => overlayPanel.Visible = false;
            }
        }
        private void CheckMouseLeave(Panel panel)
        {
            Panel overlayPanel = panel.Controls.OfType<Panel>().FirstOrDefault(p => p.BackColor == Color.SandyBrown);
            if (overlayPanel != null && overlayPanel.Visible)
            {
                if (!overlayPanel.ClientRectangle.Contains(overlayPanel.PointToClient(MousePosition)))
                {
                    overlayPanel.Visible = false;
                }
            }
        }
        private void InitializeGradientPanel(Panel panel)
        {
            panel.Paint += (s, e) =>
            {
                Color startColor = Color.FromArgb(200, 255, 165, 0);
                Color endColor = Color.FromArgb(255, 255, 99, 71);

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
                Ingredient ingredientToDelete = deleteButton.Tag as Ingredient;

                if (ingredientToDelete != null)
                {
                    DialogResult dialogResult = MessageBox.Show(
                        $"{ingredientToDelete.IngredientName} Malzemesini Silmek Istediginize Emin Misiniz?",
                        "Emin Misiniz",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (dialogResult == DialogResult.Yes)
                    {
                        bool isDeleted = await Task.Run(() => _ingredientService.DeleteIngredient(ingredientToDelete.Id));

                        if (isDeleted)
                        {
                            MessageBox.Show("Malzeme Basariyla Silindi!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await RefreshPanelsAsync();
                        }
                        else
                        {
                            MessageBox.Show("Malzeme Silinemedi Lutfen Tekrar Deneyiniz.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        public async Task RefreshPanelsAsync()
        {
            panelItems.Controls.Clear();

            await InitializeCustomPanelsAsync();
        }
        private void buttonPriceRangeAdd_Click(object sender, EventArgs e)
        {
            decimal? minPrice = null;
            decimal? maxPrice = null;

            if (decimal.TryParse(textBoxMinPrice.Text, out decimal minPriceValue))
            {
                minPrice = minPriceValue;
            }

            if (decimal.TryParse(textBoxMaxPrice.Text, out decimal maxPriceValue))
            {
                maxPrice = maxPriceValue;
            }

            if (minPrice.HasValue && maxPrice.HasValue && minPrice.Value > maxPrice.Value)
            {
                MessageBox.Show("Minimum fiyat maksimum fiyatı geçemez.");
                return;
            }

            RemoveExistingFilter("Fiyat");

            if (minPrice.HasValue || maxPrice.HasValue)
            {
                filterCriteriaList.Add(new FilterCriteria { FilterType = "Fiyat", Value = $"{minPrice} - {maxPrice}" });
                AddFilterToPanel($"Fiyat: {minPrice} - {maxPrice}", RemoveFilter);
            }
        }
        private void buttonStockRangeAdd_Click(object sender, EventArgs e)
        {
            int? minStock = null;
            int? maxStock = null;

            if (int.TryParse(textBoxMinStock.Text, out int minStockValue))
            {
                minStock = minStockValue;
            }

            if (int.TryParse(textBoxMaxStock.Text, out int maxStockValue))
            {
                maxStock = maxStockValue;
            }

            if (minStock.HasValue && maxStock.HasValue && minStock.Value > maxStock.Value)
            {
                MessageBox.Show("Minimum stok maksimum stok değerini geçemez.");
                return;
            }

            RemoveExistingFilter("Stok");
            if (minStock.HasValue || maxStock.HasValue)
            {
                filterCriteriaList.Add(new FilterCriteria { FilterType = "Stok", Value = $"{minStock} - {maxStock}"});
                AddFilterToPanel($"Stok: {minStock} - {maxStock}", RemoveFilter);
            }
        }
        private void buttonUnitAdd_Click(object sender, EventArgs e)
        {
            string unit = comboBoxUnit.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(unit))
            {
                RemoveExistingFilter("Birim");
                filterCriteriaList.Add(new FilterCriteria { FilterType = "Birim", Value = unit });
                AddFilterToPanel($"Birim: {unit}", RemoveFilter);
            }
            else
            {
                MessageBox.Show("Lütfen birim seçin.");
            }
        }
        private void AddFilterToPanel(string filterText, Action<Control> removeAction)
        {
            Panel filterPanel = new Panel
            {
                AutoSize = false,
                Width = 50,
                Height = 30,
                Margin = new Padding(10),
                Dock = DockStyle.Top,
                BackColor = Color.Gray
            };

            Label label = new Label
            {
                Text = filterText,
                AutoSize = true,
                Margin = new Padding(5)
            };

            Button removeButton = new Button
            {
                Text = "X",
                Width = 25,
                Height = 25,
                Margin = new Padding(5),
                Dock = DockStyle.Right
            };

            removeButton.Click += (sender, e) =>
            {
                removeAction(filterPanel);
                RemoveFilter(filterPanel);
            };

            filterPanel.Controls.Add(label);
            filterPanel.Controls.Add(removeButton);

            panelCurrentFilters.Controls.Add(filterPanel);
        }
        private void RemoveFilter(Control filterPanel)
        {
            panelCurrentFilters.Controls.Remove(filterPanel);

            var filterType = filterPanel.Controls[0].Text.Split(':')[0].Trim();
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
        private void RemoveExistingFilter(string filterType)
        {
            var existingFilter = filterCriteriaList.FirstOrDefault(f => f.FilterType == filterType);
            if (existingFilter != null)
            {
                filterCriteriaList.Remove(existingFilter);

                foreach (Control control in panelCurrentFilters.Controls)
                {
                    if (control is Panel filterPanel && filterPanel.Controls[0].Text.StartsWith(filterType))
                    {
                        panelCurrentFilters.Controls.Remove(filterPanel);
                        break;
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
            string name = textBoxSearch.Text.Trim();
            var existingFilter = filterCriteriaList.FirstOrDefault(f => f.FilterType == "Malzeme Adi");
            if (existingFilter != null)
            {
                existingFilter.Value = name;
            }
            else
            {
                filterCriteriaList.Add(new FilterCriteria { FilterType = "Malzeme Adi", Value = name });
            }
            RefreshPanelsAsync();
            InitializeCustomPanelsAsync();
        }
        private void buttonPrevius_Click(object sender, EventArgs e)
        {
            if (currentPage != 1)
            {
                currentPage--;
                RefreshPanelsAsync();
            }
            else
            {
                MessageBox.Show("Ilk Sayfaya Ulastiniz Daha Geri Gidemezsiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages - 1)
            {
                currentPage++;
                RefreshPanelsAsync();
            }
            else
            {
                MessageBox.Show("Son sayfaya ulaştınız, daha ileri gidemiyorsunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

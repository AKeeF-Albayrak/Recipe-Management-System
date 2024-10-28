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
using System.Diagnostics;
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
        public event EventHandler IngredientChanged;
        private readonly IIngredientService _ingredientService;
        IngredientSortingType _sortingType = IngredientSortingType.A_from_Z;
        private List<FilterCriteria> filterCriteriaList;
        private int currentPage = 1;
        public int totalPages;

        public IngredientMainControl(IServiceProvider serviceProvider)
        {
            filterCriteriaList = new List<FilterCriteria>();
            _ingredientService = serviceProvider.GetRequiredService<IIngredientService>();
            InitializeComponent();


            comboBoxUnit.Items.AddRange(Enum.GetNames(typeof(UnitType)));

        }

        /*public async Task LoadBackgroundImageAsync()
        {
            await Task.Run(() =>
            {
                this.BackgroundImage = Properties.Resources.Kitchen_utensils_seamless_background_vector;
            });

            this.Invalidate();
        }*/
        private void OnIngredientsChanged()
        {
            IngredientChanged?.Invoke(this, EventArgs.Empty);
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

            textBoxSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection suggestions = new AutoCompleteStringCollection();

            foreach (var ingredient in ingredients)
            {
                suggestions.Add(ingredient.IngredientName);
            }
            totalPages = (int)Math.Ceiling((double)ingredients.Count / 18);

            label7.Text = $"{currentPage}  / {totalPages}";


            textBoxSearch.AutoCompleteCustomSource = suggestions;


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
                        using (Brush brush = new SolidBrush(Color.FromArgb(186, 230, 253)))
                        {
                            g.FillPath(brush, path);
                        }
                    }
                };

                mainPanel.MouseEnter += (s, e) => BringToFront(mainPanel);
                mainPanel.MouseLeave += (s, e) => CheckMouseLeave(mainPanel);

                PictureBox pictureBox = new PictureBox();
                using (MemoryStream ms = new MemoryStream(ingredients[i].Image))
                {
                    Image img = Image.FromStream(ms);

                    pictureBox.Image = img;
                }
                pictureBox.Size = new Size(115, 94);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Location = new Point((panelWidth - pictureBox.Width) / 2, 35);



                Label label = new Label();
                label.Size = new Size(panelWidth, 20); // Sabit genişlik ayarlayarak ortalamayı sağla
                label.TextAlign = ContentAlignment.MiddleCenter; // Etiket içinde metni ortala
                label.Font = new Font("Segoe UI", 8F, FontStyle.Bold); // Daha net bir font ve kalın stil kullan
                label.Text = ingredients[i].IngredientName;
                label.Location = new Point(0, 12); // X pozisyonunu sıfırla, Y pozisyonunu ihtiyaca göre ayarla
                label.ForeColor = Color.FromArgb(3, 105, 161);

                Label labelMiktar = new Label();
                labelMiktar.AutoSize = true;
                labelMiktar.Text = $"{ingredients[i].TotalQuantity} {ingredients[i].Unit}";
                labelMiktar.Location = new Point((panelWidth - labelMiktar.Width) / 2, pictureBox.Bottom + 5);
                labelMiktar.ForeColor = Color.FromArgb(3, 105, 161);

                Label labelBirimFiyati = new Label();
                labelBirimFiyati.AutoSize = true;
                labelBirimFiyati.Text = $"₺{ingredients[i].UnitPrice:0.00}";
                labelBirimFiyati.Location = new Point((panelWidth - labelBirimFiyati.Width) / 2, labelMiktar.Bottom + 5);
                labelBirimFiyati.ForeColor = Color.FromArgb(3, 105, 161);

                Panel overlayPanel = new Panel();
                overlayPanel.BackColor = Color.FromArgb(186, 230, 253);
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
                        using (Brush brush = new SolidBrush(Color.FromArgb(186, 230, 253)))
                        {
                            g.FillPath(brush, path);
                        }

                        overlayPanel.Region = new Region(path);
                    }
                };

                int iconSize = 50;
                int verticalSpacing = 10;

                PictureBox pictureBoxEdit = new PictureBox();
                pictureBoxEdit.Size = new Size(iconSize, iconSize);
                pictureBoxEdit.Location = new Point((panelWidth - pictureBoxEdit.Width) / 2, (panelHeight - (iconSize * 2 + verticalSpacing)) / 2);
                pictureBoxEdit.Image = Properties.Resources.EditIcon;
                pictureBoxEdit.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxEdit.Cursor = Cursors.Hand;
                pictureBoxEdit.Tag = ingredients[i];
                pictureBoxEdit.Click += EditIcon_Click;

                PictureBox pictureBoxDelete = new PictureBox();
                pictureBoxDelete.Size = new Size(iconSize, iconSize);
                pictureBoxDelete.Location = new Point((panelWidth - pictureBoxDelete.Width) / 2, pictureBoxEdit.Bottom + verticalSpacing);
                pictureBoxDelete.Image = Properties.Resources.DeleteIcon;
                pictureBoxDelete.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxDelete.Cursor = Cursors.Hand;
                pictureBoxDelete.Tag = ingredients[i];
                pictureBoxDelete.Click += DeleteIcon_Click;

                overlayPanel.Controls.Add(pictureBoxEdit);
                overlayPanel.Controls.Add(pictureBoxDelete);

                mainPanel.Controls.Add(label);
                mainPanel.Controls.Add(pictureBox);
                mainPanel.Controls.Add(labelMiktar);
                mainPanel.Controls.Add(labelBirimFiyati);
                mainPanel.Controls.Add(overlayPanel);

                panelItems.Controls.Add(mainPanel);
            }
        }
        private void EditIcon_Click(object sender, EventArgs e)
        {
            PictureBox editPictureBox = sender as PictureBox;

            if (editPictureBox != null)
            {
                Ingredient ingredient = editPictureBox.Tag as Ingredient;

                if (ingredient != null)
                {
                    IngredientEditForm form = new IngredientEditForm(_ingredientService);
                    form.LoadIngredientDetails(ingredient);

                    form.IngredientUpdated += Form_IngredientUpdated;

                    form.ShowDialog();
                }
            }
        }
        private async void DeleteIcon_Click(object sender, EventArgs e)
        {
            PictureBox deletePictureBox = sender as PictureBox;

            if (deletePictureBox != null)
            {
                Ingredient ingredientToDelete = deletePictureBox.Tag as Ingredient;

                if (ingredientToDelete != null)
                {
                    DialogResult dialogResult = MessageBox.Show(
                        $"{ingredientToDelete.IngredientName} Malzemesini Silmek İstediğinize Emin Misiniz?",
                        "Emin Misiniz",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (dialogResult == DialogResult.Yes)
                    {
                        bool isDeleted = await Task.Run(() => _ingredientService.DeleteIngredient(ingredientToDelete.Id));

                        if (isDeleted)
                        {
                            MessageBox.Show("Malzeme Başarıyla Silindi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await RefreshPanelsAsync();
                        }
                        else
                        {
                            MessageBox.Show("Malzeme Silinemedi. Lütfen Tekrar Deneyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
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
            Size arcSize = new Size(arcDiameter, arcDiameter);
            path.AddArc(new Rectangle(rect.Location, arcSize), 180, 90);
            path.AddArc(new Rectangle(new Point(rect.Right - arcDiameter, rect.Top), arcSize), 270, 90);
            path.AddArc(new Rectangle(new Point(rect.Right - arcDiameter, rect.Bottom - arcDiameter), arcSize), 0, 90);
            path.AddArc(new Rectangle(new Point(rect.Left, rect.Bottom - arcDiameter), arcSize), 90, 90);
            path.CloseFigure();
            return path;
        }
        private void BringToFront(Panel panel)
        {
            Panel overlayPanel = panel.Controls.OfType<Panel>().FirstOrDefault(p => p.BackColor == Color.FromArgb(186, 230, 253));
            if (overlayPanel != null)
            {
                overlayPanel.Visible = true;
                overlayPanel.BringToFront();

                System.Windows.Forms.Timer mouseLeaveTimer = new System.Windows.Forms.Timer();
                mouseLeaveTimer.Interval = 500;
                mouseLeaveTimer.Tick += (s, e) =>
                {
                    if (!overlayPanel.ClientRectangle.Contains(overlayPanel.PointToClient(MousePosition)))
                    {
                        overlayPanel.Visible = false;
                        mouseLeaveTimer.Stop();
                        mouseLeaveTimer.Dispose();
                    }
                };

                overlayPanel.MouseEnter += (s, e) =>
                {
                    overlayPanel.Visible = true;
                    mouseLeaveTimer.Stop();
                };

                overlayPanel.MouseLeave += (s, e) =>
                {
                    mouseLeaveTimer.Start();
                };
            }
        }
        private void CheckMouseLeave(Panel panel)
        {
            Panel overlayPanel = panel.Controls.OfType<Panel>().FirstOrDefault(p => p.BackColor == Color.FromArgb(186, 230, 253));
            if (overlayPanel != null && overlayPanel.Visible)
            {
                System.Windows.Forms.Timer mouseLeaveTimer = new System.Windows.Forms.Timer();
                mouseLeaveTimer.Interval = 200;

                mouseLeaveTimer.Tick += (s, e) =>
                {
                    if (!overlayPanel.ClientRectangle.Contains(overlayPanel.PointToClient(MousePosition)))
                    {
                        overlayPanel.Visible = false;
                        mouseLeaveTimer.Stop();
                        mouseLeaveTimer.Dispose();
                    }
                };

                overlayPanel.MouseEnter += (s, e) => mouseLeaveTimer.Stop();
                overlayPanel.MouseLeave += (s, e) => mouseLeaveTimer.Start();
            }
        }
        public async Task RefreshPanelsAsync()
        {
            panelItems.Controls.Clear();

            await InitializeCustomPanelsAsync();
        }
        private void UpdatePaginationButtons()
        {
            buttonPrevious.Enabled = currentPage > 1;
            buttonNext.Enabled = currentPage < totalPages;
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
                RefreshPanelsAsync();
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
                filterCriteriaList.Add(new FilterCriteria { FilterType = "Stok", Value = $"{minStock} - {maxStock}" });
                AddFilterToPanel($"Stok: {minStock} - {maxStock}", RemoveFilter);
                RefreshPanelsAsync();
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
                RefreshPanelsAsync();
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
                BackColor = Color.FromArgb(5, 150, 105)
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
        private async void buttonPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                label7.Text = $"{currentPage}  / {totalPages}";
                await RefreshPanelsAsync();
            }

        }
        private async void buttonNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                label7.Text = $"{currentPage}  / {totalPages}";
                await RefreshPanelsAsync();
            }
        }
        private async void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxSearch.Text))
            {
                await RefreshPanelsAsync();
            }
        }

    }
}

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

            textBoxSearch.AutoCompleteCustomSource = suggestions;
        }
        public async void SetUpCombobox()
        {
            var ingredients = await _ingredientService.GetAllIngredientsByOrderAndFilterAsync(IngredientSortingType.A_from_Z);
            comboBoxIngredients.DataSource = ingredients;
            comboBoxIngredients.DisplayMember = "IngredientName";
            comboBoxIngredients.ValueMember = "Id";
        }
        private async Task InitializeCustomPanelsAsync()
        {
            int rows = 2;
            int cols = 4;
            int panelWidth = 240;
            int panelHeight = 285;
            int xPadding = 12;
            int yPadding = 12;
            int startX = 10;
            int startY = 10;
            int cornerRadius = 20;

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

                Panel mainPanel = new Panel();
                mainPanel.Tag = recipes[i];
                mainPanel.BackColor = recipes[i].AvailabilityPercentage == 100 ? Color.Green : Color.DarkRed;
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
                        using (Brush brush = new SolidBrush(mainPanel.BackColor))
                        {
                            g.FillPath(brush, path);
                        }

                        mainPanel.Region = new Region(path);
                    }
                };

                mainPanel.MouseEnter += (s, e) => BringToFront(mainPanel);
                mainPanel.MouseLeave += (s, e) => CheckMouseLeave(mainPanel);

                Panel overlayPanel = new Panel();
                overlayPanel.BackColor = Color.SandyBrown;
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

                int iconSize = 75;
                int horizontalSpacing = 30;
                int startYTop = 30;
                int startYBottom = 150;

                PictureBox pictureBoxDetail = new PictureBox();
                pictureBoxDetail.Size = new Size(iconSize, iconSize);
                pictureBoxDetail.Location = new Point((panelWidth - pictureBoxDetail.Width) / 2, startYTop);
                pictureBoxDetail.Image = Properties.Resources.DetailsIcon;
                pictureBoxDetail.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxDetail.Cursor = Cursors.Hand;
                pictureBoxDetail.Click += DetailsIcon_Click;

                PictureBox pictureBoxEdit = new PictureBox();
                pictureBoxEdit.Size = new Size(iconSize, iconSize);
                pictureBoxEdit.Location = new Point((panelWidth / 2) - iconSize - (horizontalSpacing / 2), startYBottom);
                pictureBoxEdit.Image = Properties.Resources.EditIcon;
                pictureBoxEdit.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxEdit.Cursor = Cursors.Hand;
                pictureBoxEdit.Click += EditIcon_Click;


                PictureBox pictureBoxDelete = new PictureBox();
                pictureBoxDelete.Size = new Size(iconSize, iconSize);
                pictureBoxDelete.Location = new Point((panelWidth / 2) + (horizontalSpacing / 2), startYBottom);
                pictureBoxDelete.Image = Properties.Resources.DeleteIcon;
                pictureBoxDelete.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxDelete.Cursor = Cursors.Hand;
                pictureBoxDelete.Click += DeleteIcon_Click;
                pictureBoxDelete.Tag = recipes[i];

                overlayPanel.Controls.Add(pictureBoxDetail);
                overlayPanel.Controls.Add(pictureBoxEdit);
                overlayPanel.Controls.Add(pictureBoxDelete);

                Label label = new Label();
                label.AutoSize = true;
                label.Text = recipes[i].RecipeName;
                label.Location = new Point((panelWidth - label.Width) / 2, 12);

                Label percentageLabel = new Label();
                percentageLabel.AutoSize = true;
                percentageLabel.Text = "Yüzde: " + (recipes[i].AvailabilityPercentage).ToString("0.##") + "%";
                percentageLabel.Location = new Point((panelWidth - percentageLabel.Width) / 2, 40);

                Label costLabel = new Label();
                costLabel.AutoSize = true;
                costLabel.Text = "Maliyet: " + recipes[i].TotalCost.ToString("C");
                costLabel.Location = new Point((panelWidth - costLabel.Width) / 2, 60);

                mainPanel.Controls.Add(label);
                mainPanel.Controls.Add(percentageLabel); 
                mainPanel.Controls.Add(costLabel);
                mainPanel.Controls.Add(overlayPanel);

                panelItems.Controls.Add(mainPanel);
            }
        }
        private void DetailsIcon_Click(object sender, EventArgs e)
        {
            /*PictureBox picBox = sender as PictureBox;
            Recipe recipe = picBox?.Tag as Recipe;
            if (recipe != null)
            {
            }*/
        }
        private void EditIcon_Click(object sender, EventArgs e)
        {
            /*PictureBox picBox = sender as PictureBox;
            Recipe recipe = picBox?.Tag as Recipe;
            if (recipe != null)
            {
                // Düzenleme işlemini gerçekleştirin
            }*/
        }
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
        private void BringToFront(Panel panel)
        {
            Panel overlayPanel = panel.Controls.OfType<Panel>().FirstOrDefault(p => p.BackColor == Color.SandyBrown);
            if (overlayPanel != null)
            {
                overlayPanel.Visible = true;
                overlayPanel.BringToFront();
                overlayPanel.MouseEnter += (s, e) => overlayPanel.Visible = true;
                overlayPanel.MouseLeave += (s, e) => overlayPanel.Visible = false;
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
        private void CheckMouseLeave(Panel panel)
        {
            Panel overlayPanel = panel.Controls.OfType<Panel>().FirstOrDefault(p => p.BackColor == Color.SandyBrown);
            if (overlayPanel != null && overlayPanel.Visible)
            {
                if (!overlayPanel.ClientRectangle.Contains(overlayPanel.PointToClient(MousePosition)))
                {
                    overlayPanel.Visible = false; // Üstteki paneli gizle
                }
            }
        }
        private async void ComboBoxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
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

            await InitializeCustomPanelsAsync();
        }
        private void buttonPriceTagAdd_Click(object sender, EventArgs e)
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

            if (minPrice.HasValue || maxPrice.HasValue)
            {
                RemoveExistingFilter("Fiyat");

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
            int? minTime = null;
            int? maxTime = null;

            if (int.TryParse(textBoxMinPrepTime.Text, out int minTimeValue))
            {
                minTime = minTimeValue;
            }

            if (int.TryParse(textBoxMaxPrepTime.Text, out int maxTimeValue))
            {
                maxTime = maxTimeValue;
            }

            if (minTime.HasValue || maxTime.HasValue)
            {
                RemoveExistingFilter("Hazırlama Süresi");

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
            string selectedCategory = comboBoxCategory.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedCategory))
            {
                RemoveExistingFilter("Kategori");

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
            var selectedIngredient = comboBoxIngredients.SelectedItem as Ingredient;

            if (selectedIngredient != null)
            {
                var existingFilter = filterCriteriaList.FirstOrDefault(f => f.FilterType == "Malzeme" && f.Value == selectedIngredient.IngredientName);

                if (existingFilter == null)
                {
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
            string name = textBoxSearch.Text.Trim();

            var existingFilter = filterCriteriaList.FirstOrDefault(f => f.FilterType == "Tarif Adi");
            if (existingFilter != null)
            {
                existingFilter.Value = name;
            }
            else
            {
                filterCriteriaList.Add(new FilterCriteria { FilterType = "Tarif Adi", Value = name });
            }

            RefreshPanelsAsync();
            InitializeCustomPanelsAsync();
        }
        private void buttonFilter_Click(object sender, EventArgs e)
        {
            RefreshPanelsAsync();
        }
        private void AddFilterToPanel(string filterText, Action<Control> removeAction)
        {
            Panel filterPanel = new Panel
            {
                AutoSize = false,
                Width = 70,
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
            if(filterCriteriaList.Count == 0)
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
    }
}

using LezzetKitabi.Application.Services;
using LezzetKitabi.Domain.Dtos.RecipeDtos;
using LezzetKitabi.Domain.Entities;
using LezzetKitabi.Domain.Enums;
using LezzetKitabi.Services.Abstract;
using LezzetKitabi.Forms.Controls;
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
using LezzetKitabi.Domain.Dtos.CrossTableDtos;
using LezzetKitabi.Domain.Dtos.IngredientDtos;

namespace LezzetKitabi.Forms.Controls
{
    public partial class RecipeMainControl : UserControl
    {
        private readonly IRecipeService _recipeService;
        private readonly IIngredientService _ingredientService;
        private readonly IRecipeIngredientService _recipeIngredientService;
        private readonly IServiceProvider _serviceProvider;
        RecipeSortingType _sortingType = RecipeSortingType.Descending_Percentage;
        private int currentPage = 1;
        private int totalPages;
        private List<FilterCriteria> filterCriteriaList;
        public RecipeMainControl(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            filterCriteriaList = new List<FilterCriteria>();
            _recipeService = serviceProvider.GetRequiredService<IRecipeService>();
            _ingredientService = serviceProvider.GetRequiredService<IIngredientService>();
            _recipeIngredientService = serviceProvider.GetRequiredService<IRecipeIngredientService>();
            InitializeComponent();

            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            
            panelFilter.BackColor = Color.White;
            panelElements.BackColor = Color.Transparent;
            panelDown.BackColor = Color.Transparent;
            comboBoxCategory.Items.AddRange(Enum.GetNames(typeof(Category)));
        }

        public async Task LoadBackgroundImageAsync()
        {
            await Task.Run(() =>
            {
                BackgroundImage = Properties.Resources.kitchen_utensils_background_cookbook_seamless_600nw_2152405123;
            });

            this.Invalidate();
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

            List<RecipeViewGetDto> recipes = await _recipeService.GetAllRecipesByOrderAsync(_sortingType,filterCriteriaList);
            List<Ingredient> ingredients = await _ingredientService.GetAllIngredientsByOrderAndFilterAsync(IngredientSortingType.A_from_Z);
            textBoxSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection suggestions = new AutoCompleteStringCollection();


            foreach (var recipe in recipes)
            {
                suggestions.Add(recipe.RecipeName);
            }

            foreach (var ingredient in ingredients)
            {
                suggestions.Add(ingredient.IngredientName);
            }

            textBoxSearch.AutoCompleteCustomSource = suggestions;

            int totalRecipes = recipes.Count();
            totalPages = (int)Math.Ceiling(totalRecipes / (double)8);

            comboBoxIngredients.DataSource = ingredients;
            comboBoxIngredients.DisplayMember = "IngredientName";
            comboBoxIngredients.ValueMember = "Id";

            if (recipes == null || recipes.Count == 0)
            {
                MessageBox.Show("No recipes found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int startIndex = (currentPage - 1) * 8;
            int endIndex = Math.Min(startIndex + 8, recipes.Count);

            for (int i = startIndex; i < endIndex; i++)
            {
                int row = (i - startIndex) / cols;
                int col = (i - startIndex) % cols;

                Panel mainPanel = new Panel();
                mainPanel.Tag = recipes[i];

                Color labelColor;
                if (recipes[i].MissingCost == 0)
                {
                    mainPanel.BackColor = Color.FromArgb(187, 247, 208);
                    labelColor = Color.FromArgb(21, 128, 61);
                }
                else
                {
                    mainPanel.BackColor = Color.FromArgb(254, 202, 202);
                    labelColor = Color.FromArgb(185, 28, 28);
                }

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
                overlayPanel.BackColor = mainPanel.BackColor;
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
                        using (Brush brush = new SolidBrush(overlayPanel.BackColor)) // overlayPanel rengini burada da kullanıyoruz
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
                pictureBoxDetail.Tag = recipes[i];
                pictureBoxDetail.Click += DetailsIcon_Click;

                PictureBox pictureBoxEdit = new PictureBox();
                pictureBoxEdit.Size = new Size(iconSize, iconSize);
                pictureBoxEdit.Location = new Point((panelWidth / 2) - iconSize - (horizontalSpacing / 2), startYBottom);
                pictureBoxEdit.Image = Properties.Resources.EditIcon;
                pictureBoxEdit.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxEdit.Cursor = Cursors.Hand;
                pictureBoxEdit.Tag = recipes[i];
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

                PictureBox recipeImageBox = new PictureBox();
                recipeImageBox.Size = new Size(120, 120);
                recipeImageBox.Location = new Point((panelWidth - recipeImageBox.Width) / 2, 50);
                using (MemoryStream ms = new MemoryStream(recipes[i].Image))
                {
                    Image img = Image.FromStream(ms);

                    recipeImageBox.Image = img;
                }
                recipeImageBox.SizeMode = PictureBoxSizeMode.StretchImage;

                Label label = new Label();
                label.AutoSize = true;
                label.Text = recipes[i].RecipeName;
                label.Location = new Point((panelWidth - label.Width) / 2, 12);
                label.ForeColor = labelColor;

                Label percentageLabel = new Label();
                percentageLabel.AutoSize = true;
                percentageLabel.Text = "Yüzde: " + recipes[i].AvailabilityPercentage.ToString("0.##") + "%";
                percentageLabel.Location = new Point((panelWidth - percentageLabel.Width) / 2, 180);
                percentageLabel.ForeColor = labelColor;

                Label costLabel = new Label();
                costLabel.AutoSize = true;
                costLabel.Text = "Maliyet: ₺" + recipes[i].TotalCost.ToString("0.00");
                costLabel.Location = new Point((panelWidth - costLabel.Width) / 2, 200);
                costLabel.ForeColor = labelColor;

                Label missingCostLabel = new Label();
                missingCostLabel.AutoSize = true;
                missingCostLabel.Text = "Eksik Maliyet: ₺" + recipes[i].MissingCost.ToString("0.00");
                missingCostLabel.Location = new Point((panelWidth - missingCostLabel.Width) / 2, 220);
                missingCostLabel.ForeColor = labelColor;

                Label timeLabel = new Label();
                timeLabel.AutoSize = true;
                timeLabel.Text = "Tarif Süresi: " + recipes[i].PreparationTime + " dk";
                timeLabel.Location = new Point((panelWidth - timeLabel.Width) / 2, 240);
                timeLabel.ForeColor = labelColor;

                Label MatchingpercentageLabel = new Label();
                MatchingpercentageLabel.AutoSize = true;
                MatchingpercentageLabel.Text = "Yüzde: " + recipes[i].MatchingPercentage.ToString("0.##") + "%";
                MatchingpercentageLabel.Location = new Point((panelWidth - MatchingpercentageLabel.Width) / 2, 260);
                MatchingpercentageLabel.ForeColor = labelColor;

                mainPanel.Controls.Add(label);
                mainPanel.Controls.Add(recipeImageBox);
                mainPanel.Controls.Add(percentageLabel);
                mainPanel.Controls.Add(costLabel);
                mainPanel.Controls.Add(missingCostLabel);
                mainPanel.Controls.Add(timeLabel);
                if (recipes[i].MatchingPercentage != -1) mainPanel.Controls.Add(MatchingpercentageLabel);
                mainPanel.Controls.Add(overlayPanel);

                panelItems.Controls.Add(mainPanel);
            }
        }
        private async void DetailsIcon_Click(object sender, EventArgs e)
        {
            PictureBox DetailsIcon = sender as PictureBox;
            if (DetailsIcon?.Tag is RecipeViewGetDto selectedRecipe)
            {
                List<IngredientGetDto> ingredients = await _recipeIngredientService.GetIngredientsByRecipeIdAsync(selectedRecipe.Id);

                RecipeUpdateDto recipeUpdateDto = new RecipeUpdateDto
                {
                    Id = selectedRecipe.Id,
                    RecipeName = selectedRecipe.RecipeName,
                    Category = selectedRecipe.Category,
                    PreparationTime = selectedRecipe.PreparationTime,
                    Instructions = selectedRecipe.Instructions,
                    Image = selectedRecipe.Image,
                    Ingredients = ingredients
                };
                RecipeDetailsForm detailsForm = new RecipeDetailsForm(recipeUpdateDto);
                detailsForm.ShowDialog();
            }
        }
        private async void EditIcon_Click(object sender, EventArgs e)
        {
            PictureBox EditIcon = sender as PictureBox;

            if (EditIcon?.Tag is RecipeViewGetDto selectedRecipe)
            {
                List<IngredientGetDto> ingredients = await _recipeIngredientService.GetIngredientsByRecipeIdAsync(selectedRecipe.Id);

                RecipeUpdateDto recipeUpdateDto = new RecipeUpdateDto
                {
                    Id = selectedRecipe.Id,
                    RecipeName = selectedRecipe.RecipeName,
                    Category = selectedRecipe.Category,
                    PreparationTime = selectedRecipe.PreparationTime,
                    Instructions = selectedRecipe.Instructions,
                    Image = selectedRecipe.Image,
                    Ingredients = ingredients
                };

                RecipeEditForm editForm = new RecipeEditForm(recipeUpdateDto, _serviceProvider);
                editForm.RecipeUpdated += Form_RecipeUpdated;
                editForm.ShowDialog();
            }
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
        private async void Form_RecipeUpdated(object sender, EventArgs e)
        {
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
            Panel overlayPanel = panel.Controls.OfType<Panel>().FirstOrDefault(p => p.BackColor == panel.BackColor);
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
            Panel overlayPanel = panel.Controls.OfType<Panel>().FirstOrDefault(p => p.BackColor == panel.BackColor);
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
        private void button2_Click(object sender, EventArgs e)
        {
            int? minCount = null;
            int? maxCount = null;

            if (int.TryParse(textBoxminIngredientCount.Text, out int minCountValue))
            {
                minCount = minCountValue;
            }

            if (int.TryParse(textBoxmaxIngredientCount.Text, out int maxCountValue))
            {
                maxCount = maxCountValue;
            }

            if (minCount.HasValue || maxCount.HasValue)
            {
                RemoveExistingFilter("Malzeme Sayisi");

                AddFilterToPanel($"Malzeme Sayisi: {minCount} - {maxCount}", RemoveFilter);
                filterCriteriaList.Add(new FilterCriteria { FilterType = "Malzeme Sayisi", Value = $"{minCount} - {maxCount}" });
                textBoxmaxIngredientCount.Clear();
                textBoxminIngredientCount.Clear();
            }
            else
            {
                MessageBox.Show("Geçerli bir malzeme sayisi aralığı girin.");
            }
        }
        private async void button3_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                await RefreshPanelsAsync();
            }
            else
            {
                MessageBox.Show("Ilk Sayfaya Ulastiniz Daha Geri Gidemezsiniz!","Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                RefreshPanelsAsync();
            }
            else
            {
                MessageBox.Show("Son sayfaya ulaştınız, daha ileri gidemiyorsunuz.","Hata",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
    }
}

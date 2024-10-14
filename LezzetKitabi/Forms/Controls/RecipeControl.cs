using LezzetKitabi.Application.Services;
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
    public partial class RecipeControl : UserControl
    {
        private readonly IRecipeService _recipeService;
        RecipeSortingType _sortingType = RecipeSortingType.A_from_Z;
        public RecipeControl(IServiceProvider serviceProvider)
        {
            _recipeService = serviceProvider.GetRequiredService<IRecipeService>();
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

            // Tüm malzemeleri al
            List<Recipe> recipes = await _recipeService.GetAllRecipesAsync(_sortingType);

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

                // Düzenleme butonu
                PictureBox editIcon = new PictureBox();
                editIcon.Size = new Size(30, 30);
                editIcon.Location = new Point(10, 10);
                editIcon.Image = Properties.Resources.edit_24;  // Düzenleme ikonunu ayarlayın
                editIcon.SizeMode = PictureBoxSizeMode.Zoom;

                // Overlay paneline butonları ekleyin
                overlayPanel.Controls.Add(editIcon);


                // Ana paneli içerikleriyle birlikte ekleyin
                Label label = new Label();
                label.AutoSize = true;
                label.Text = recipes[i].RecipeName; // Dinamik malzeme adı
                label.Location = new Point((panelWidth - label.Width) / 2, 12);  // Ortalayın

                mainPanel.Controls.Add(label);
                mainPanel.Controls.Add(overlayPanel);

                // Ana paneli panelItems'a ekleyin
                panelItems.Controls.Add(mainPanel);
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

        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            Button deleteButton = sender as Button;

            if (deleteButton != null)
            {
                // Delete butonunun Tag'inde hangi ingredient olduğunu al
                Recipe recipeToDelete = deleteButton.Tag as Recipe;

                if (recipeToDelete != null)
                {
                    bool isDeleted = await Task.Run(() => _recipeService.DeleteRecipe(recipeToDelete.Id));

                    if (isDeleted)
                    {
                        MessageBox.Show("Recipe deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await RefreshPanelsAsync();  // Panel yenileme işlemini async yap
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the Recipe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void ComboBoxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Seçilen index'e göre sortingType'ı ayarlama
            switch (comboBoxSort.SelectedIndex)
            {
                case 0:
                    _sortingType = RecipeSortingType.A_from_Z;
                    break;
                case 1:
                    _sortingType = RecipeSortingType.Z_from_A;
                    break;
                case 2:
                    _sortingType = RecipeSortingType.Cheapest_to_Expensive;
                    break;
                case 3:
                    _sortingType = RecipeSortingType.Expensive_to_Cheapest;
                    break;
                /*case 4:
                    _sortingType = RecipeSortingType.DescendingStock;
                    break;
                case 5:
                    _sortingType = RecipeSortingType.AscendingStock;
                    break;*/
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
    }
}

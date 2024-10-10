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
    public partial class SearchControl : UserControl
    {
        private readonly IServiceProvider _serviceProvider;
        public SearchControl(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
            InitializeGradientPanel(panelElements);
            InitializeCustomPanels();

            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            // Arka plan rengini transparent yapın
            panelElements.BackColor = Color.Transparent;
            panelItems.BackColor = Color.Transparent;
            panelPrevius.BackColor = Color.Transparent;
            panelNext.BackColor = Color.Transparent;
        }

        private void InitializeCustomPanels()
        {
            int rows = 3;  // 3 rows
            int cols = 5;  // 5 columns
            int panelWidth = 160;  // Panel width
            int panelHeight = 190; // Panel height
            int xPadding = 12;  // Horizontal padding between panels
            int yPadding = 12;  // Vertical padding between panels
            int startX = 10; // Starting X position
            int startY = 10; // Starting Y position

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    // Create main panel
                    Panel mainPanel = new Panel();
                    mainPanel.BackColor = SystemColors.ActiveCaption;
                    mainPanel.Size = new Size(panelWidth, panelHeight);
                    int x = startX + col * (panelWidth + xPadding);
                    int y = startY + row * (panelHeight + yPadding);
                    mainPanel.Location = new Point(x, y);

                    // Set up mouse events
                    mainPanel.MouseEnter += (s, e) => BringToFront(mainPanel);
                    mainPanel.MouseLeave += (s, e) => CheckMouseLeave(mainPanel);

                    // Create PictureBox
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = Properties.Resources.Screenshot_2024_10_09_121511;
                    pictureBox.Size = new Size(115, 94);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Location = new Point((panelWidth - pictureBox.Width) / 2, 35);  // Center horizontally and move down

                    // Create label for "Malzeme Adı"
                    Label label = new Label();
                    label.AutoSize = true;
                    label.Text = "Malzeme Adı";
                    label.Location = new Point((panelWidth - label.Width) / 2, 12);  // Center horizontally

                    // Create labels for "Miktar" and "Birim Fiyatı"
                    Label labelMiktar = new Label();
                    labelMiktar.AutoSize = true;
                    labelMiktar.Text = "Miktar";
                    labelMiktar.Location = new Point((panelWidth - labelMiktar.Width) / 2, pictureBox.Bottom + 5);  // Below pictureBox

                    Label labelBirimFiyati = new Label();
                    labelBirimFiyati.AutoSize = true;
                    labelBirimFiyati.Text = "Birim Fiyatı";
                    labelBirimFiyati.Location = new Point((panelWidth - labelBirimFiyati.Width) / 2, labelMiktar.Bottom + 5);  // Below "Miktar" label

                    // Create overlay panel
                    Panel overlayPanel = new Panel();
                    overlayPanel.BackColor = Color.Purple; // Overlay panel color
                    overlayPanel.Size = new Size(panelWidth, panelHeight);
                    overlayPanel.Location = new Point(0, 0);
                    overlayPanel.Visible = false; // Hidden initially

                    // Create buttons in the overlay panel
                    Button button1 = new Button();
                    button1.Text = "Button 1";
                    button1.Size = new Size(80, 30);
                    button1.Location = new Point(10, 10);

                    Button button2 = new Button();
                    button2.Text = "Button 2";
                    button2.Size = new Size(80, 30);
                    button2.Location = new Point(100, 10);

                    // Add buttons to the overlay panel
                    overlayPanel.Controls.Add(button1);
                    overlayPanel.Controls.Add(button2);

                    // Add controls to the main panel
                    mainPanel.Controls.Add(label);
                    mainPanel.Controls.Add(pictureBox);
                    mainPanel.Controls.Add(labelMiktar);
                    mainPanel.Controls.Add(labelBirimFiyati);
                    mainPanel.Controls.Add(overlayPanel);

                    // Add main panel to panelItems
                    panelItems.Controls.Add(mainPanel);
                }
            }
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
                using (LinearGradientBrush brush = new LinearGradientBrush(panel.ClientRectangle, startColor, endColor, LinearGradientMode.ForwardDiagonal))
                {
                    // Paneli degrade ile doldur
                    e.Graphics.FillRectangle(brush, panel.ClientRectangle);
                }
            };
        }
    }
}

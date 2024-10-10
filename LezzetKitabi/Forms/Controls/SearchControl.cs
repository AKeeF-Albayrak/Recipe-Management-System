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
            int cornerRadius = 20;  // Yuvarlak köşe yarıçapı

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    // Ana panel oluştur
                    Panel mainPanel = new Panel();
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
                    pictureBox.Image = Properties.Resources.Screenshot_2024_10_09_121511;
                    pictureBox.Size = new Size(115, 94);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Location = new Point((panelWidth - pictureBox.Width) / 2, 35);  // Ortalayın

                    Label label = new Label();
                    label.AutoSize = true;
                    label.Text = "Malzeme Adı";
                    label.Location = new Point((panelWidth - label.Width) / 2, 12);  // Ortalayın

                    Label labelMiktar = new Label();
                    labelMiktar.AutoSize = true;
                    labelMiktar.Text = "Miktar";
                    labelMiktar.Location = new Point((panelWidth - labelMiktar.Width) / 2, pictureBox.Bottom + 5);

                    Label labelBirimFiyati = new Label();
                    labelBirimFiyati.AutoSize = true;
                    labelBirimFiyati.Text = "Birim Fiyatı";
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

                    Button button2 = new Button();
                    button2.Text = "Button 2";
                    button2.Size = new Size(80, 30);
                    button2.Location = new Point(100, 10);

                    overlayPanel.Controls.Add(button1);
                    overlayPanel.Controls.Add(button2);

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
                using (LinearGradientBrush brush = new LinearGradientBrush(panel.ClientRectangle, startColor, endColor, LinearGradientMode.ForwardDiagonal))
                {
                    // Paneli degrade ile doldur
                    e.Graphics.FillRectangle(brush, panel.ClientRectangle);
                }
            };
        }
    }
}

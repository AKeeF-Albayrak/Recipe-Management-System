using System;
using System.Windows.Forms;

namespace LezzetKitabi.Forms.Controls
{
    public partial class DenemeControl : UserControl
    {
        public DenemeControl()
        {
            InitializeComponent();
            InitializeCustomPanels();
        }

        private void InitializeCustomPanels()
        {
            int rows = 2; // 2 satır
            int cols = 4; // 4 sütun
            int panelWidth = 201;  // Panel genişliği
            int panelHeight = 213; // Panel yüksekliği
            int xPadding = 20; // Paneller arasındaki yatay boşluk
            int yPadding = 20; // Paneller arasındaki dikey boşluk
            int startX = 10; // Başlangıç X konumu
            int startY = 10; // Başlangıç Y konumu

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    // Ana panel oluştur
                    Panel mainPanel = new Panel();
                    mainPanel.BackColor = SystemColors.ActiveCaption;
                    mainPanel.Size = new Size(panelWidth, panelHeight);
                    int x = startX + col * (panelWidth + xPadding);
                    int y = startY + row * (panelHeight + yPadding);
                    mainPanel.Location = new Point(x, y);

                    // Mouse olaylarını ayarla
                    mainPanel.MouseEnter += (s, e) => BringToFront(mainPanel);
                    mainPanel.MouseLeave += (s, e) => CheckMouseLeave(mainPanel);

                    // PictureBox
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = Properties.Resources.Screenshot_2024_10_09_121511;
                    pictureBox.Size = new Size(115, 94);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Location = new Point(42, 38);

                    // Label
                    Label label = new Label();
                    label.AutoSize = true;
                    label.Location = new Point(55, 12);
                    label.Text = "Malzeme Adı";

                    // Üstteki panel
                    Panel overlayPanel = new Panel();
                    overlayPanel.BackColor = Color.Purple; // Üstteki panelin rengi
                    overlayPanel.Size = new Size(panelWidth, panelHeight);
                    overlayPanel.Location = new Point(0, 0);
                    overlayPanel.Visible = false; // Başlangıçta görünmez

                    // Butonları oluştur
                    Button button1 = new Button();
                    button1.Text = "Button 1";
                    button1.Size = new Size(80, 30);
                    button1.Location = new Point(10, 10);

                    Button button2 = new Button();
                    button2.Text = "Button 2";
                    button2.Size = new Size(80, 30);
                    button2.Location = new Point(100, 10);

                    // Butonları overlay paneline ekle
                    overlayPanel.Controls.Add(button1);
                    overlayPanel.Controls.Add(button2);

                    // Ana panelin içeriklerini ekle
                    mainPanel.Controls.Add(label);
                    mainPanel.Controls.Add(pictureBox);
                    mainPanel.Controls.Add(overlayPanel);

                    // Ana paneli UserControl'e ekle
                    panel13.Controls.Add(mainPanel);
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


        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("İşlem başarıyla tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

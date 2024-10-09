using LezzetKitabi.Data.Repositories.Abstract;
using LezzetKitabi.Forms.Controls;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks; // Task kullanımını ekleyin
using System.Windows.Forms;

namespace LezzetKitabi.Forms
{
    public partial class MainForm : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private bool isAnimating = false;
        string page = "Home";
        public MainForm(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
            LoadForm(new SearchControl(serviceProvider));
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (isAnimating) return; // Eğer animasyon devam ediyorsa çık

            isAnimating = true; // Animasyon başladı
            try
            {
                // Menüyü genişlet/daralt
                int delayTime = 10; // Her adım için bekleme süresi (ms) azaltıldı
                int maxSteps = 30; // Toplam adım sayısını azaltıldı
                int currentStep = 0; // Mevcut adım sayısı
                int stepSize = 4; // Başlangıç adım boyutu (artırıldı)

                if (panelMenu.Width > 200) // Menüyü daraltma
                {
                    while (panelMenu.Width > 100 && currentStep < maxSteps) // Minimum genişlik kontrolü
                    {
                        panelMenu.Width -= stepSize; // Menü genişliğini azalt
                        await Task.Delay(delayTime); // Bekle

                        // Adım boyutunu artır (daha kontrollü bir hızlandırma)
                        if (currentStep < maxSteps / 2)
                        {
                            stepSize = 4 + (currentStep / 4); // İlk yarıda adım boyutunu hafifçe artır
                        }

                        currentStep++;
                    }
                }
                else // Menüyü genişletme
                {
                    while (panelMenu.Width < 230 && currentStep < maxSteps) // Maksimum genişlik kontrolü
                    {
                        panelMenu.Width += stepSize; // Menü genişliğini arttır
                        await Task.Delay(delayTime); // Bekle

                        // Adım boyutunu artır (daha kontrollü bir hızlandırma)
                        if (currentStep < maxSteps / 2)
                        {
                            stepSize = 4 + (currentStep / 4); // İlk yarıda adım boyutunu hafifçe artır
                        }

                        currentStep++;
                    }
                }
            }
            finally
            {
                isAnimating = false; // Animasyon tamamlandı
            }
        }

        private void LoadForm(UserControl userControl)
        {
            panelForms.Controls.Clear(); // Mevcut içeriği temizle
            userControl.Dock = DockStyle.Fill; // UserControl tüm paneli kaplasın
            panelForms.Controls.Add(userControl); // Yeni UserControl'ü panele ekle
            userControl.BringToFront(); // Üste getir
        }

        private void buttonRecipe_Click(object sender, EventArgs e)
        {
            if(page != "Recipe")    LoadForm(new RecipeControl(_serviceProvider));
            page = "Recipe";
        }

        private void buttonIngredient_Click(object sender, EventArgs e)
        {
            if(page != "Ingredient")    LoadForm(new IngredientControl(_serviceProvider));
            page = "Ingredient";
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if(page != "Search")   LoadForm(new SearchControl(_serviceProvider));
            page = "Search";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(page != "Deneme1") LoadForm(new DenemeControl());
            page = "Deneme1";
        }
    }
}

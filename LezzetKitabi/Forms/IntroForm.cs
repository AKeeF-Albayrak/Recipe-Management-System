using LezzetKitabi.Forms.Controls;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LezzetKitabi.Forms
{
    public partial class IntroForm : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private System.Windows.Forms.Timer _timer;

        public IntroForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            //Load += IntroForm_Load;
        }

        /*private async void IntroForm_Load(object sender, EventArgs e)
        {
            // Kontrolleri oluştur
            var ingredientControl = _serviceProvider.GetService<IngredientControl>();
            var recipeControl = _serviceProvider.GetService<RecipeControl>();
            var searchControl = _serviceProvider.GetService<SearchControl>();

            // Ana formu al
            MainForm mainForm = _serviceProvider.GetService<MainForm>();

            // Kontrolleri ana forma ekle
            mainForm.panelControls.Controls.Add(ingredientControl);
            mainForm.panelControls.Controls.Add(recipeControl);
            mainForm.panelControls.Controls.Add(searchControl);

            // Kontrolleri görünür hale getir
            ingredientControl.Visible = true;  // İlk kontrolü görünür yapın
            recipeControl.Visible = false;
            searchControl.Visible = false;

            // Ana formu görünmez yap
            mainForm.Hide();  // Ana formu gizle

            // 6 saniye bekle
            await Task.Delay(6000);

            // RecipeControl'ü göster
            recipeControl.Visible = true; // recipeControl'ü görünür yap

            // Ana formu göster ve aktif kontrolü ayarla
            mainForm.Show();  // Ana formu göster
            mainForm.SetActiveControl(recipeControl); // Aktif kontrolü ayarla

            // Intro ekranını kapat
            this.Hide();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();

            // Ana formu aç
            var mainForm = _serviceProvider.GetService<MainForm>();
            mainForm.Show();

            // Bu formu kapat
            this.Hide();
        }*/
    }
}

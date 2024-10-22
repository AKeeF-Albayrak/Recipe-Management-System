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
            Load += IntroForm_Load;
        }

        private async void IntroForm_Load(object sender, EventArgs e)
        {

            MainForm mainForm = _serviceProvider.GetService<MainForm>();

            mainForm.Hide();

            await Task.Delay(6000);

            mainForm.Show();

            this.Hide();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();

            var mainForm = _serviceProvider.GetService<MainForm>();
            mainForm.Show();


            this.Hide();
        }
    }
}

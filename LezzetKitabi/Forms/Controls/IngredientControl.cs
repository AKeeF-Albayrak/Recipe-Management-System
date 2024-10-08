using LezzetKitabi.Services.Abstract;
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

namespace LezzetKitabi.Forms.Controls
{
    public partial class IngredientControl : UserControl
    {
        private readonly IServiceProvider _serviceProvider;
        public IngredientControl(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ingredientService = _serviceProvider.GetService<IIngredientService>();

            // Servisi kullan
            ingredientService.Test();
        }
    }
}

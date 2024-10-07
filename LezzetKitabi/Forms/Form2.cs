using LezzetKitabi.Services.Abstract;
using LezzetKitabi.Services.Concrete;
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
    public partial class Form2 : Form
    {
        private readonly IIngredientService _ingredientService;
        public Form2(IIngredientService ingredientService)
        {
            InitializeComponent();
            _ingredientService = ingredientService;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _ingredientService.AddEntity();
        }
    }
}

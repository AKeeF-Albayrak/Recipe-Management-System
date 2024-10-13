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
    public partial class RecipeUpdateControl : UserControl
    {
        public RecipeUpdateControl()
        {
            InitializeComponent();
            numericUpDownHours.Minimum = 0;
            numericUpDownHours.Maximum = 23;

            numericUpDownMinutes.Minimum = 0;
            numericUpDownMinutes.Maximum = 59;
        }

        private void metroSetDefaultButton1_Click(object sender, EventArgs e)
        {

        }
    }
}

using LezzetKitabi.Data.Repositories.Abstract;
using LezzetKitabi.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace LezzetKitabi
{
    public partial class Form1 : Form
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IServiceProvider _serviceProvider;
        public Form1(IIngredientRepository ingredientRepository, IServiceProvider serviceProvider)
        {
            _ingredientRepository = ingredientRepository;
            _serviceProvider = serviceProvider;
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form2 = _serviceProvider.GetService<Form2>();
            form2.Show();
            this.Hide();
        }
    }
}

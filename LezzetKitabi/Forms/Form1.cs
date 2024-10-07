using LezzetKitabi.Data.Repositories.Abstract;
using LezzetKitabi.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace LezzetKitabi
{
    public partial class Form1 : Form
    {
        private readonly IIngredientRepository _ıngredientRepository;
        private readonly IServiceProvider _serviceProvider;
        public Form1(IIngredientRepository ıngredientRepository, IServiceProvider serviceProvider)
        {
            _ıngredientRepository = ıngredientRepository;
            _serviceProvider = serviceProvider;
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var detailsForm = _serviceProvider.GetService<Form2>();
            detailsForm.Show();
        }
    }
}

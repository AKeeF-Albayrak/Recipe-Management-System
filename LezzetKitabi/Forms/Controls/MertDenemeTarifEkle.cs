using LezzetKitabi.Domain.Dtos.RecipeDtos;
using LezzetKitabi.Services.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace LezzetKitabi.Forms.Controls
{
    public partial class MertDenemeTarifEkle : UserControl
    {
        private readonly IRecipeService _recipeService;

        public MertDenemeTarifEkle(IServiceProvider serviceProvider)
        {
            _recipeService = serviceProvider.GetRequiredService<IRecipeService>();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var recipeAddDto = new RecipeAddDto
            {
                RecipeName = txtRecipeName.Text,
                Category = txtCategory.Text,
                PreparationTime = (int)numPreparationTime.Value,  // Doğrudan int değeri alıyoruz
                Instructions = txtInstructions.Text
            };

            _recipeService.AddRecipe(recipeAddDto);

            MessageBox.Show("Tarif başarıyla eklendi!");
        }        
    }
}

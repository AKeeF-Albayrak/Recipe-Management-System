using LezzetKitabi.Data.Repositories.Abstract;
using LezzetKitabi.Domain.Contracts;
using LezzetKitabi.Forms.Controls;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LezzetKitabi.Forms
{
    public partial class MainForm : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private bool isAnimating = false;
        public static string page;

        public RecipeMainControl _recipeMainControl;
        private IngredientMainControl _ingredientMainControl;
        public MainForm(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();

            _recipeMainControl = _serviceProvider.GetRequiredService<RecipeMainControl>();
            _ingredientMainControl = _serviceProvider.GetRequiredService<IngredientMainControl>();

            panelForms.Controls.Add(_recipeMainControl);
            panelForms.Controls.Add(_ingredientMainControl);

            _recipeMainControl.Visible = false;
            _ingredientMainControl.Visible = false;
            LoadForm(_recipeMainControl);

            Load();
            page = "Recipes";
        }
        private async void Load()
        {
            await _recipeMainControl.LoadBackgroundImageAsync();
            await _recipeMainControl.RefreshPanelsAsync();
            await _ingredientMainControl.RefreshPanelsAsync();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (isAnimating) return;

            isAnimating = true;
            try
            {
                int delayTime = 10;
                int maxSteps = 30;
                int currentStep = 0;
                int stepSize = 4;

                if (panelMenu.Width > 200)
                {
                    while (panelMenu.Width > 100 && currentStep < maxSteps)
                    {
                        panelMenu.Width -= stepSize;
                        await Task.Delay(delayTime);

                        if (currentStep < maxSteps / 2)
                        {
                            stepSize = 4 + (currentStep / 4);
                        }

                        currentStep++;
                    }
                    GlobalVariables.IsExpanded = false;
                }
                else
                {
                    while (panelMenu.Width < 210 && currentStep < maxSteps)
                    {
                        panelMenu.Width += stepSize;
                        await Task.Delay(delayTime);

                        if (currentStep < maxSteps / 2)
                        {
                            stepSize = 4 + (currentStep / 4);
                        }

                        currentStep++;
                    }
                    GlobalVariables.IsExpanded = true;
                }
            }
            finally
            {
                isAnimating = false;
            }
        }
        private void LoadForm(UserControl userControl)
        {
            panelForms.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            panelForms.Controls.Add(userControl);

            userControl.Visible = true;
            userControl.BringToFront();
        }

        private async void btnRecipes_Click(object sender, EventArgs e)
        {
            if (page != "Recipes")
            {
                await _recipeMainControl.RefreshPanelsAsync();
                LoadForm(_recipeMainControl);
                page = "Recipes";
            }
        }

        private async void btnIngredients_Click(object sender, EventArgs e)
        {
            if (page != "Ingredients")
            {
                await _ingredientMainControl.RefreshPanelsAsync();
                LoadForm(_ingredientMainControl);
                page = "Ingredients";
                
            }
        }

        public async void btnAddIngredient_Click(object sender, EventArgs e)
        {
            if (page != "AddIngredient")
            {
                LoadForm(new IngredientAddControl(_serviceProvider));
                page = "AddIngredient";
            }
        }

        private async void btnAddRecipe_Click(object sender, EventArgs e)
        {
            if (page != "AddRecipe")
            {
                LoadForm(new RecipeAddControl(_serviceProvider));
                page = "AddRecipe";
            }
        }
    }
}

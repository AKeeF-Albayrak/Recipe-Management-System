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

        private RecipeMainControl _recipeMainControl;
        private IngredientMainControl _ingredientMainControl;
        private IngredientAddControl _ingredientAddControl;
        private RecipeAddControl _recipeAddControl;
        public MainForm(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();

            _recipeMainControl = _serviceProvider.GetRequiredService<RecipeMainControl>();
            _ingredientMainControl = _serviceProvider.GetRequiredService<IngredientMainControl>();
            _ingredientAddControl = _serviceProvider.GetRequiredService<IngredientAddControl>();
            _recipeAddControl = _serviceProvider.GetRequiredService<RecipeAddControl>();

            panelForms.Controls.Add(_recipeMainControl);
            panelForms.Controls.Add(_ingredientMainControl);
            panelForms.Controls.Add(_ingredientAddControl);
            panelForms.Controls.Add(_recipeAddControl);

            _recipeMainControl.Visible = false;
            _ingredientMainControl.Visible = false;
            _ingredientAddControl.Visible = false;
            _recipeAddControl.Visible = false;

            LoadForm(_recipeMainControl);
            _recipeMainControl.RefreshPanelsAsync();
            _recipeMainControl.LoadBackgroundImageAsync();
            page = "Recipes";
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
            foreach (Control control in panelForms.Controls)
            {
                control.Visible = false;
            }

            userControl.Visible = true;
            userControl.BringToFront();
        }

        private async void btnRecipes_Click(object sender, EventArgs e)
        {
            if (page != "Recipes")
            {
                LoadForm(_recipeMainControl);
                page = "Recipes";
                await _recipeMainControl.RefreshPanelsAsync();
                await _recipeMainControl.LoadBackgroundImageAsync();
            }
        }

        private async void btnIngredients_Click(object sender, EventArgs e)
        {
            if (page != "Ingredients")
            {
                LoadForm(_ingredientMainControl);
                page = "Ingredients";
                await _ingredientMainControl.RefreshPanelsAsync();
                await _ingredientMainControl.LoadBackgroundImageAsync();
            }
        }

        public void btnAddIngredient_Click(object sender, EventArgs e)
        {
            if (page != "AddIngredient")
            {
                LoadForm(_ingredientAddControl);
                page = "AddIngredient";
            }
        }

        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            if (page != "AddRecipe")
            {
                LoadForm(_recipeAddControl);
                page = "AddRecipe";
            }
        }
    }
}

using LezzetKitabi.Data.Repositories.Abstract;
using LezzetKitabi.Domain.Contracts;
using LezzetKitabi.Forms.Controls;
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
        RecipeMainForm recipeMainForm;
        private bool isAnimating = false;
        string page;
        public MainForm(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            recipeMainForm = new RecipeMainForm(serviceProvider);
            InitializeComponent();
            LoadForm(recipeMainForm);
            page = "Search";
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
            userControl.BringToFront();
        }


        private void btnRecipes_Click(object sender, EventArgs e)
        {
            if (page != "Recipes") LoadForm(recipeMainForm);
            page = "Recipes";
        }

        private void btnIngredients_Click(object sender, EventArgs e)
        {
            if (page != "Ingredients") LoadForm(new IngredientMainForm(_serviceProvider));
            page = "Ingredients";
        }

        private void btnAddIngredient_Click(object sender, EventArgs e)
        {
            if (page != "AddIngredient") LoadForm(new IngredientAddForm(_serviceProvider));
            page = "AddIngredient";
        }

        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            if (page != "AddRecipe") LoadForm(new RecipeAddForm(_serviceProvider));
            page = "AddRecipe";
        }

        private void btnEditRecipe_Click(object sender, EventArgs e)
        {
            if (page != "EditRecipe") LoadForm(new RecipeEditForm(/*simdilik eksik*/));
            page = "EditRecipe";
        }

        private void btnDeleteRecipe_Click(object sender, EventArgs e)
        {
            if (page != "DeleteRecipe") LoadForm(new RecipeDeleteForm(/*simdilik eksik*/));
            page = "DeleteRecipe";
        }
    }
}

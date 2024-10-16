using LezzetKitabi.Application.Services;
using LezzetKitabi.Data.Repositories.Abstract;
using LezzetKitabi.Data.Repositories.Concrete;
using LezzetKitabi.Domain.Contracts;
using LezzetKitabi.Forms;
using System.Windows.Forms;
using LezzetKitabi.Services.Abstract;
using LezzetKitabi.Services.Concrete;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;
using LezzetKitabi.Forms.Controls;
using Dapper;
using LezzetKitabi.Domain.Entities;

namespace LezzetKitabi
{
    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();

            //Saving Services
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IRecipeIngredientService, RecipeIngredientService>();

            //Saving Repos
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IRecipeIngredientRepository, RecipeIngredientRepository>();

            //Saving Forms
            services.AddScoped<MainForm>();

            //Adding Controls
            services.AddScoped<IngredientAddForm>();
            services.AddScoped<RecipeAddForm>();
            services.AddScoped<RecipeDeleteForm>();
            services.AddScoped<RecipeEditForm>();
            services.AddScoped<RecipeMainForm>();
            services.AddScoped<IngredientMainForm>();

            services.AddScoped<IDbConnection>(sp => new SqlConnection(ConstVariables.ConnectionString));

            var serviceProvider = services.BuildServiceProvider();

            // MainForm'u IServiceProvider olarak ge�iyoruz
            System.Windows.Forms.Application.Run(serviceProvider.GetService<MainForm>());
        }
    }
}
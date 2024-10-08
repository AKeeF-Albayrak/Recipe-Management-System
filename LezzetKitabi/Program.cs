using LezzetKitabi.Data.Repositories.Abstract;
using LezzetKitabi.Data.Repositories.Concrete;
using LezzetKitabi.Domain.Contracts;
using LezzetKitabi.Forms;
using LezzetKitabi.Services.Abstract;
using LezzetKitabi.Services.Concrete;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

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
            /*var services = new ServiceCollection();

            // Servislerin kaydý
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddScoped<IRecipeService, RecipeService>();

            // Repository'yi kaydediyoruz
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();

            // Formlarý kaydediyoruz
            services.AddScoped<Form1>();
            services.AddScoped<Form2>();

            services.AddScoped<IDbConnection>(sp => new SqlConnection(ConstVariables.ConnectionString));

            var serviceProvider = services.BuildServiceProvider();

            Application.Run(serviceProvider.GetService<Form1>());*/
            Application.Run(new MainForm());
        }
    }
}
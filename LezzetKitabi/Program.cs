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
            services.AddScoped<IngredientControl>();
            services.AddScoped<RecipeControl>();
            services.AddScoped<SearchControl>();
            services.AddScoped<RecipeUpdateControl>();

            services.AddScoped<IDbConnection>(sp => new SqlConnection(ConstVariables.ConnectionString));

            var serviceProvider = services.BuildServiceProvider();

            // MainForm'u IServiceProvider olarak ge�iyoruz
            System.Windows.Forms.Application.Run(serviceProvider.GetService<MainForm>());
        }
    }
}
//eksikler var tam istediklerimi yapamadım, dışarıdan malzeme eklerken cross  table'da veri kaybı oluyor eklenen her malzemenin en az bir tarifle ilişkisi olması lazım, addEntity kaldırılmalı yerine sadece ingredient ve recipe ile ilgili özel add methodları eklenmeli, DTO'lar büyük sıkıntı eksik dtolar var -mert 
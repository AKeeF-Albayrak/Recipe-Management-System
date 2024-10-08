using LezzetKitabi.Data.Repositories.Abstract;
using LezzetKitabi.Data.Repositories.Concrete;
using LezzetKitabi.Forms;
using LezzetKitabi.Services.Abstract;
using LezzetKitabi.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

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
            //services.AddScoped<>
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddScoped<Form1>();
            services.AddScoped<Form2>();

            var serviceProvider = services.BuildServiceProvider();

            Application.Run(serviceProvider.GetService<Form1>());
        }
    }
}
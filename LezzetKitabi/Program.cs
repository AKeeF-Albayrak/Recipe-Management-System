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
// tarif eklenirken aynı isimli tarif eklenemiyor ( evet GetRecipeByName yeniden bizlerlee :D ), tarif eklendikten sonra textbox vs içleri temizleniyor, adam yanlışlıkla bir malzeme eklerse silemiyor -> silmek için bir buton ekledim, silme işlemini yapıyordu ancak 2 listbox olduğu için ikisini de select ediyor orada görüntü hoşuma gitmedi o yüzden şimdilik yorum satırına aldım, tasarımda da butonlar hala leş onlar değişecek bir de malzeme ekleme kısmında yeni malzeme ekle butonu olacak o buton senin daha önce yaptığın malzeme ekleme form'una yönlendirecek gibi dusundum ama oyle yapınca da hali hazırda yarım eklenmis olan tarif içeriği siliniyo (en iyisi böyle kalsın) 


//BOŞ TARİF EKLENEBİLİYOR HİÇBİR AŞAMA ATLANMAMALI !
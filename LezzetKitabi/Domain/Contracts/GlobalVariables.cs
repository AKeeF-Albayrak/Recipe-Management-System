using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LezzetKitabi.Domain.Contracts
{
    public static class GlobalVariables
    {
        public static bool IsExpanded { get; set; } = true;

        public static byte[] BaseIngredientImage { get; private set; }
        public static byte[] BaseRecipeImage { get; private set; }

        static GlobalVariables()
        {
            BaseIngredientImage = LoadBaseImage();
            BaseRecipeImage = LoadBaseImageRecipeImage();
        }

        private static byte[] LoadBaseImageRecipeImage()
        {
            Image img = Properties.Resources.IngredientBase;
            using (var ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private static byte[] LoadBaseImage()
        {
            Image img = Properties.Resources._6330592__1_;
            using (var ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
}

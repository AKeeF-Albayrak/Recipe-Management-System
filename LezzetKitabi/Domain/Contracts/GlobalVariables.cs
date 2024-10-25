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

        public static byte[] BaseImage { get; private set; }

        static GlobalVariables()
        {
            BaseImage = LoadBaseImage();
        }
        private static byte[] LoadBaseImage()
        {
            Image img = Properties.Resources.Screenshot_2024_10_09_121511;
            using (var ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
}

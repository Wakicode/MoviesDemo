using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MoviesDemo.Core
{
    public static class Tools
    {
        public static BitmapImage GetImageFromPath(string img)
        {
            
            BitmapImage bimage = new BitmapImage();

            bimage.BeginInit();

            bimage.UriSource = new Uri(img, UriKind.RelativeOrAbsolute);

            bimage.EndInit();

            return bimage;
        }

        public static async Task<BitmapImage> GetImageFromPathAsync(string img)
        {
            return await Task.Run(() =>
            {
                BitmapImage bimage = new BitmapImage();

                bimage.BeginInit();

                bimage.UriSource = new Uri(img, UriKind.RelativeOrAbsolute);

                bimage.EndInit();

                return bimage;
            });
           
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace HeliosCheat.Helpers
{
    public class MediaHelper
    {
        public static BitmapImage? ConvertIconToBitmapImage(Icon? icon)
        {
            if (icon == null) return null;

            // Create a memory stream to hold the icon data
            using (MemoryStream iconStream = new MemoryStream())
            {
                // Save the icon to the memory stream
                icon.Save(iconStream);

                // Rewind the stream to the beginning
                iconStream.Seek(0, SeekOrigin.Begin);

                // Create a BitmapImage and initialize it from the memory stream
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = iconStream;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                return bitmapImage;
            }
        }
    }
}

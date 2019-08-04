using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.Formats.Bmp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;

namespace MiBand4SkinEditor.Core {
    public static class ImageSharpExtensions {
        public static System.Drawing.Bitmap ToBitmap <TPixel>(this Image<TPixel> image) where TPixel : struct, IPixel<TPixel> {
            var memoryStream = new MemoryStream();
            var imageEncoder = image.GetConfiguration().ImageFormatsManager.FindEncoder(PngFormat.Instance);
            image.Save(memoryStream, imageEncoder);

            memoryStream.Seek(0, SeekOrigin.Begin);

            return new System.Drawing.Bitmap(memoryStream);
        }

        public static Image<TPixel> ToImageSharpImage <TPixel>(this System.Drawing.Bitmap bitmap) where TPixel : struct, IPixel<TPixel> {
            var memoryStream = new MemoryStream();
            bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);

            memoryStream.Seek(0, SeekOrigin.Begin);

            return Image.Load<TPixel>(memoryStream);
        }
    }
}
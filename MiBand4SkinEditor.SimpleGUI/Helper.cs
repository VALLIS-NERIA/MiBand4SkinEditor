using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using MiBand4SkinEditor.Core.Models.UIElements;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.Formats.Bmp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using Image = SixLabors.ImageSharp.Image;

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

        public static System.Drawing.Bitmap RenderBitmap(this IElement element) {
            Bitmap bitmap;
            using (var img = element.Render()) {
                bitmap = img.ToBitmap();
            }

            return bitmap;
        }

        public static void DrawElement(this System.Drawing.Graphics g, Models.UIElements.IElement element) {
            g.DrawImage(element.RenderBitmap(), 0, 0);
        }

        public static void DrawImage(this System.Drawing.Graphics g, System.Drawing.Image img) {
            g.DrawImage(img, 0, 0);
        }

        public static void DrawElement(this System.Drawing.Graphics g, Models.UIElements.IAnchoredElement element) {
            g.DrawImage(element.RenderBitmap(), element.X, element.Y);
        }

        public static void DrawElement(this System.Drawing.Graphics g, System.Drawing.Image img, Models.UIElements.IAnchoredElement element) {
            g.DrawImage(img, element.X, element.Y);
        }
    }
}
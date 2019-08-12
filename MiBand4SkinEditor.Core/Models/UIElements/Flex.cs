using System;
using System.Collections.Generic;
using System.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;

namespace MiBand4SkinEditor.Core.Models.UIElements {
    public static class Flex {
        public static Image<Argb32> FlexRender(int spacing, params Image<Argb32>[] images) {
            return FlexRender(spacing, (IEnumerable<Image<Argb32>>) images);
        }

        public static Image<Argb32> FlexRender(int spacing, IEnumerable<Image<Argb32>> images) {
            var canvas = new Image<Argb32>(Constants.PanelWidth, Constants.PanelHeight);
            canvas.Mutate(c => c.Fill(Brushes.Solid(new Argb32(0, 0, 0, 0))));
            int x = 0;
            const int y = 0;
            foreach (var image in images) {
                canvas.Mutate(c => c.DrawImage(image, new Point(x, y), PixelColorBlendingMode.Normal, 1));
                x += image.Width + spacing;
            }

            return canvas;
        }
    }
}

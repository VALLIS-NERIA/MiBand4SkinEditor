using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiBand4SkinEditor.Core.Models.Json;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;

namespace MiBand4SkinEditor.Core.Models.UIElements {
    public class FlexDate :DateBase, IElement {
        public override Slice<Image<Argb32>> Numbers { get; protected set; }
        public override Pick<Image<Argb32>> Divider { get; protected set; }

        private int x;
        private int y;

        public override int X => this.x;

        public override int Y => this.y;

        public override void Move(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public int Spacing { get; set; }

        public static FlexDate FromJson(SkinManifestJson json, Image<Argb32>[] images) {
            var s = json.Date.MonthAndDay.OneLine;
            var d = new FlexDate
            {
                Numbers = images.Slice(s.Number.ImageIndex, s.Number.ImagesCount),
                Divider = images.Pick(s.DelimiterImageIndex),
                x = s.Number.TopLeftX,
                y = s.Number.TopLeftY,
                Spacing = s.Number.Spacing
            };

            return d;
        }

        private static Image<Argb32> FlexRender(int leftTopX, int leftTopY, int spacing, params Image<Argb32>[] images) {
            return FlexRender(leftTopX, leftTopY, spacing, (IEnumerable<Image<Argb32>>) images);
        }

        private static Image<Argb32> FlexRender(int leftTopX, int leftTopY, int spacing, IEnumerable<Image<Argb32>> images) {
            var canvas = new Image<Argb32>(Constants.PanelWidth, Constants.PanelHeight);
            canvas.Mutate(c => c.Fill(Brushes.Solid(new Argb32(0, 0, 0, 0))));
            int x = leftTopX;
            int y = leftTopY;
            foreach (var image in images) {
                canvas.Mutate(c => c.DrawImage(image, new Point(x, y), PixelColorBlendingMode.Normal, 1));
                x += image.Width + spacing;
            }

            return canvas;
        }

        public override Image<Argb32> Render(int a, int b, int c, int d) {
            return FlexRender(0, 0, this.Spacing, this.Numbers[a], this.Numbers[b], this.Divider.Item, this.Numbers[c], this.Numbers[d]);
        }
    }
}
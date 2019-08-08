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
    public class FlexDate : IAnchoredElement {
        public Slice<Image<Argb32>> Numbers;
        public Pick<Image<Argb32>> Divider;

        private int x;
        private int y;

        public int X {
            get => this.x;
            set => this.MoveTo(value, this.y);
        }

        public int Y {
            get => this.y;
            set => this.MoveTo(this.x, value);
        }

        public void MoveTo(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public int Spacing { get; set; }

        private static (int min, int max) GetMinMax(params int[] nums) {
            int min = int.MaxValue;
            int max = int.MinValue;
            foreach (int num in nums) {
                if (num < min) min = num;
                if (num > max) max = num;
            }

            return (min, max);
        }

        public static FlexDate FromJson(SkinManifestJson json, Image<Argb32>[] images) {
            var s = json.Date.MonthAndDay.OneLine;
            var d = new FlexDate
            {
                Numbers = images.Slice(s.Number.ImageIndex, s.Number.ImagesCount),
                Divider = images.Pick(s.DelimiterImageIndex),
                X = s.Number.TopLeftX,
                Y = s.Number.TopLeftY,
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
                canvas.Mutate(c => c.DrawImage(image, new Point(x, y), PixelColorBlendingMode.Overlay, 1));
                x += image.Width + spacing;
            }

            return canvas;
        }

        public Image<Argb32> Render() {
            return FlexRender(0, 0, this.Spacing, this.Numbers[0], this.Numbers[7], this.Divider.Item, this.Numbers[2], this.Numbers[2]);
        }

        public void Move(int xOffset, int yOffset) {
            this.x += xOffset;
            this.y += yOffset;
        }
    }
}
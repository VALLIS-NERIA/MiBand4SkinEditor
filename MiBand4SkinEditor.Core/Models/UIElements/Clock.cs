using System;
using System.Collections.Generic;
using System.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;

namespace MiBand4SkinEditor.Core.Models.UIElements {
    public class Clock : IElement {
        public readonly Slice<Image<Argb32>> Numbers;

        public int X { get; set; }
        public int Y { get; set; }

        public int Width => this.MinuteTenX + this.NumberDistance - this.X + this.NumberDistance;
        public int Height => this.Numbers[0].Height + 2 * this.NumberMargin;

        public int NumberMargin { get; set; } = 0;
        private int? numberWidth = null;

        // By default it's Numbers[0]'s width + NumberMargin. If you manually set this value, NumberMargin will be ignored.
        public int NumberDistance {
            get => this.numberWidth ?? this.Numbers[0].Width + this.NumberMargin;
            set => this.numberWidth = value;
        }

        public int HourMinuteDistance { get; set; } = 10;

        public Clock(Slice<Image<Argb32>> numbers) {
            this.Numbers = numbers;
        }

        #region auto-calculate

        public Slice<Image<Argb32>> HourTensNumbers => this.Numbers;
        public Slice<Image<Argb32>> HourOnesNumbers => this.Numbers;
        public Slice<Image<Argb32>> MinuteTensNumbers => this.Numbers;
        public Slice<Image<Argb32>> MinuteOnesNumbers => this.Numbers;

        public int HourTenX => this.X;
        public int HourTenY => this.Y;
        public int HourOneX => this.X + this.NumberDistance;
        public int HourOneY => this.Y;

        public int MinuteTenX => this.HourOneX + this.NumberDistance + this.HourMinuteDistance;
        public int MinuteTenY => this.Y;
        public int MinuteOneX => this.MinuteTenX + this.NumberDistance;
        public int MinuteOneY => this.Y;

        #endregion

        public Image<Argb32> Render() {
            var canvas = new Image<Argb32>(this.Width, this.Height);
            canvas.Mutate(x => x.Fill(Brushes.Solid(new Argb32(0, 0, 0, 0))));
            canvas.Mutate(x => x.DrawImage(this.Numbers[1], new Point(this.HourTenX, this.NumberMargin), PixelColorBlendingMode.Overlay, 1));
            canvas.Mutate(x => x.DrawImage(this.Numbers[2], new Point(this.HourOneX, this.NumberMargin), PixelColorBlendingMode.Overlay, 1));
            canvas.Mutate(x => x.DrawImage(this.Numbers[4], new Point(this.MinuteTenX, this.NumberMargin), PixelColorBlendingMode.Overlay, 1));
            canvas.Mutate(x => x.DrawImage(this.Numbers[9], new Point(this.MinuteOneX, this.NumberMargin), PixelColorBlendingMode.Overlay, 1));

            return canvas;
        }
    }
}
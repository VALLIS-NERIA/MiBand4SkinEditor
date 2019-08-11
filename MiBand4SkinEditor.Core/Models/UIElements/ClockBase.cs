using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;

namespace MiBand4SkinEditor.Core.Models.UIElements {
    public abstract class ClockBase : IElement {
        public abstract int X { get; }
        public abstract int Y { get; }
        public abstract Slice<Image<Argb32>> HourTensNumbers { get; set; }

        public abstract Slice<Image<Argb32>> HourOnesNumbers { get; set; }

        public abstract Slice<Image<Argb32>> MinuteTensNumbers { get; set; }
        public abstract Slice<Image<Argb32>> MinuteOnesNumbers { get; set; }

        public abstract int HourTenX { get; set; }
        public abstract int HourTenY { get; set; }
        public abstract int HourOneX { get; set; }
        public abstract int HourOneY { get; set; }

        public abstract int MinuteTenX { get; set; }
        public abstract int MinuteTenY { get; set; }
        public abstract int MinuteOneX { get; set; }
        public abstract int MinuteOneY { get; set; }

        public abstract void Move(int x, int y);

        public virtual Image<Argb32> Render(params object[] args) {
            if (args.All(o => o is int) && args.Length >= 4) {
                return this.Render((int) args[0], (int) args[1], (int) args[2], (int) args[3]);
            }
            else if (args[0] is DateTime time) {
                return this.Render(time);
            }
            else {
                return this.Render(DateTime.Now);
            }
        }

        public virtual Image<Argb32> Render(DateTime time) {
            return this.Render(time.Hour % 10, time.Hour / 10, time.Minute % 10, time.Minute / 10);
        }

        public virtual Image<Argb32> Render(int h1, int h2, int m1, int m2) {
            var canvas = new Image<Argb32>(Constants.PanelWidth, Constants.PanelHeight);
            canvas.Mutate(x => x.Fill(Brushes.Solid(new Argb32(0, 0, 0, 0))));
            canvas.Mutate(x => x.DrawImage(this.HourTensNumbers[h1], new Point(this.HourTenX, this.HourTenY), PixelColorBlendingMode.Normal, 1));
            canvas.Mutate(x => x.DrawImage(this.HourOnesNumbers[h2], new Point(this.HourOneX, this.HourOneY), PixelColorBlendingMode.Normal, 1));
            canvas.Mutate(x => x.DrawImage(this.MinuteTensNumbers[m1], new Point(this.MinuteTenX, this.MinuteTenY), PixelColorBlendingMode.Normal, 1));
            canvas.Mutate(x => x.DrawImage(this.MinuteOnesNumbers[m2], new Point(this.MinuteOneX, this.MinuteOneY), PixelColorBlendingMode.Normal, 1));

            return canvas;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;

namespace MiBand4SkinEditor.Core.Models.UIElements {
    public abstract class ClockBase : IElement {
        //public abstract int Width { get; }
        //public abstract int Height { get; }

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

        public virtual void Move(int xOffset, int yOffset) {
            this.HourTenX += xOffset;
            this.HourOneX += xOffset;
            this.MinuteTenX += xOffset;
            this.MinuteOneX += xOffset;
            this.HourTenY += yOffset;
            this.HourOneY += yOffset;
            this.MinuteTenY += yOffset;
            this.MinuteOneY += yOffset;
        }

        public virtual Image<Argb32> Render() => this.Render(2, 8, 5, 7);

        public virtual Image<Argb32> Render(int h1, int h2, int m1, int m2) {
            var canvas = new Image<Argb32>(Constants.PanelWidth, Constants.PanelHeight);
            canvas.Mutate(x => x.Fill(Brushes.Solid(new Argb32(0, 0, 0, 0))));
            canvas.Mutate(x => x.DrawImage(this.HourTensNumbers[h1], new Point(this.HourTenX, this.HourTenY), PixelColorBlendingMode.Overlay, 1));
            canvas.Mutate(x => x.DrawImage(this.HourOnesNumbers[h2], new Point(this.HourOneX, this.HourOneY), PixelColorBlendingMode.Overlay, 1));
            canvas.Mutate(x => x.DrawImage(this.MinuteTensNumbers[m1], new Point(this.MinuteTenX, this.MinuteTenY), PixelColorBlendingMode.Overlay, 1));
            canvas.Mutate(x => x.DrawImage(this.MinuteOnesNumbers[m2], new Point(this.MinuteOneX, this.MinuteOneY), PixelColorBlendingMode.Overlay, 1));

            return canvas;
        }
    }
}
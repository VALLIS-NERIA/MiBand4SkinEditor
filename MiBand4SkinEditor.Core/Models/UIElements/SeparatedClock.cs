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
    public class SeparatedClock :ClockBase, IElement {
        public override Slice<Image<Argb32>> HourTensNumbers { get; set; }
        public override Slice<Image<Argb32>> HourOnesNumbers { get; set; }

        public override Slice<Image<Argb32>> MinuteTensNumbers { get; set; }
        public override Slice<Image<Argb32>> MinuteOnesNumbers { get; set; }

        public override int HourTenX { get; set; }
        public override int HourTenY { get; set; }
        public override int HourOneX { get; set; }
        public override int HourOneY { get; set; }

        public override int MinuteTenX { get; set; }
        public override int MinuteTenY { get; set; }
        public override int MinuteOneX { get; set; }
        public override int MinuteOneY { get; set; }

        public override int X => 0;
        public override int Y => 0;
        public override bool Moveable => false;

        public override void Move(int xOffset, int yOffset) {
            this.HourTenX += xOffset;
            this.HourOneX += xOffset;
            this.MinuteTenX += xOffset;
            this.MinuteOneX += xOffset;
            this.HourTenY += yOffset;
            this.HourOneY += yOffset;
            this.MinuteTenY += yOffset;
            this.MinuteOneY += yOffset;
        }

        public static SeparatedClock FromJson(SkinManifestJson json, Image<Argb32>[] images) {
            var s = json.Time;
            var c = new SeparatedClock
            {
                HourTensNumbers = images.Slice(s.Hours.Tens.ImageIndex, s.Hours.Tens.ImagesCount),
                HourOnesNumbers = images.Slice(s.Hours.Ones.ImageIndex, s.Hours.Ones.ImagesCount),
                MinuteTensNumbers = images.Slice(s.Minutes.Tens.ImageIndex, s.Minutes.Tens.ImagesCount),
                MinuteOnesNumbers = images.Slice(s.Minutes.Ones.ImageIndex, s.Minutes.Ones.ImagesCount),

                HourTenX = s.Hours.Tens.X,
                HourTenY = s.Hours.Tens.Y,
                HourOneX = s.Hours.Ones.X,
                HourOneY = s.Hours.Ones.Y,
                MinuteTenX = s.Minutes.Tens.X,
                MinuteTenY = s.Minutes.Tens.Y,
                MinuteOneX = s.Minutes.Ones.X,
                MinuteOneY = s.Minutes.Ones.Y,
            };

            return c;
        }
    }
}
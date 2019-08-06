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
    public class SeparatedClock : ClockBase {
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

        private int x = 0;
        public override int X {
            get => this.x;
            set {
                int shift = value - this.x;
                this.HourTenX += shift;
                this.HourOneX += shift;
                this.MinuteTenX += shift;
                this.MinuteOneX += shift;
                this.x += shift;
            }
        }

        private int y = 0;
        public override int Y {
            get => this.y;
            set {
                int shift = value - this.y;
                this.HourTenY += shift;
                this.HourOneY += shift;
                this.MinuteTenY += shift;
                this.MinuteOneY += shift;
                this.y += shift;
            }
        }

        //public override int Width {
        //    get {
        //        var (left, right) = GetMinMax(this.HourTenX, this.HourOneX, this.MinuteTenX, this.MinuteOneX);
        //        return right - left;
        //    }
        //}

        //public override int Height {
        //    get {
        //        var (top, bottom) = GetMinMax(this.HourTenY, this.HourOneY, this.MinuteTenY, this.MinuteOneY);
        //        return bottom - top;
        //    }
        //}

        private static (int min, int max) GetMinMax(params int[] nums) {
            int min = int.MaxValue;
            int max = int.MinValue;
            foreach (int num in nums) {
                if (num < min) min = num;
                if (num > max) max = num;
            }

            return (min, max);
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
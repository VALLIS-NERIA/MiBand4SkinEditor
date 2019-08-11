using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using MiBand4SkinEditor.Core.Models.Json;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace MiBand4SkinEditor.Core.Models.UIElements {
    public class DayOfWeek : IElement {
        private int x;
        public int X => x;

        private int y;
        public int Y => y;

        public Slice<Image<Argb32>> Numbers { get; private set; }

        public Image<Argb32> Render(params object[] args) {
            if (args.Length < 1) return this.Render(DateTime.Now.DayOfWeek);
            switch (args[0]) {
            case int d:
                return this.Render(d);
            case System.DayOfWeek dow:
                return this.Render(dow);
            case DateTime dt:
                return this.Render(dt.DayOfWeek);
            default:
                return this.Render(DateTime.Now.DayOfWeek);
            }
        }

        public Image<Argb32> Render(int dow) {
            return this.Numbers[dow];
        }

        public Image<Argb32> Render(System.DayOfWeek dow) {
            return this.Numbers[((int) dow + 6) % 7];
        }

        public void Move(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public static DayOfWeek FromJson(SkinManifestJson json, Image<Argb32>[] images) {
            var ret = new DayOfWeek
            {
                Numbers = images.Slice(json.Date.WeekDay.ImageIndex, json.Date.WeekDay.ImagesCount),
                x = json.Date.WeekDay.X,
                y = json.Date.WeekDay.Y
            };
            return ret;
        }

        public static DayOfWeek Create(Slice<Image<Argb32>> numbers) {
            var ret = new DayOfWeek {Numbers = numbers};
            return ret;
        }
    }
}
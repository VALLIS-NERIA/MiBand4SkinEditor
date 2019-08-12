using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace MiBand4SkinEditor.Core.Models.UIElements {
    public abstract class DateBase : IElement<DateTime> {
        public abstract Slice<Image<Argb32>> Numbers { get; protected set; }
        public abstract Pick<Image<Argb32>> Divider { get; protected set; }

        public abstract int X { get; }
        public abstract int Y { get; }

        public DateTime Data { get; set; } = DateTime.Now;
        
        public virtual Image<Argb32> Render(params object[] args) {
            if (args.All(o => o is int) && args.Length >= 4) {
                return this.Render((int) args[0], (int) args[1], (int) args[2], (int) args[3]);
            }
            else if (args[0] is DateTime time) {
                return this.Render(time);
            }
            else {
                return this.Render(this.Data);
            }
        }

        public virtual Image<Argb32> Render(DateTime date) {
            return this.Render(date.Month / 10, date.Month % 10, date.Day / 10, date.Day % 10);
        }

        public abstract Image<Argb32> Render(int a, int b, int c, int d);

        public abstract void Move(int x, int y);
    }
}
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;

namespace MiBand4SkinEditor.Core.Models.UIElements {
    // currently only supports month and day in one line
    public class Date: IElement {
        public Slice<Image<Argb32>> Numbers;
        public ArrayElement<Image<Argb32>> Divider;


        public int X { get; set; }
        public int Y { get; set; }
        public int Width => this.DayOneX + this.NumberDistance - this.X + this.NumberDistance;
        public int Height => this.Numbers[0].Height + 2 * this.NumberMargin;
        
        public int NumberMargin { get; set; } = 2;
        private int? numberWidth = null;

        // By default it's Numbers[0]'s width + NumberMargin. If you manually set this value, NumberMargin will be ignored.
        public int NumberDistance {
            get => this.numberWidth ?? this.Numbers[0].Width + this.NumberMargin;
            set => this.numberWidth = value;
        }

        // we have a divider
        public int MonthDateDistance { get; set; } = 0;

        #region auto-calculate

        public Slice<Image<Argb32>> MonthTensNumbers => this.Numbers;
        public Slice<Image<Argb32>> MonthOnesNumbers => this.Numbers;
        public Slice<Image<Argb32>> DayTensNumbers => this.Numbers;
        public Slice<Image<Argb32>> DayOnesNumbers => this.Numbers;

        public int MonthTenX => this.X;
        public int MonthTenY => this.Y;
        public int MonthOneX => this.X + this.NumberDistance;
        public int MonthOneY => this.Y;

        public int DividerX => this.MonthOneX + this.NumberDistance;
        public int DividerY => this.Y;

        public int DayTenX => this.DividerX + this.Divider.Item.Width + this.NumberMargin + this.MonthDateDistance;
        public int DayTenY => this.Y;
        public int DayOneX => this.DayTenX + this.NumberDistance;
        public int DayOneY => this.Y;

        #endregion

        public Image<Argb32> Render() {
            var canvas = new Image<Argb32>(this.Width, this.Height);
            canvas.Mutate(x => x.Fill(Brushes.Solid(new Argb32(0, 0, 0, 0))));
            canvas.Mutate(x => x.DrawImage(this.Numbers[1], new Point(this.MonthTenX, this.NumberMargin), PixelColorBlendingMode.Overlay, 1));
            canvas.Mutate(x => x.DrawImage(this.Numbers[2], new Point(this.MonthOneX, this.NumberMargin), PixelColorBlendingMode.Overlay, 1));
            canvas.Mutate(x => x.DrawImage(this.Divider.Item, new Point(this.DividerX, this.NumberMargin), PixelColorBlendingMode.Overlay, 1));
            canvas.Mutate(x => x.DrawImage(this.Numbers[3], new Point(this.DayTenX, this.NumberMargin), PixelColorBlendingMode.Overlay, 1));
            canvas.Mutate(x => x.DrawImage(this.Numbers[4], new Point(this.DayOneX, this.NumberMargin), PixelColorBlendingMode.Overlay, 1));

            return canvas;
        }
    }
}

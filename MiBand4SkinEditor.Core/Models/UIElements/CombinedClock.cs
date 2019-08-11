using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;

namespace MiBand4SkinEditor.Core.Models.UIElements {
    public class CombinedClock : ClockBase, IElement {
        public Slice<Image<Argb32>> Numbers { get; set; }

        private int x;
        private int y;

        public override int X => this.x;

        public override int Y => this.y;

        #region format

        private int numberMargin = 0;

        public int NumberMargin {
            get => this.numberMargin;
            set {
                this.numberMargin = value;
                this.Align();
            }
        }

        // By default it's Numbers[0]'s width + NumberMargin. If you manually set this value, NumberMargin will be ignored.
        private int? numberWidth = null;

        public int NumberDistance {
            get => this.numberWidth ?? this.Numbers[0].Width + this.NumberMargin;
            set => this.numberWidth = value;
        }


        private int hourMinuteDistance = 10;

        public int HourMinuteDistance {
            get => this.hourMinuteDistance;
            set {
                this.hourMinuteDistance = value;
                this.Align();
            }
        }

        #endregion

        #region relative positions

        public int RelativeHourTenX;
        public int RelativeHourTenY;
        public int RelativeHourOneX;
        public int RelativeHourOneY;

        public int RelativeMinuteTenX;
        public int RelativeMinuteTenY;
        public int RelativeMinuteOneX;
        public int RelativeMinuteOneY;

        #endregion

        #region auto-calculated properties

        public override Slice<Image<Argb32>> HourTensNumbers {
            get => this.Numbers;
            set => this.Numbers = value;
        }

        public override Slice<Image<Argb32>> HourOnesNumbers {
            get => this.Numbers;
            set => this.Numbers = value;
        }

        public override Slice<Image<Argb32>> MinuteTensNumbers {
            get => this.Numbers;
            set => this.Numbers = value;
        }

        public override Slice<Image<Argb32>> MinuteOnesNumbers {
            get => this.Numbers;
            set => this.Numbers = value;
        }

        public override int HourTenX {
            get => this.X + this.RelativeHourTenX;
            set => this.RelativeHourTenX = value - this.X;
        }

        public override int HourTenY {
            get => this.Y + this.RelativeHourTenY;
            set => this.RelativeHourTenY = value - this.Y;
        }

        public override int HourOneX {
            get => this.X + this.RelativeHourOneX;
            set => this.RelativeHourOneX = value - this.X;
        }

        public override int HourOneY {
            get => this.Y + this.RelativeHourOneY;
            set => this.RelativeHourOneY = value - this.Y;
        }

        public override int MinuteTenX {
            get => this.X + this.RelativeMinuteTenX;
            set => this.RelativeMinuteTenX = value - this.X;
        }

        public override int MinuteTenY {
            get => this.Y + this.RelativeMinuteTenY;
            set => this.RelativeMinuteTenY = value - this.Y;
        }

        public override int MinuteOneX {
            get => this.X + this.RelativeMinuteOneX;
            set => this.RelativeMinuteOneX = value - this.X;
        }

        public override int MinuteOneY {
            get => this.Y + this.RelativeMinuteOneY;
            set => this.RelativeMinuteOneY = value - this.Y;
        }

        #endregion

        private CombinedClock() { }

        public override void Move(int x, int y) {
            this.x = x;
            this.x = y;
            this.Align();
        }

        public void Align() {
            this.RelativeHourTenY = this.RelativeHourOneY = this.RelativeMinuteTenY = this.RelativeMinuteOneY = this.NumberMargin;
            this.RelativeHourTenX = this.NumberMargin;
            this.RelativeHourOneX = this.RelativeHourTenX + this.NumberDistance;
            this.RelativeMinuteTenX = this.RelativeHourOneX + this.NumberDistance + this.HourMinuteDistance;
            this.RelativeMinuteOneX = this.RelativeMinuteTenX + this.NumberDistance;
        }

        public static CombinedClock Generate(Slice<Image<Argb32>> numbers, int x = 0, int y = 0, int? numberWidth = null, int hmDistance = 10) {
            var c = new CombinedClock
            {
                x = x,
                y = y,
                Numbers = numbers,
                numberWidth = numberWidth, // field numberWidth
                hourMinuteDistance = hmDistance,
            };
            c.Align();

            return c;
        }
    }
}
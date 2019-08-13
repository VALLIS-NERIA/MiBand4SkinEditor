using System;
using System.Collections.Generic;
using System.Text;
using MiBand4SkinEditor.Core.Models.Json;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;

namespace MiBand4SkinEditor.Core.Models.UIElements {
    public class IconGroup: IElementGroup {
        public string Name => "IconGroup";
        public int X => 0;
        public int Y => 0;
        public bool Moveable => false;

        public bool ShowLock { get; set; } = true;
        public bool ShowAlarm { get; set; } = true;
        public bool ShowBluetoothDisconnected { get; set; } = true;

        public LockIcon Lock { get; private set; }
        public AlarmIcon Alarm { get; private set; }
        public BluetoothDisconnectedIcon Bluetooth { get; private set; }


        public Image<Argb32> Render(params object[] args) {
            var canvas = new Image<Argb32>(Constants.PanelWidth, Constants.PanelHeight);
            canvas.Mutate(x => x.Fill(Brushes.Solid(new Argb32(0, 0, 0, 0))));
            canvas.Mutate(x => x.DrawImage(this.Lock.Render(this.ShowLock), new Point(this.Lock.X, this.Lock.Y), PixelColorBlendingMode.Normal, 1));
            canvas.Mutate(x => x.DrawImage(this.Alarm.Render(this.ShowAlarm), new Point(this.Alarm.X, this.Alarm.Y), PixelColorBlendingMode.Normal, 1));
            canvas.Mutate(x => x.DrawImage(this.Bluetooth.Render(this.ShowBluetoothDisconnected), new Point(this.Bluetooth.X, this.Bluetooth.Y), PixelColorBlendingMode.Normal, 1));
            return canvas;
        }



        public void Move(int x, int y) {
            this.Lock.Shift(x, y);
            this.Alarm.Shift(x, y);
            this.Bluetooth.Shift(x, y);
        }

        public static IconGroup FromJson(SkinManifestJson json, Image<Argb32>[] images) {
            var ig = new IconGroup()
            {
                Lock = LockIcon.FromJson(json, images),
                Alarm = AlarmIcon.FromJson(json, images),
                Bluetooth = BluetoothDisconnectedIcon.FromJson(json, images)
            };
            return ig;
        }

        public IEnumerable<IElement> Elements => new IElement[] {this.Lock, this.Alarm, this.Bluetooth};

        public Image<Argb32> Render() => this.Render(null);
    }
}

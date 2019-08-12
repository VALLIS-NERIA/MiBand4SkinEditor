using System;
using System.Collections.Generic;
using System.Text;
using MiBand4SkinEditor.Core.Models.Json;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace MiBand4SkinEditor.Core.Models.UIElements {
    public abstract class IconElement : IElement<bool> {
        public int X { get; protected set; }
        public int Y { get; protected set; }

        public Pick<Image<Argb32>> Image;

        public Image<Argb32> Render(params object[] args) {
            if (args != null && args.Length >= 1 && args[0] is bool show) {
                return this.Render(show);
            }

            return this.Render(this.Data);
        }

        public void Move(int x, int y) {
            this.X = x;
            this.Y = y;
        }

        public bool Data { get; set; } = true;

        public virtual Image<Argb32> Render(bool arg) => arg ? this.Image.Item : new Image<Argb32>(Configuration.Default, 0, 0, new Argb32(0, 0, 0, 0));
    }

    public class AlarmIcon : IconElement {
        private AlarmIcon() { }
        
        public static AlarmIcon FromJson(SkinManifestJson json, Image<Argb32>[] images) {
            var a = new AlarmIcon();
            a.Image = images.Pick(json.Status.Alarm.ImageIndexOn);
            a.X = json.Status.Alarm.Coordinates.X;
            a.Y = json.Status.Alarm.Coordinates.Y;

            return a;
        }
    }

    public class NoDisturbIcon : IconElement {
        private NoDisturbIcon() { }

        public static NoDisturbIcon FromJson(SkinManifestJson json, Image<Argb32>[] images) {
            var a = new NoDisturbIcon();
            a.Image = images.Pick(json.Status.Lock.ImageIndexOn);
            a.X = json.Status.Lock.Coordinates.X;
            a.Y = json.Status.Lock.Coordinates.Y;

            return a;
        }
    }

    public class BluetoothDisconnectedIcon : IconElement {
        private BluetoothDisconnectedIcon() { }

        public static BluetoothDisconnectedIcon FromJson(SkinManifestJson json, Image<Argb32>[] images) {
            var a = new BluetoothDisconnectedIcon();
            a.Image = images.Pick(json.Status.Bluetooth.ImageIndexOff);
            a.X = json.Status.Bluetooth.Coordinates.X;
            a.Y = json.Status.Bluetooth.Coordinates.Y;

            return a;
        }
    }
}
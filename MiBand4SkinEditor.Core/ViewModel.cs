using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using MiBand4SkinEditor.Core.Models;
using MiBand4SkinEditor.Core.Models.Json;
using MiBand4SkinEditor.Core.Models.UIElements;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;

namespace MiBand4SkinEditor.Core {
    public class ViewModel {
        private string skinDirPath;
        private Image<Argb32>[] images;
        private Pick<Image<Argb32>> backgroundImage;

        private SkinManifestJson json;
        private IElement clock;
        private IElement date;
        private IElement dow;
        private IElement alarm;
        private IElement noDisturb;
        private IElement noBluetooth;

        public void LoadAssets(string dirPath) {
            this.skinDirPath = dirPath;
            var files = Directory.EnumerateFiles(this.skinDirPath).ToArray();
            this.images = files
                          .Where(n => n.EndsWith(".png", StringComparison.OrdinalIgnoreCase) && int.TryParse(Path.GetFileNameWithoutExtension(n), out int _))
                          .OrderBy(n => int.Parse(Path.GetFileNameWithoutExtension(n)))
                          .Select(Image.Load<Argb32>)
                          .ToArray();
            this.json = SkinManifestJson.FromJson(File.ReadAllText(files.First(n => n.EndsWith(".json", StringComparison.OrdinalIgnoreCase))));

            this.LoadElements();
        }

        private void LoadElements() {
            this.backgroundImage = this.images.Pick(this.json.Background.Image.ImageIndex);
            this.clock = SeparatedClock.FromJson(this.json, this.images);
            this.date = FlexDate.FromJson(this.json, this.images);
            this.dow = Models.UIElements.DayOfWeek.FromJson(this.json, this.images);
            this.alarm = AlarmIcon.FromJson(this.json, this.images);
            this.noDisturb = NoDisturbIcon.FromJson(this.json, this.images);
            this.noBluetooth = BluetoothDisconnectedIcon.FromJson(this.json, this.images);
        }

        public Image<Argb32> Draw() {
            var canvas = new Image<Argb32>(Constants.PanelWidth, Constants.PanelHeight);
            canvas.Mutate(x => x.Fill(Brushes.Solid(new Argb32(0, 0, 0, 0))));
            if (this.backgroundImage == null) return canvas;

            canvas.Mutate(x => x.DrawImage(this.backgroundImage.Item, new Point(0, 0), PixelColorBlendingMode.Normal, 1));
            canvas.Mutate(x => x.DrawImage(this.clock.Render(DateTime.Now), new Point(this.clock.X, this.clock.Y), PixelColorBlendingMode.Normal, 1));
            canvas.Mutate(x => x.DrawImage(this.date.Render(DateTime.Now), new Point(this.date.X, this.date.Y), PixelColorBlendingMode.Normal, 1));
            canvas.Mutate(x => x.DrawImage(this.dow.Render(DateTime.Now), new Point(this.dow.X, this.dow.Y), PixelColorBlendingMode.Normal, 1));
            canvas.Mutate(x => x.DrawImage(this.alarm.Render(true), new Point(this.alarm.X, this.alarm.Y), PixelColorBlendingMode.Normal, 1));
            canvas.Mutate(x => x.DrawImage(this.noDisturb.Render(true), new Point(this.noDisturb.X, this.noDisturb.Y), PixelColorBlendingMode.Normal, 1));
            canvas.Mutate(x => x.DrawImage(this.noBluetooth.Render(true), new Point(this.noBluetooth.X, this.noBluetooth.Y), PixelColorBlendingMode.Normal, 1));

            return canvas;
        }
    }
}

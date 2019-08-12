using System;
using System.Collections.Generic;
using System.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace MiBand4SkinEditor.Core.Models.UIElements {
    public class IconGroup: IElement {
        public int X { get; }
        public int Y { get; }

        public bool ShowNoDisturb { get; set; }
        public bool ShowAlarm { get; set; }
        public bool ShowBluetoothDisconnected { get; set; }

        public Image<Argb32> Render(params object[] args) => throw new NotImplementedException();

        public void Move(int x, int y) {
            throw new NotImplementedException();
        }
    }
}

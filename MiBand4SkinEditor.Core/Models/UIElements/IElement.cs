using System;
using System.Collections.Generic;
using System.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace MiBand4SkinEditor.Core.Models.UIElements {
    public interface IElement {
        Image<Argb32> Render();

        int X { get; set; }
        int Y { get; set; }
        int Width { get; }
        int Height { get; }
    }
}
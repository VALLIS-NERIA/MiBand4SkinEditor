using System;
using System.Collections.Generic;
using System.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace MiBand4SkinEditor.Core.Models.UIElements {
    public interface IElement {
        int X { get; }

        int Y { get; }

        Image<Argb32> Render(params object[] args);
        
        void Move(int x, int y);
    }
}
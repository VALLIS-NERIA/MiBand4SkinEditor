using System;
using System.Collections.Generic;
using System.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace MiBand4SkinEditor.Core.Models.UIElements {
    public interface IElement {
        Image<Argb32> Render();

        void Move(int xOffset, int yOffset);
    }

    public interface IAnchorlessElement : IElement { }

    public interface IAnchoredElement : IElement {
        int X { get; }

        int Y { get; }

        void MoveTo(int x, int y);
    }
}
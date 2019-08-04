using System;
using System.Collections.Generic;
using System.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace MiBand4SkinEditor.Core.Models.UIElements {
    interface IElement {
        Image<Argb32> Render();
    }
}

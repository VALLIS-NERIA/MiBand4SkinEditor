using System;
using System.Collections.Generic;
using System.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace MiBand4SkinEditor.Core.Models {
    public class SkinImageMap {

        public Image<Argb32>[] DateNumbers;
        public Image<Argb32>[] Weekdays;

        public Image<Argb32> AmCn;
        public Image<Argb32> PmCn;
        public Image<Argb32> AmEn;
        public Image<Argb32> PmEn;
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MiBand4SkinEditor.Core.Models {
    public struct Point2 {
        public int X { get; set; }
        public int Y { get; set; }

        public Point2(int x, int y) {
            this.X = x;
            this.Y = y;
        }
    }
}

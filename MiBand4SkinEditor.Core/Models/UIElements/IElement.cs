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

    public interface IElement <T> : IElement where T : struct {
        T Data { get; set; }
        Image<Argb32> Render(T arg);
    }

    public static class IElementExtensions {
        public static bool TryParse <T>(this IElement<T> element, string data) where T:struct {
            try {
                var d = (T) Convert.ChangeType(data, typeof(T));
                element.Data = d;
                return true;
            }
            catch {
                return false;
            }
        }
    }
}
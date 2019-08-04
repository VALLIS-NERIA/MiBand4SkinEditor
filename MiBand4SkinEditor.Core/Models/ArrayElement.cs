using System;
using System.Collections.Generic;
using System.Text;

namespace MiBand4SkinEditor.Core.Models {
    public class ArrayElement<T> {
        private T[] array;
        private int index;

        public ArrayElement(T[] array, int index) {
            if (array == null || index > array.Length || index < 0) {
                throw new ArgumentException($"invalid argument for ArrayElement: {array}, {index}, where array.Length is {array?.Length}");
            }
            this.array = array;
            this.index = index;
        }

        public T Item {
            get => this.array[this.index];
            set => this.array[this.index] = value;
        }
    }
}

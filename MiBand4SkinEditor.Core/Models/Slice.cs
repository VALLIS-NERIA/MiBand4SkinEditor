using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MiBand4SkinEditor.Core.Models {
    public class Slice <T> : IEnumerable<T>, IReadWriteList<T> {
        private T[] Array { get; }
        private int Start { get; }
        private int Length { get; }

        public Slice(T[] array, int start, int length) {
            if (array == null || start < 0 || length < 0 || start + length > array.Length) {
                throw new ArgumentException("slice init illegal!");
            }

            this.Array = array;
            this.Start = start;
            this.Length = length;
        }

        public static implicit operator Slice<T>(T[] array) {
            return new Slice<T>(array, 0, array.Length);
        }

        public T this[int i] {
            get => this.Array[i + this.Start];
            set => this.Array[i + this.Start] = value;
        }

        public IEnumerator<T> GetEnumerator() {
            for (int i = 0; i < this.Length; i++) {
                yield return this.Array[i + this.Length];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public Span<T> Span => new Span<T>(this.Array, this.Start, this.Length);

        public T[] ToArray() => this.Span.ToArray();

        public int Count => this.Length - this.Start;
    }

    public class Pick <T> {
        private T[] array;
        private int index;

        public Pick(T[] array, int index) {
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

    public interface IReadWriteList <T> : IReadOnlyList<T> {
        new T this[int i] { get; set; }
    }

    public static class Helper {
        public static Slice<T> Slice <T>(this T[] me, int start, int length) {
            return new Slice<T>(me, start, length);
        }

        public static Pick<T> Pick <T>(this T[] me, int index) {
            return new Pick<T>(me, index);
        }
    }
}
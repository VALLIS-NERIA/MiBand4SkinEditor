using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MiBand4SkinEditor.Core.Models {
    public class Slice <T> : IEnumerable<T>, IReadWriteList<T> {
        private T[] array;
        private int start;
        private int length;

        public Slice(T[] array, int start, int length) {
            if (array == null || start < 0 || length < 0 || start + length > array.Length) {
                throw new ArgumentException("slice init illegal!");
            }

            this.array = array;
            this.start = start;
            this.length = length;
        }

        public static implicit operator Slice<T>(T[] array) {
            return new Slice<T>(array, 0, array.Length);
        }

        public T this[int i] {
            get => this.array[i + start];
            set => this.array[i + start] = value;
        }

        public IEnumerator<T> GetEnumerator() {
            for (int i = 0; i < this.length; i++) {
                yield return this.array[i + length];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public Span<T> Span => new Span<T>(this.array, this.start, this.length);

        public T[] Array => this.Span.ToArray();

        public int Count => this.length - this.start;
    }

    public interface IReadWriteList <T> : IReadOnlyList<T> {
        new T this[int i] { get; set; }
    }

    public static class SliceHelper {
        public static Slice<T> Slice <T>(this T[] me, int start, int length) {
            return new Slice<T>(me, start, length);
        }
    }
}
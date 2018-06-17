using System;
using System.Collections.Generic;
using System.Linq;

namespace DSA.BLL.DataStructures.Array
{
    public class Sequence<T> : ICluster<T>
    {
        private readonly T[] _array;

        public Sequence()
        {
            _array = new T[Count];
        }

        public Sequence(int count)
        {
            Count = count;
            _array = new T[Count];
        }

        public bool Contains(T item)
        {
            for (var i = 0; i < Count; i++)
                if (_array[i].Equals(item))
                    return true;

            return false;
        }

        public int IndexOf(T item)
        {
            for (var i = 0; i < Count; i++)
                if (_array[i].Equals(item))
                    return i;

            return -1;
        }

        public void Reverse()
        {
            for (int i = 0, j = Count - 1; i < j; i++, j--)
            {
                var tmp = _array[i];
                _array[i] = _array[j];
                _array[j] = tmp;
            }
        }

        public void Clear()
        {
            for (var i = 0; i < Count; i++) _array[i] = default(T);
        }

        public IEnumerable<T> ToEnumerable()
        {
            for (var i = 0; i < Count; i++) yield return _array[i];
        }

        public T this[int index]
        {
            get
            {
                if (index >= Count)
                    throw new IndexOutOfRangeException("Index grater or equal count.");
                return _array[index];
            }
            set
            {
                if (index >= Count)
                    throw new IndexOutOfRangeException("Index grater or equal count.");
                _array[index] = value;
            }
        }

        public int Count { get; } = 16;

        public override string ToString()
        {
            return "[ " + ToEnumerable().Aggregate("", (x, y) => x + (!string.IsNullOrEmpty(x) ? ", " : "") + y) + " ]";
        }
    }
}
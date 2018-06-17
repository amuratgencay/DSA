using System;
using System.Collections.Generic;
using System.Linq;
using DSA.Entity.DataStructures;

namespace DSA.BLL.DataStructures.Array
{
    public class Sequence<T> : ICluster<T>
    {
        private readonly int _count = 16;
        private readonly T[] _array;

        public Sequence()
        {
            _array = new T[_count];
        }

        public Sequence(int count)
        {
            _count = count;
            _array = new T[_count];
        }

        public bool Contains(T item)
        {
            for (var i = 0; i < _count; i++)
                if (_array[i].Equals(item))
                    return true;

            return false;
        }

        public int IndexOf(T item)
        {
            for (var i = 0; i < _count; i++)
                if (_array[i].Equals(item))
                    return i;

            return -1;
        }

        public void Reverse()
        {
            for (int i = 0, j = _count - 1; i < j; i++, j--)
            {
                var tmp = _array[i];
                _array[i] = _array[j];
                _array[j] = tmp;
            }
        }

        public void Clear()
        {
            for (var i = 0; i < _count; i++) _array[i] = default(T);
        }

        public IEnumerable<T> ToEnumerable()
        {
            for (var i = 0; i < _count; i++) yield return _array[i];
        }

        public T this[int index]
        {
            get
            {
                if (index >= _count)
                    throw new ArgumentOutOfRangeException(nameof(index), "index grater or equal count");
                return _array[index];
            }
            set
            {
                if (index >= _count)
                    throw new ArgumentOutOfRangeException(nameof(index), "index grater or equal count");
                _array[index] = value;
            }
        }

        public int Count()
        {
            return _count;
        }

        public override string ToString()
        {
            return "[ " + ToEnumerable().Aggregate("", (x, y) => x + (!string.IsNullOrEmpty(x) ? ", " : "") + y) + " ]";
        }
    }
}
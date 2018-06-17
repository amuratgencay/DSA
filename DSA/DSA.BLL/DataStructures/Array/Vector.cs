using System;
using System.Collections.Generic;
using System.Linq;

namespace DSA.BLL.DataStructures.Array
{
    public class Vector<T> : IExpandedCluster<T>
    {
        private readonly int _factory = 2;
        private T[] _array;
        private int _index;

        public Vector()
        {
            _array = new T[Count];
        }

        public Vector(int count, int factory = 2)
        {
            Count = count;
            _factory = factory;
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

            _index = 0;
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
                if (index > _index)
                    _index = index + 1;

                while (_index - 1 >= Count)
                    CloneVector();

                _array[index] = value;
            }
        }

        public int Count { get; private set; } = 16;

        public void Add(T item)
        {
            if (_index >= Count) CloneVector();
            _array[_index++] = item;
        }

        public void Insert(int index, T item)
        {
            if (_index >= Count) CloneVector();

            var tmp = _array[index];
            _array[index] = item;
            for (var i = index; i < Count - 1; i++)
            {
                var tmp2 = _array[i + 1];
                _array[i + 1] = tmp;
                tmp = tmp2;
            }
        }

        public bool Remove(T item)
        {
            if (Contains(item))
            {
                _array[IndexOf(item)] = default(T);
                return true;
            }

            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index >= Count)
                throw new IndexOutOfRangeException("Index grater or equal count.");

            _array[index] = default(T);
            return true;
        }

        private void CloneVector()
        {
            var tmpCount = Count * _factory;
            var tmp = new T[tmpCount];
            for (var i = 0; i < Count; i++) tmp[i] = _array[i];
            _array = tmp;
            Count = tmpCount;
        }

        public override string ToString()
        {
            return "{ " + ToEnumerable().Aggregate("", (x, y) => x + (!string.IsNullOrEmpty(x) ? ", " : "") + y) + " }";
        }
    }
}
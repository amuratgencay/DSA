using System;
using System.Collections.Generic;
using System.Linq;
using DSA.Entity.DataStructures;

namespace DSA.BLL.DataStructures.Array
{
    public class Vector<T> : IExpandedCluster<T>
    {
        private readonly int _factory = 2;
        private T[] _array;
        private int _count = 16;
        private int _index;

        public Vector()
        {
            _array = new T[_count];
        }

        public Vector(int count, int factory = 2)
        {
            _count = count;
            _factory = factory;
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

            _index = 0;
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
                if (index > _index)
                    _index = index + 1;
            }
        }

        public int Count()
        {
            return _count;
        }

        public void Add(T item)
        {
            if (_index >= _count) CloneVector();
            _array[_index++] = item;
        }

        public void Insert(int index, T item)
        {
            if (_index >= _count) CloneVector();

            var tmp = _array[index];
            _array[index] = item;
            for (var i = index; i < _count - 1; i++)
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
            if (index >= _count)
                throw new ArgumentOutOfRangeException(nameof(index), "index grater or equal count");

            _array[index] = default(T);
            return true;
        }

        private void CloneVector()
        {
            var tmpCount = _count * _factory;
            var tmp = new T[tmpCount];
            for (var i = 0; i < _count; i++) tmp[i] = _array[i];
            _array = tmp;
            _count = tmpCount;
        }

        public override string ToString()
        {
            return "{ " + ToEnumerable().Aggregate("", (x, y) => x + (!string.IsNullOrEmpty(x) ? ", " : "") + y) + " }";
        }
    }
}
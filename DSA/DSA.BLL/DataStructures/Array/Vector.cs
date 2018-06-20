using System;
using System.Collections.Generic;
using System.Linq;

namespace DSA.BLL.DataStructures.Array
{
    public class Vector<T> : ICountable<T>
    {
        private readonly int _factor;
        protected int Index;

        public Vector()
        {
            Array = new T[1];
            _factor = 1;
        }

        public Vector(int count, int factor = 1)
        {
            Array = new T[count];
            _factor = factor;
        }

        protected T[] Array { get; set; }
        public virtual int Count => Array.Length;

        public virtual void Clear()
        {
            for (var i = 0; i < Count; i++)
                Array[i] = default(T);
            Index = 0;
        }

        public virtual bool Contains(T item)
        {
            for (var i = 0; i < Count; i++)
                if (Array[i].Equals(item))
                    return true;

            return false;
        }

        public int IndexOf(T item, int startIndex = 0)
        {
            for (var i = 0; i < Count; i++)
                if (Array[i].Equals(item))
                    return i;

            return -1;
        }

        public int LastIndexOf(T item, int startIndex = 0)
        {
            throw new NotImplementedException();
        }

        public virtual void Reverse(int startIndex = 0, int endIndex = 0)
        {
            if (startIndex >= Count || startIndex < 0)
                startIndex = 0;
            if (endIndex >= Count || endIndex <= 0)
                endIndex = Count - 1;
            if (startIndex >= endIndex)
            {
                startIndex = 0;
                endIndex = Count - 1;
            }


            for (int i = startIndex, j = endIndex; i < j; i++, j--)
            {
                var tmp = Array[i];
                Array[i] = Array[j];
                Array[j] = tmp;
            }
        }

        public virtual IEnumerable<T> GetEnumerable()
        {
            return Array.ToList();
        }

        public T this[int index]
        {
            get => Array[index];
            set
            {
                if (index > Index)
                    Index = index + 1;

                while (Index - 1 >= Count)
                    ResizeArray();

                Array[index] = value;
            }
        }

        public virtual void Add(T item)
        {
            while (Index >= Count) ResizeArray();
            Array[Index++] = item;
        }

        public virtual void Insert(int index, T item)
        {
            while (Index >= Count) ResizeArray();

            var tmp = Array[index];
            Array[index] = item;
            for (var i = index; i < Count - 1; i++)
            {
                var tmp2 = Array[i + 1];
                Array[i + 1] = tmp;
                tmp = tmp2;
            }

            Index++;
        }

        public virtual bool Remove(T item)
        {
            if (!Contains(item)) return false;
            Array[IndexOf(item)] = default(T);
            Index--;
            return true;
        }

        public virtual bool RemoveAt(int index)
        {
            Array[index] = default(T);
            Index--;
            return true;
        }

        protected void ResizeArray()
        {
            var tmpCount = Count + _factor;
            var tmp = new T[tmpCount];
            for (var i = 0; i < Count; i++) tmp[i] = Array[i];
            Array = tmp;
        }

        public override string ToString()
        {
            return $"[ {GetEnumerable().Aggregate("", (x, y) => x + (!string.IsNullOrEmpty(x) ? ", " : "") + y)} ]";
        }
    }
}
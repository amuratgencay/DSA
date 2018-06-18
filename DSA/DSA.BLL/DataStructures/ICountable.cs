using System;
using System.Collections.Generic;
using System.Linq;

namespace DSA.BLL.DataStructures
{
    public interface ICountable<T>
    {
        T this[int index] { get; set; }
        int Count { get; }
        void Clear();
        bool Contains(T item);
        int IndexOf(T item);
        void Reverse();
        IEnumerable<T> GetEnumerable();
    }

    public abstract class Countable<T> : ICountable<T>
    {
        protected Countable(int count)
        {
            Array = new T[count];
        }

        protected T[] Array { get; set; }

        public virtual T this[int index]
        {
            get => Array[index];
            set => Array[index] = value;
        }

        public virtual void Clear()
        {
            for (var i = 0; i < Count; i++)
                Array[i] = default(T);
        }

        public virtual int Count => Array.Length;

        public bool Contains(T item)
        {
            for (var i = 0; i < Count; i++)
                if (Array[i].Equals(item))
                    return true;

            return false;
        }

        public virtual int IndexOf(T item)
        {
            for (var i = 0; i < Count; i++)
                if (Array[i].Equals(item))
                    return i;

            return -1;
        }

        public virtual void Reverse()
        {
            for (int i = 0, j = Count - 1; i < j; i++, j--)
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


        public override string ToString()
        {
            return "[ " + GetEnumerable().Aggregate("", (x, y) => x + (!string.IsNullOrEmpty(x) ? ", " : "") + y) +
                   " ]";
        }
    }

    public abstract class ExpandedCountableArray<T> : Countable<T>
    {
        private readonly int _factor = 2;
        protected int Index;

        protected ExpandedCountableArray() : base(8)
        {
        }

        protected ExpandedCountableArray(int count) : base(count)
        {
        }

        protected ExpandedCountableArray(int count, int factor) : base(count)
        {
            _factor = factor;
        }

        public override T this[int index]
        {
            get
            {
                if (index >= Count)
                    throw new IndexOutOfRangeException("Index grater or equal count.");
                return Array[index];
            }
            set
            {
                if (index > Index)
                    Index = index + 1;

                while (Index - 1 >= Count)
                    ResizeArray();

                Array[index] = value;
            }
        }

        protected virtual void Add(T item)
        {
            if (Index >= Count) ResizeArray();
            Array[Index++] = item;
        }

        protected virtual void Insert(int index, T item)
        {
            if (Index >= Count) ResizeArray();

            var tmp = Array[index];
            Array[index] = item;
            for (var i = index; i < Count - 1; i++)
            {
                var tmp2 = Array[i + 1];
                Array[i + 1] = tmp;
                tmp = tmp2;
            }
        }

        protected virtual bool Remove(T item)
        {
            if (!Contains(item)) return false;
            Array[IndexOf(item)] = default(T);
            return true;
        }

        protected virtual bool RemoveAt(int index)
        {
            if (index >= Count)
                throw new IndexOutOfRangeException("Index grater or equal count.");
            Array[index] = default(T);
            return true;
        }


        protected void ResizeArray()
        {
            var tmpCount = Count * _factor;
            var tmp = new T[tmpCount];
            for (var i = 0; i < Count; i++) tmp[i] = Array[i];
            Array = tmp;
        }
    }
}
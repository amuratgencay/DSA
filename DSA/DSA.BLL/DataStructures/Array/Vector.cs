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
            Arr = new T[1];
            _factor = 1;
        }

        public Vector(int count, int factor = 1)
        {
            Arr = new T[count];
            _factor = factor;
        }

        protected T[] Arr { get; set; }
        public virtual int Count => Arr.Length;

        public virtual void Clear()
        {
            for (var i = 0; i < Count; i++)
                Arr[i] = default(T);
            Index = 0;
        }

        public virtual bool Contains(T item)
        {
            for (var i = 0; i < Count; i++)
                if (Arr[i].Equals(item))
                    return true;

            return false;
        }

        public int IndexOf(T item, int startIndex = 0)
        {
            for (var i = startIndex; i < Count; i++)
                if (Arr[i].Equals(item))
                    return i;

            return -1;
        }

        public int LastIndexOf(T item, int startIndex = 0)
        {
            if (startIndex <= 0)
                startIndex = Count - 1;

            for (var i = startIndex; i >= 0; i--)
                if (Arr[i].Equals(item))
                    return i;

            return -1;
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
                var tmp = Arr[i];
                Arr[i] = Arr[j];
                Arr[j] = tmp;
            }
        }

        public virtual IEnumerable<T> GetEnumerable()
        {
            return Arr.ToList();
        }

        public T this[int index]
        {
            get => Arr[index];
            set
            {
                if (index > Index)
                    Index = index + 1;

                while (Index - 1 >= Count)
                    ResizeArray();

                Arr[index] = value;
            }
        }

        public object Clone()
        {
            var res = new Vector<T>(Count);
            for (var i = 0; i < Count; i++) res[i] = Arr[i];

            res.Index = Index;
            return res;
        }

        public virtual void Add(T item)
        {
            while (Index >= Count) ResizeArray();
            Arr[Index++] = item;
        }

        public virtual void Insert(int index, T item)
        {
            while (Index >= Count) ResizeArray();

            var tmp = Arr[index];
            Arr[index] = item;
            for (var i = index; i < Count - 1; i++)
            {
                var tmp2 = Arr[i + 1];
                Arr[i + 1] = tmp;
                tmp = tmp2;
            }

            Index++;
        }

        public virtual bool Remove(T item)
        {
            if (!Contains(item)) return false;
            Arr[IndexOf(item)] = default(T);
            Index--;
            return true;
        }

        public virtual bool RemoveAt(int index)
        {
            Arr[index] = default(T);
            Index--;
            return true;
        }

        protected void ResizeArray()
        {
            var tmpCount = Count + _factor;
            var tmp = new T[tmpCount];
            for (var i = 0; i < Count; i++) tmp[i] = Arr[i];
            Arr = tmp;
        }

        public override string ToString()
        {
            return $"[ {GetEnumerable().Aggregate("", (x, y) => x + (!string.IsNullOrEmpty(x) ? ", " : "") + y)} ]";
        }
    }
}
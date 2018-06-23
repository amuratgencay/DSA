using System.Collections.Generic;
using System.Linq;

namespace DSA.BLL.DataStructures.Array
{
    public class Array<T> : ICountable<T>
    {
        public Array(int count)
        {
            Arr = new T[count];
        }

        protected T[] Arr { get; set; }

        public virtual T this[int index]
        {
            get => Arr[index];
            set => Arr[index] = value;
        }

        public virtual void Clear()
        {
            for (var i = 0; i < Count; i++)
                Arr[i] = default(T);
        }

        public virtual int Count => Arr.Length;

        public bool Contains(T item)
        {
            for (var i = 0; i < Count; i++)
                if (Arr[i].Equals(item))
                    return true;

            return false;
        }

        public virtual int IndexOf(T item, int startIndex = 0)
        {
            for (var i = startIndex; i < Count; i++)
                if (Arr[i].Equals(item))
                    return i;

            return -1;
        }

        public virtual int LastIndexOf(T item, int startIndex = 0)
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

        public object Clone()
        {
            var res = new Array<T>(Count);
            for (var i = 0; i < Count; i++) res[i] = Arr[i];

            return res;
        }


        public override string ToString()
        {
            return $"[ {GetEnumerable().Aggregate("", (x, y) => x + (!string.IsNullOrEmpty(x) ? ", " : "") + y)} ]";
        }
    }
}
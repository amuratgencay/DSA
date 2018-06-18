using System.Collections.Generic;
using System.Linq;

namespace DSA.BLL.DataStructures.Queue
{
    public abstract class Queue<T> : IQueue<T>
    {
        protected int Index;
        public abstract T this[int index] { get; set; }
        public int Count { get; protected set; } = 16;
        public abstract bool Contains(T item);
        public abstract int IndexOf(T item);
        public abstract void Reverse();
        public abstract void Clear();
        public abstract IEnumerable<T> ToEnumerable();
        public abstract T Peek();
        public bool IsEmpty => Count == 0;
        public bool IsFull => Index >= Count;

        public override string ToString()
        {
            return "{ " + ToEnumerable().Aggregate("", (x, y) => x + (!string.IsNullOrEmpty(x) ? ", " : "") + y) + " }";
        }

        public abstract void Enqueue(T item);
        public abstract T Dequeue();
    }

}

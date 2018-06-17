using System.Collections.Generic;
using System.Linq;

namespace DSA.BLL.DataStructures.Stack
{
    public abstract class Stack<T> : IStack<T>
    {
        protected int Index;
        public abstract T this[int index] { get; set; }
        public int Count { get; protected set; } = 16;
        public abstract bool Contains(T item);
        public abstract int IndexOf(T item);
        public abstract void Reverse();
        public abstract void Clear();
        public abstract IEnumerable<T> ToEnumerable();
        public abstract void Push(T item);
        public abstract T Pop();
        public abstract T Peek();
        public bool IsEmpty => Index <= 0;
        public bool IsFull => Index >= Count;

        public override string ToString()
        {
            return "{ " + ToEnumerable().Aggregate("", (x, y) => x + (!string.IsNullOrEmpty(x) ? ", " : "") + y) + " }";
        }
    }
}
using System;
using DSA.BLL.DataStructures.Array;

namespace DSA.BLL.DataStructures.Queue
{
    public class FixedQueue<T> : Sequence<T>, IQueue<T>
    {
        protected int Index;

        public FixedQueue(int count) : base(count)
        {
        }

        public bool IsEmpty => Count == 0;
        public bool IsFull => Index >= Count;

        public override void Clear()
        {
            base.Clear();
            Index = 0;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Stack is empty.");
            return Array[0];
        }

        public void Enqueue(T item)
        {
            if (IsFull)
                throw new IndexOutOfRangeException("Stack is full.");
            Array[Index++] = item;
        }

        public T Dequeue()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Stack is empty.");

            var res = Array[0];
            for (var i = 1; i < Count; i++) Array[i - 1] = Array[i];
            Array[Count - 1] = default(T);
            return res;
        }
    }
}
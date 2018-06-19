using System;
using DSA.BLL.DataStructures.Array;

namespace DSA.BLL.DataStructures.Queue
{
    public class VectorQueue<T> : Vector<T>, IQueue<T>
    {
        public VectorQueue()
        {
        }

        public VectorQueue(int count) : base(count)
        {
        }

        public VectorQueue(int count, int factor) : base(count, factor)
        {
        }

        public bool IsEmpty => Index <= 0;
        public bool IsFull => Index >= Count;

        public virtual void Enqueue(T item)
        {
            Add(item);
        }

        public virtual T Dequeue()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Queue is empty.");
            var res = Array[0];
            for (var i = 1; i < Count; i++) Array[i - 1] = Array[i];
            Array[Count - 1] = default(T);
            Index--;
            return res;
        }

        public virtual T Peek()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Queue is empty.");
            return Array[0];
        }

        public override void Reverse(int startIndex = 0, int endIndex = 0)
        {
            base.Reverse(startIndex, Index - 1);
        }
    }
}
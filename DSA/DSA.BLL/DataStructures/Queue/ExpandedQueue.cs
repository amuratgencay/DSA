using System;
using DSA.BLL.DataStructures.Array;

namespace DSA.BLL.DataStructures.Queue
{
    public class ExpandedQueue<T> : Vector<T>, IQueue<T>
    {
        public ExpandedQueue()
        {
        }

        public ExpandedQueue(int count) : base(count)
        {
        }

        public ExpandedQueue(int count, int factor) : base(count, factor)
        {
        }

        public bool IsEmpty => Count == 0;
        public bool IsFull => Index >= Count;

        public virtual void Enqueue(T item)
        {
            Add(item);
            Index++;
        }

        public virtual T Dequeue()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Stack is empty.");
            var res = Array[0];
            RemoveAt(0);
            return res;
        }

        public virtual T Peek()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Stack is empty.");
            return Array[0];
        }
    }
}
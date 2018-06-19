using System;
using DSA.BLL.DataStructures.Array;

namespace DSA.BLL.DataStructures.Queue
{
    public class ArrayQueue<T> : Array<T>, IQueue<T>
    {
        protected int Index;

        public ArrayQueue(int count) : base(count)
        {
        }

        public override void Clear()
        {
            base.Clear();
            Index = 0;
        }

        public bool IsEmpty => Index <= 0;
        public bool IsFull => Index >= Count;

        public T Peek()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Queue is empty.");
            return Arr[0];
        }

        public void Enqueue(T item)
        {
            if (IsFull)
                throw new IndexOutOfRangeException("Queue is full.");
            Arr[Index++] = item;
        }

        public T Dequeue()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Stack is empty.");

            var res = Arr[0];
            for (var i = 1; i < Count; i++) Arr[i - 1] = Arr[i];
            Arr[Count - 1] = default(T);
            Index--;
            return res;
        }

        public override void Reverse(int startIndex = 0, int endIndex = 0)
        {
            base.Reverse(startIndex, Index - 1);
        }
    }
}
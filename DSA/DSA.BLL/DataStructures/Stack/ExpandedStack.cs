using System;

namespace DSA.BLL.DataStructures.Stack
{
    public class ExpandedStack<T> : ExpandedCountableArray<T>, IStack<T>
    {
        public ExpandedStack()
        {
        }

        public ExpandedStack(int count) : base(count)
        {
        }

        public ExpandedStack(int count, int factor) : base(count, factor)
        {
        }

        public bool IsEmpty => Count == 0;
        public bool IsFull => Index >= Count;

        public virtual void Push(T item)
        {
            Add(item);
            Index++;
        }

        public virtual T Pop()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Stack is empty.");
            var res = Array[Count - 1];
            RemoveAt(Count - 1);
            Index--;
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
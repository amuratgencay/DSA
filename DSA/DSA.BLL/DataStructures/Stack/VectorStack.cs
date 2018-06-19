using System;
using DSA.BLL.DataStructures.Array;

namespace DSA.BLL.DataStructures.Stack
{
    public class VectorStack<T> : Vector<T>, IStack<T>
    {
        public VectorStack()
        {
        }

        public VectorStack(int count) : base(count)
        {
        }

        public VectorStack(int count, int factor) : base(count, factor)
        {
        }

        public bool IsEmpty => Index <= 0;
        public bool IsFull => Index >= Count;

        public virtual void Push(T item)
        {
            Add(item);
        }

        public virtual T Pop()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Stack is empty.");
            Index--;
            var res = Array[Index];
            RemoveAt(Index);
            return res;
        }

        public virtual T Peek()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Stack is empty.");
            return Array[0];
        }

        public override void Reverse(int startIndex = 0, int endIndex = 0)
        {
            base.Reverse(startIndex, Index - 1);
        }
    }
}
using System;
using DSA.BLL.DataStructures.Array;

namespace DSA.BLL.DataStructures.Stack
{
    public class FixedStack<T> : Sequence<T>, IStack<T>
    {
        protected int Index;

        public FixedStack(int count) : base(count)
        {
        }

        public override void Clear()
        {
            base.Clear();
            Index = 0;
        }

        public bool IsEmpty => Count == 0;
        public bool IsFull => Index >= Count;

        public virtual void Push(T item)
        {
            if (IsFull)
                throw new IndexOutOfRangeException("Stack is full.");

            Array[Index++] = item;
        }

        public virtual T Pop()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Stack is empty.");
            Index--;

            var res = Array[Index];
            Array[Index] = default(T);

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
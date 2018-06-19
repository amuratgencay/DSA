using System;
using DSA.BLL.DataStructures.Array;

namespace DSA.BLL.DataStructures.Stack
{
    public class ArrayStack<T> : Array<T>, IStack<T>
    {
        protected int Index;

        public ArrayStack(int count) : base(count)
        {
        }

        public override void Clear()
        {
            base.Clear();
            Index = 0;
        }

        public bool IsEmpty => Index <= 0;
        public bool IsFull => Index >= Count;

        public virtual void Push(T item)
        {
            if (IsFull)
                throw new IndexOutOfRangeException("Stack is full.");

            Arr[Index++] = item;
        }

        public virtual T Pop()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Stack is empty.");
            Index--;

            var res = Arr[Index];
            Arr[Index] = default(T);

            return res;
        }

        public virtual T Peek()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Stack is empty.");
            return Arr[0];
        }

        public override void Reverse(int startIndex = 0, int endIndex = 0)
        {
            base.Reverse(startIndex, Index - 1);
        }
    }
}
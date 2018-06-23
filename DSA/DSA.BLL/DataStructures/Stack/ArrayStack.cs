using System;
using System.Collections.Generic;
using DSA.BLL.DataStructures.Array;

namespace DSA.BLL.DataStructures.Stack
{
    public class ArrayStack<T> : IStack<T>
    {
        protected Array<T> Array;
        protected int Index;

        public ArrayStack(int count)
        {
            Array = new Array<T>(count);
        }

        public void Clear()
        {
            Array.Clear();
            Index = 0;
        }

        public bool IsEmpty => Index <= 0;
        public bool IsFull => Index >= Array.Count;

        public int Count => Array.Count;

        public T this[int index]
        {
            get => Array[index];
            set => Array[index] = value;
        }

        public void Push(T item)
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

        public void Reverse(int startIndex = 0, int endIndex = 0)
        {
            Array.Reverse(startIndex, Index - 1);
        }

        public bool Contains(T item)
        {
            return Array.Contains(item);
        }

        public int IndexOf(T item, int startIndex = 0)
        {
            return Array.IndexOf(item, startIndex);
        }

        public int LastIndexOf(T item, int startIndex = 0)
        {
            return Array.LastIndexOf(item, startIndex);
        }

        public IEnumerable<T> GetEnumerable()
        {
            return Array.GetEnumerable();
        }

        public object Clone()
        {
            return new ArrayStack<T>(Count)
            {
                Array = (Array<T>) Array.Clone(),
                Index = Index
            };
        }

        public override string ToString()
        {
            return Array.ToString();
        }
    }
}
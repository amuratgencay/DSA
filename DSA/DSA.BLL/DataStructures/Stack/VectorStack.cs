using System;
using System.Collections.Generic;
using DSA.BLL.DataStructures.Array;

namespace DSA.BLL.DataStructures.Stack
{
    public class VectorStack<T> : IStack<T>
    {
        protected int Index;
        protected Vector<T> Vector;

        public VectorStack()
        {
            Vector = new Vector<T>();
        }

        public VectorStack(int count)
        {
            Vector = new Vector<T>(count);
        }

        public VectorStack(int count, int factor)
        {
            Vector = new Vector<T>(count, factor);
        }

        public bool IsEmpty => Index <= 0;
        public bool IsFull => Index >= Count;

        public int Count => Vector.Count;

        public T this[int index]
        {
            get => Vector[index];
            set => Vector[index] = value;
        }

        public void Clear()
        {
            Vector.Clear();
            Index = 0;
        }

        public void Push(T item)
        {
            Vector.Add(item);
            Index++;
        }

        public virtual T Pop()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Stack is empty.");
            Index--;
            var res = Vector[Index];
            Vector.RemoveAt(Index);
            return res;
        }

        public virtual T Peek()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Stack is empty.");
            return Vector[0];
        }

        public void Reverse(int startIndex = 0, int endIndex = 0)
        {
            Vector.Reverse(startIndex, Index - 1);
        }

        public bool Contains(T item)
        {
            return Vector.Contains(item);
        }

        public int IndexOf(T item, int startIndex = 0)
        {
            return Vector.IndexOf(item, startIndex);
        }

        public int LastIndexOf(T item, int startIndex = 0)
        {
            return Vector.LastIndexOf(item, startIndex);
        }

        public IEnumerable<T> GetEnumerable()
        {
            return Vector.GetEnumerable();
        }

        public object Clone()
        {
            return new VectorStack<T>(Count)
            {
                Vector = (Vector<T>) Vector.Clone(),
                Index = Index
            };
        }

        public override string ToString()
        {
            return Vector.ToString();
        }
    }
}
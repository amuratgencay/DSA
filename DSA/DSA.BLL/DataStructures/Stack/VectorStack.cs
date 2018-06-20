using System;
using System.Collections.Generic;
using DSA.BLL.DataStructures.Array;

namespace DSA.BLL.DataStructures.Stack
{
    public class VectorStack<T> : IStack<T>
    {
        protected Vector<T> vector;
        protected int index;
        public VectorStack()
        {
            vector = new Vector<T>();
        }

        public VectorStack(int count)
        {
            vector = new Vector<T>(count);
        }

        public VectorStack(int count, int factor) 
        {
            vector = new Vector<T>(count, factor);
        }

        public bool IsEmpty => index <= 0;
        public bool IsFull => index >= Count;

        public int Count => vector.Count;

        public T this[int index] { get => vector[index]; set => vector[index] = value; }

        public void Clear()
        {
            vector.Clear();
            index = 0;
        }

        public void Push(T item)
        {
            vector.Add(item);
            index++;
        }

        public virtual T Pop()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Stack is empty.");
            index--;
            var res = vector[index];
            vector.RemoveAt(index);
            return res;
        }

        public virtual T Peek()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Stack is empty.");
            return vector[0];
        }

        public void Reverse(int startIndex = 0, int endIndex = 0)
        {
            vector.Reverse(startIndex, index - 1);
        }

        public bool Contains(T item) => vector.Contains(item);

        public int IndexOf(T item) => vector.IndexOf(item);

        public IEnumerable<T> GetEnumerable() => vector.GetEnumerable();

        public override string ToString() => vector.ToString();
    }
}
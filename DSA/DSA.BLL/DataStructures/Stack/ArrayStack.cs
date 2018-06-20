using System;
using System.Collections.Generic;
using DSA.BLL.DataStructures.Array;

namespace DSA.BLL.DataStructures.Stack
{
    public class ArrayStack<T> : IStack<T>
    {
        protected Array<T> array;
        protected int index;

        public ArrayStack(int count) 
        {
            array = new Array<T>(count);
        }

        public void Clear()
        {
            array.Clear();
            index = 0;
        }

        public bool IsEmpty => index <= 0;
        public bool IsFull => index >= array.Count;

        public int Count => array.Count;

        public T this[int index] { get => array[index]; set => array[index] = value; }

        public void Push(T item)
        {
            if (IsFull)
                throw new IndexOutOfRangeException("Stack is full.");

            array[index++] = item;
        }

        public virtual T Pop()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Stack is empty.");
            index--;

            var res = array[index];
            array[index] = default(T);

            return res;
        }

        public virtual T Peek()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Stack is empty.");
            return array[0];
        }

        public void Reverse(int startIndex = 0, int endIndex = 0)
        {
            array.Reverse(startIndex, index - 1);
        }

        public bool Contains(T item) => array.Contains(item);

        public int IndexOf(T item) => array.IndexOf(item);

        public IEnumerable<T> GetEnumerable() => array.GetEnumerable();

        public override string ToString() => array.ToString();
    }
}
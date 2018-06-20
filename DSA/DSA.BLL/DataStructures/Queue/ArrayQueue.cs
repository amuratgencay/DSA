using System;
using System.Collections.Generic;
using DSA.BLL.DataStructures.Array;

namespace DSA.BLL.DataStructures.Queue
{
    public class ArrayQueue<T> : IQueue<T>
    {
        protected Array<T> array;
        protected int index;

        public ArrayQueue(int count) 
        {
            array = new Array<T>(count);
        }

        public void Clear()
        {
            array.Clear();
            index = 0;
        }

        public bool IsEmpty => index <= 0;
        public bool IsFull => index >= Count;

        public int Count => array.Count;

        public T this[int index] { get => array[index]; set => array[index] = value; }

        public T Peek()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Queue is empty.");
            return array[0];
        }

        public void Enqueue(T item)
        {
            if (IsFull)
                throw new IndexOutOfRangeException("Queue is full.");
            array[index++] = item;
        }

        public T Dequeue()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Stack is empty.");

            var res = array[0];
            for (var i = 1; i < Count; i++) array[i - 1] = array[i];
            array[Count - 1] = default(T);
            index--;
            return res;
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
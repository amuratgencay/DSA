using System;
using System.Collections.Generic;
using DSA.BLL.DataStructures.Array;

namespace DSA.BLL.DataStructures.Queue
{
    public class ArrayQueue<T> : IQueue<T>
    {
        protected Array<T> Arr;
        protected int Index;

        public ArrayQueue(int count)
        {
            Arr = new Array<T>(count);
        }

        public void Clear()
        {
            Arr.Clear();
            Index = 0;
        }

        public bool IsEmpty => Index <= 0;
        public bool IsFull => Index >= Count;

        public int Count => Arr.Count;

        public T this[int index]
        {
            get => Arr[index];
            set => Arr[index] = value;
        }

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

        public void Reverse(int startIndex = 0, int endIndex = 0)
        {
            Arr.Reverse(startIndex, Index - 1);
        }

        public bool Contains(T item)
        {
            return Arr.Contains(item);
        }

        public int IndexOf(T item, int startIndex = 0)
        {
            return Arr.IndexOf(item, startIndex);
        }

        public int LastIndexOf(T item, int startIndex = 0)
        {
            return Arr.LastIndexOf(item, startIndex);
        }

        public IEnumerable<T> GetEnumerable()
        {
            return Arr.GetEnumerable();
        }

        public object Clone()
        {
            return new ArrayQueue<T>(Count)
            {
                Arr = (Array<T>) Arr.Clone(),
                Index = Index
            };
        }

        public override string ToString()
        {
            return Arr.ToString();
        }
    }
}
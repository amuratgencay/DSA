using System;
using System.Collections.Generic;
using DSA.BLL.DataStructures.Array;

namespace DSA.BLL.DataStructures.Queue
{
    public class VectorQueue<T> : IQueue<T>
    {
        protected Vector<T> vector;
        protected int index;

        public VectorQueue()
        {
            vector = new Vector<T>();
        }

        public VectorQueue(int count)
        {
            vector = new Vector<T>(count);
        }

        public VectorQueue(int count, int factor)
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

        public void Enqueue(T item)
        {
            vector.Add(item);
            index++;
        }

        public T Dequeue()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Queue is empty.");
            var res = vector[0];
            for (var i = 1; i < Count; i++) vector[i - 1] = vector[i];
            vector[Count - 1] = default(T);
            index--;
            return res;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Queue is empty.");
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
using System;
using System.Collections.Generic;
using DSA.BLL.DataStructures.Array;

namespace DSA.BLL.DataStructures.Queue
{
    public class VectorQueue<T> : IQueue<T>
    {
        protected int Index;
        protected Vector<T> Vector;

        public VectorQueue()
        {
            Vector = new Vector<T>();
        }

        public VectorQueue(int count)
        {
            Vector = new Vector<T>(count);
        }

        public VectorQueue(int count, int factor)
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

        public void Enqueue(T item)
        {
            Vector.Add(item);
            Index++;
        }

        public T Dequeue()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Queue is empty.");
            var res = Vector[0];
            for (var i = 1; i < Count; i++) Vector[i - 1] = Vector[i];
            Vector[Count - 1] = default(T);
            Index--;
            return res;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Queue is empty.");
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
            return new VectorQueue<T>(Count)
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
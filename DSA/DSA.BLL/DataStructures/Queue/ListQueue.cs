using System;
using System.Collections.Generic;
using DSA.BLL.DataStructures.LinkedList.SinglyLinkedList;

namespace DSA.BLL.DataStructures.Queue
{
    public class ListQueue<T> : IQueue<T>
    {
        protected int Index;
        protected SinglyLinkedList<T> List;

        public ListQueue()
        {
            List = new SinglyLinkedList<T>();
        }

        public ListQueue(int count)
        {
            List = new SinglyLinkedList<T>();
            for (var i = 0; i < count; i++) List.Add(default(T));
        }


        public bool IsEmpty => Index <= 0;
        public bool IsFull => false;

        public int Count => List.Count;

        public T this[int index]
        {
            get => List[index];
            set => List[index] = value;
        }

        public void Clear()
        {
            List.Clear();
            Index = 0;
        }

        public void Enqueue(T item)
        {
            List.Add(item);
            Index++;
        }

        public T Dequeue()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Queue is empty.");
            var res = this[0];
            List.RemoveAt(0);
            Index--;
            return res;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException("Queue is empty.");
            return this[0];
        }


        public void Reverse(int startIndex = 0, int endIndex = 0)
        {
            List.Reverse(startIndex, Index - 1);
        }

        public bool Contains(T item)
        {
            return List.Contains(item);
        }

        public int IndexOf(T item, int startIndex = 0)
        {
            return List.IndexOf(item, startIndex);
        }

        public int LastIndexOf(T item, int startIndex = 0)
        {
            return List.LastIndexOf(item, startIndex);
        }

        public IEnumerable<T> GetEnumerable()
        {
            return List.GetEnumerable();
        }

        public object Clone()
        {
            return new ListQueue<T>(Count)
            {
                List = (SinglyLinkedList<T>) List.Clone(),
                Index = Index
            };
        }

        public override string ToString()
        {
            return List.ToString();
        }
    }
}